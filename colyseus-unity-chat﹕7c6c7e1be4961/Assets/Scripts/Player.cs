using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private TextMeshPro playerName; 
    [SerializeField] private TextMeshPro playerMess; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        playerName.text = name;
    }
    public void SetMessage(string message)
    {
        playerMess.text = message;
    }
}
