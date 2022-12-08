using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private readonly Dictionary<string, Player> _players = new Dictionary<string, Player>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddPlayer(string sessionId, PlayerState playerSate)
    {
        Player player = Instantiate(playerPrefab, this.transform).GetComponent<Player>();
        player.transform.position = new Vector3(playerSate.x, playerSate.y);
        player.SetName(playerSate.name);
        player.SetMessage("Hello");
        
        _players.Add(sessionId, player);
        Debug.LogError("[Client] Add Player Complete");

    }
    public void RemovePlayer(string sessionId, PlayerState playerSate)
    {
        Player leftPlayer = _players[sessionId];
        if(leftPlayer) Destroy(leftPlayer.gameObject);
        _players.Remove(sessionId);
        Debug.LogError("[Client] Remove Player Complete");
    }
}
