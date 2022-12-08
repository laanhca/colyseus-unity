using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerInputArea;
    [SerializeField] private Button sendMessageBtn;
    public Action<string> OnSendBtn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSendMessageBtnClick()
    {
        string mess = playerInputArea.text;
        playerInputArea.text = "";
        OnSendBtn.Invoke(mess);
    }
}
