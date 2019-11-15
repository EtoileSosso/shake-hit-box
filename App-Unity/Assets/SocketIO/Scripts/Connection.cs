using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Connection : MonoBehaviour
{
    private SocketIOComponent socket;
    JSONObject message;

    public void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        message = new JSONObject();
        socket.On("connectionEstablished", onConnectionEstabilished);
        socket.On("doAction", onActions);
    }

    void onConnectionEstabilished(SocketIOEvent evt)
    {
        Debug.Log("Player is connected: " + evt.data.GetField("id"));
    }

    public void onActions(SocketIOEvent evt)
    {
        Debug.Log("test");
        Debug.Log(evt.data);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            message.AddField("message", "Hello! I am " + socket.sid);
            socket.Emit("actions", message);
            message.Clear();
        }
    }
}
