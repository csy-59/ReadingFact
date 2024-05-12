using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHowToScreen : UIBase
{
    [SerializeField] private Button btnBack;

    private void Start()
    {
        UIHelper.AddButtonEvent(btnBack, Close);
    }
}
