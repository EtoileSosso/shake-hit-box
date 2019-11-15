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
        socket.On("foreignMessage", onForeignMessage);
    }

    // This is the listener function definition
    void onConnectionEstabilished(SocketIOEvent evt)
    {
        Debug.Log("I am connected on server with ID " + evt.data.GetField("id"));

        message.AddField("identity", "UNITY_CLIENT");
        socket.Emit("main", message);
        message.Clear();
    }

    private void onForeignMessage(SocketIOEvent evt)
    {
        Debug.Log("Foreign Message: " + evt.data.GetField("message"));
    }
}
