using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif
using UnityEngine;
using UnityEngine.UI;

public class UIHomeScreen : UIBase
{
    /// <summary> 유저가 입력받는 닉네임 </summary>
    [SerializeField] private TMP_InputField inputName;
    /// <summary> 중복 닉네임 경고 </summary>
    [SerializeField] private GameObject goSameNameWarning;
    /// <summary> 시작 버튼 </summary>
    [SerializeField] private Button btnStart;
    /// <summary> 강제 시작 버튼 </summary>
    [SerializeField] private Button btnForceStart;
    /// <summary> 랭킹 버튼 </summary>
    [SerializeField] private Button btnRank;
    /// <summary> 방법 버튼 </summary>
    [SerializeField] private Button btnHowTo;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnForceStart, OnClickForceStart);
        UIHelper.AddButtonEvent(btnStart, OnClickStart);
        UIHelper.AddButtonEvent(btnRank, OnClickRank);
        UIHelper.AddButtonEvent(btnHowTo, OnClickHowTo);
    }

    public override void OnOpen()
    {
        Init();
    }

    public override void OnChildClosed()
    {
        Init();
    }

    private void Init()
    {
        goSameNameWarning.SetActive(false);   
    }

    private void OnClickForceStart()
    {
        UserManager.Instance.AddUser("A");


        GameManager.Instance.StartGame();
        UIManager.Instance.ShowPopup(Define.UI.UIFormMain, out var _);
    }

    private void OnClickStart()
    {
        if (inputName.text == string.Empty) return;

        var name = inputName.text;

        // 이미 닉네임이 존재한다면 경고를 띄운다. 
        if (UserManager.Instance.IsUserExist(name))
        {
            goSameNameWarning.SetActive(true);
            return;
        }
        
        UserManager.Instance.AddUser(name);

        GameManager.Instance.StartGame();
        UIManager.Instance.ShowPopup(Define.UI.UIFormMain, out var _);
    }

    private void OnClickRank()
    {
        UIManager.Instance.ShowPopup(Define.UI.UIRankingScreen, out var _);
    }
    
    private void OnClickHowTo()
    {
        UIManager.Instance.ShowPopup(Define.UI.UIHowToScreen, out var _);
    }
}
