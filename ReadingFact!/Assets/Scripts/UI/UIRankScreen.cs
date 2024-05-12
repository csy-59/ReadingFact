using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRankScreen : UIBase
{
    [SerializeField] private TMP_Text txtMyRank;
    [SerializeField] private TMP_Text txtTotalRank;
    [SerializeField] private TMP_Text txtLastMyRank;

    [SerializeField] private Button btnHome;
    [SerializeField] private Button btnRetry;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnHome, OnClickHome);
        UIHelper.AddButtonEvent(btnRetry, OnClickRetry);
    }

    public override void OnOpen()
    {
        int myRank = UserManager.Instance.GetRank(UserManager.Instance.MyUserInfo.Name);
        txtMyRank.SetText(myRank.ToString());

        var rankInfo = UserManager.Instance.GetRanker(5);
        string rankingInfoString = string.Empty;
        int count = 0;
        foreach(var info in rankInfo)
        {
            ++count;
            rankingInfoString += string.Format("{0}. {1} - {2}\n", count, info.Name, info.Score);
        }
        txtTotalRank.SetText(rankingInfoString);

        if (myRank <= 5)
        {
            txtLastMyRank.gameObject.SetActive(false);
        }
        else
        {
            txtLastMyRank.gameObject.SetActive(true);
            txtLastMyRank.SetText(string.Format("{0}. {1}", myRank, UserManager.Instance.MyUserInfo.Name));
        }
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
