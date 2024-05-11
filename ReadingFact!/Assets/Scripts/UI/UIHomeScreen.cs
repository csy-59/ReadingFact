using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;

public class UIHomeScreen : UIBase
{
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private Button btnStart;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnStart, OnClickStart);
    }

    public override void OnOpen()
    {
        
    }

    public override void OnClose()
    {
        
    }

    private void OnClickStart()
    {
        if (inputName.text == string.Empty) return;
        
        PlayerPrefs.SetString(Define.PlayerPrefs.Name, inputName.text);
        
        UIManager.Instance.ShowPopup(Define.UI.UIRankScreen, out var _);
    }
}
