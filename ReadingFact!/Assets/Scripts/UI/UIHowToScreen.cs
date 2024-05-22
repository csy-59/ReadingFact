using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHowToScreen : UIBase
{
    [SerializeField] private Button btnNext;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnNext, OnNext);
    }

    private void OnNext()
    {
        Close();
        UIManager.Instance.ShowPopup(Define.UI.UIFormMain, out var _);
    }
}
