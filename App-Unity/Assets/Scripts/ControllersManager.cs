using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class ControllersManager
{
    private static ControllersManager instance;

    private ControllersManager() { }

    enum MotionType { SHAKE, TAP, WAVE, IDLE }

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
            bool a = requireMotionDetection(MotionType.WAVE, id);
        }
    }

    private string assignColor()
    {
        assignedColors.RemoveAt(0);
        return colors[0];
    }


    bool requireMotionDetection(MotionType type, JSONObject id)
    {
        message.AddField("id", id);
        message.AddField("type", type.ToString());
        socket.Emit("motionDetection", message);
        message.Clear();
        return false;
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
