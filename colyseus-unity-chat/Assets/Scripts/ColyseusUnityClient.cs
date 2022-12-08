using System.Collections.Generic;
using Colyseus;
using Colyseus.Schema;
using UnityEngine;

public class ColyseusUnityClient : MonoBehaviour
{
    private ColyseusClient _unityClient;
    private ColyseusRoom<State> _room;
    private GamePlay _gamePlay;
    private UI _gameUI;
    
    
    void Start()
    {
       
        _gamePlay = GameObject.Find("GamePlay").GetComponent<GamePlay>();
        _gameUI = GameObject.Find("UI").GetComponent<UI>();
        _gameUI.OnSendBtn += OnPlayerSendMess;
        ConnectToGameServer();
    }

    private void OnPlayerSendMess(string mess)
    {
        _room.Send("chat", mess);
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
        // _room.State.players.OnChange += OnChangePlayer;
        _room.State.players.OnRemove += OnRemovePlayer;
    }



    void Update()
    {
        
    }

    private void OnAddPlayer(string sessionId, PlayerState playerState)
    {
        Debug.LogError("OnAddPlayer with sessionId: "+ sessionId);
        _gamePlay.AddPlayer(sessionId, playerState);
        
        //add change callback
        playerState.OnChange += (List<DataChange> changes)=>OnChangePlayer(changes, sessionId);

    }

    private void OnChangePlayer(List<DataChange> changes, string sessionId)
    {
        foreach (var change in changes)
        {
            if (change.Field == "message")
            {
                _gamePlay.OnPlayerSendMessage(sessionId, (string)change.Value);
            }
        }
    }

    private void OnRemovePlayer(string sessionId, PlayerState playerSate)
    {
        Debug.LogError("OnRemovePlayer with sessionId: "+ sessionId);
        _gamePlay.RemovePlayer(sessionId, playerSate);
    }
}
