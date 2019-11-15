using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Network : MonoBehaviour
{
    SocketIOComponent socket;
    JSONObject message;

    void Start()
    {
        socket = GameObject.Find("SocketIO").GetComponent<SocketIOComponent>();
        message = new JSONObject();

        // This line will set up the listener function
        socket.On("connectionEstabilished", onConnectionEstabilished);
    }

    // This is the listener function definition
    void onConnectionEstabilished(SocketIOEvent evt)
    {
        Debug.Log("Player is connected: " + evt.data.GetField("id"));

        message.AddField("message", "Hello! I am " + socket.sid);
        socket.Emit("main", message);
        message.Clear();
    }
}
