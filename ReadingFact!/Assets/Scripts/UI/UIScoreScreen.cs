using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScoreScreen : UIBase
{
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private Button btnNext;

    public void Start()
    {
        UIHelper.AddButtonEvent(btnNext, OnClickNext);
    }
    public override void OnOpen()
    {
        base.OnOpen();

        txtScore.SetText(UserManager.Instance.MyUserInfo.Score.ToString());
    }

    public void OnClickNext()
    {
        Close();
        UIManager.Instance.ShowPopup(Define.UI.UIRankScreen, out var _);
    }
}
