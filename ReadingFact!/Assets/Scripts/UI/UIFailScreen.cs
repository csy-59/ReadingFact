using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFailScreen : UIBase
{
    [SerializeField] private TMP_Text txtReason;
    [SerializeField] private Button btnNext;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnNext, Close);
    }

    public void Set(SDClue sdClue)
    {
        txtReason.text = sdClue.Content;
    }
}
