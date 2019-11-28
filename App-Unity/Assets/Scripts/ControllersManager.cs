using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

struct SpheroClient
{
    JSONObject id;
    string color;

    public SpheroClient(JSONObject pId, string pColor)
    {
        id = pId;
        color = pColor;
    }

    public JSONObject Id { get => Id; set => id = value; }
    public string Color { get => color; set => color = value; }
}

public enum MotionType { HORIZONTAL, FRONT, WAVE, CIRCLE, IDLE, NONE }

public class ControllersManager
{
    private static ControllersManager instance;

    private ControllersManager() { }

    SocketIOComponent socket;
    JSONObject message;

    readonly List<string> colors = new List<string> { "purple", "pink", "orange", "red" };
    List<string> assignedColors;
    short maxPlayers = 4; // TODO set to colors.Length
    List<SpheroClient> players = new List<SpheroClient>();

    private bool allPlayersConnected = false;
    public bool AllPlayersConnected
    {
        get
        {
            return players.Count == maxPlayers;
        }
        set
        {
            allPlayersConnected = value;
        }
    }

    public void Test()
    {
        Debug.Log(players.Count);
    }

    public void Setup()
    {
        assignedColors = colors;
    }

    public void SetupNetwork()
    {
        socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
        message = new JSONObject();

        // This line will set up the listener function
        socket.On("connectionEstabilished", onConnectionEstabilished);
    }

    private void onConnectionEstabilished(SocketIOEvent evt)
    {
        Debug.Log("I am connected on server with ID " + evt.data.GetField("id"));

        message.AddField("id", evt.data.GetField("id"));
        message.AddField("message", "UNITY");
        socket.Emit("firstHello", message);
        message.Clear();

        listenForShperoClients();
    }

    public void listenForShperoClients()
    {
        socket.On("newSphero", onNewSphero);
    }

    private void onNewSphero(SocketIOEvent evt)
    {
        if (players.Count < maxPlayers)
        {
            JSONObject id = evt.data.GetField("id");
            Debug.Log("Registering new sphero with ID " + id);

            string color = assignColor();

            players.Add(new SpheroClient(id, color));

            Debug.Log(color);

            message.AddField("id", id);
            message.AddField("color", color);
            socket.Emit("colorAssigned", message);
            message.Clear();

            // Start sending shake order
            requireMotionDetection(MotionType.WAVE, id);
        }
    }

    private string assignColor()
    {
        assignedColors.RemoveAt(0);
        return colors[0];
    }

    public bool startListeningToMotion(MotionType type, List<PlayerByColor> players)
    {
        List<JSONObject> ids = new List<JSONObject>();
        for(int i = 0; i < players.Count; i++)
        {
            ids.Add(getIdOfPlayerByColor(players[i]));
        }

        Debug.Log(ids);

        return true;
    }

    private JSONObject getIdOfPlayerByColor(PlayerByColor player)
    {
        foreach(SpheroClient current in players)
        {
            if(current.Color == player.ToString().ToLower())
            {
                return current.Id;
            }
        }

        return null;
    }

    void requireMotionDetection(MotionType type, JSONObject id)
    {
        message.AddField("id", id);
        message.AddField("type", type.ToString());
        socket.Emit("motionDetection", message);
        message.Clear();

        Debug.Log("Sent motion detection order: " + type);

        listenForMotionDetectionReturn(id);
    }

    void listenForMotionDetectionReturn(JSONObject id)
    {
        socket.On("motionDetectionResult", onMotionDetectionReturn);
    }

    void onMotionDetectionReturn(SocketIOEvent evt)
    {
        Debug.Log("Motion detection return : " + evt.data.GetField("status"));
    }

    public static ControllersManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ControllersManager();
            }
            return instance;
        }
    }
}
