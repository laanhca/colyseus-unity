using System.Collections;
using System.Collections.Generic;
using Colyseus;
using Colyseus.Schema;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class ColyseusUnityClient : MonoBehaviour
{
    private ColyseusClient _unityClient;
    private ColyseusRoom<State> _room;
    private GamePlay _gamePlay;
    
    
    void Start()
    {
       
        _gamePlay = GameObject.Find("GamePlay").GetComponent<GamePlay>();
        ConnectToGameServer();
    }

    private async void ConnectToGameServer()
    {
        string endpoint = "ws://localhost:2567";
        //string endpoint = "ws://vps735892.ovh.net:2567";
        Debug.Log("Connecting to " + endpoint);
        _unityClient = new ColyseusClient(endpoint);
        _room = await _unityClient.Create<State>("game_room");
    }

    void Update()
    {
        
    }
}
