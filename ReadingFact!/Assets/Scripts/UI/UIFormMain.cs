using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFormMain : UIBase
{
    [SerializeField] private Button btnTrue;
    [SerializeField] private Button btnFalse;
    [SerializeField] private Button btnSearch;
    [SerializeField] private Button btnBack;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnTrue, OnClickTrue);
        UIHelper.AddButtonEvent(btnTrue, OnClickFalse);
        UIHelper.AddButtonEvent(btnBack, Close);
    }

    private void OnClickTrue()
    {
        
    }

    private void OnClickFalse()
    {
        
    }
}
