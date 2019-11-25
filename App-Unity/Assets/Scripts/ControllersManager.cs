using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class ControllersManager
{
    private static ControllersManager instance;

    private ControllersManager() { }

    SocketIOComponent socket;
    JSONObject message;

    public void Setup()
    {
        SetupNetwork();
    }


    public void SetupNetwork()
    {
        socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
        message = new JSONObject();

        // This line will set up the listener function
        socket.On("connectionEstabilished", onConnectionEstabilished);
    }

    void onConnectionEstabilished(SocketIOEvent evt)
    {
        Debug.Log("I am connected on server with ID " + evt.data.GetField("id"));

        message.AddField("id", evt.data.GetField("id"));
        message.AddField("message", "UNITY");
        socket.Emit("firstHello", message);
        message.Clear();
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
