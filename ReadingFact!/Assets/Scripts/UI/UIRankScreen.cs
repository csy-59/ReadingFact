using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRankScreen : UIBase
{
    [SerializeField] private TMP_Text txtMyRank;

    [SerializeField] private Button btnHome;
    [SerializeField] private Button btnRetry;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnHome, OnClickHome);
        UIHelper.AddButtonEvent(btnRetry, OnClickRetry);
    }

    public override void OnOpen()
    {
        
    }

    private void OnClickHome()
    {
        Close();
    }

    private void OnClickRetry()
    {
        Close();
        GameManager.Instance.StartGame();
        UIManager.Instance.ShowPopup(Define.UI.UIFormMain, out var _);
    }
}
