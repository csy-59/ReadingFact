using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISuccessScreen : UIBase
{
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtReason;
    [SerializeField] private Button btnNext;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnNext, Close);
    }

    public void Set(SDClue sdClue)
    {
        string[] reason = sdClue.Content.Split('\n');
        txtTitle.SetText(reason[0]);
        txtReason.SetText(reason[1]);
    }
}
