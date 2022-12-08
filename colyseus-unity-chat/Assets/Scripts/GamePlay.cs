using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
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
        player.SetMessage(sessionId);
    }
}
