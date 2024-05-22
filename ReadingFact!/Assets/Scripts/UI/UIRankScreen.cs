using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRankScreen : UIBase
{
    [SerializeField] private TMP_Text txtMyRank;
    [SerializeField] private TMP_Text[] txtTotalRank;
    [SerializeField] private TMP_Text[] txtImageRank;

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

        var rankInfo = UserManager.Instance.GetRanker(3);
        int count = 0;
        foreach(var info in rankInfo)
        {
            ++count;
            txtTotalRank[count - 1].SetText(string.Format("{0}. {1} - {2}", count, info.Name, info.Score));
            txtImageRank[count - 1].SetText(info.Name);
        }

        for(; count<3; ++count)
        {
            txtTotalRank[count - 1].SetText(string.Format("{0}.", count));
            txtImageRank[count - 1].text = string.Empty;
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
