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
        Debug.Log("[CLient] Client created");
        
        _room = await _unityClient.JoinOrCreate<State>("game_room");
        Debug.Log("[CLient] Room created with SessionId:"+  _room.SessionId);

        RegisterRoomHandlers();
        StartGame();
    }

    private void StartGame()
    {
        
    }

    private void RegisterRoomHandlers()
    {
        RoomHandlerCallbacks();

        RoomHandlerMessages();


        //handle message from server

    }

    private void RoomHandlerMessages()
    {
        Debug.LogError("OnRoomHandlesMessages");
        _room.OnMessage<string>("log", (message) =>
        {
            Debug.Log("[Server] "+ message);
        });
    }

    private void RoomHandlerCallbacks()
    {
        Debug.LogError("RoomHandlerCallbacks");
        _room.State.players.OnAdd += OnAddPlayer;
        _room.State.players.OnRemove += OnRemovePlayer;
    }

    void Update()
    {
        
    }

    private void OnAddPlayer(string sessionId, PlayerState player)
    {
        Debug.LogError("OnAddPlayer");

    }

    private void OnRemovePlayer(string sessionId, PlayerState player)
    {
        Debug.LogError("OnRemovePlayer");
    }
}
