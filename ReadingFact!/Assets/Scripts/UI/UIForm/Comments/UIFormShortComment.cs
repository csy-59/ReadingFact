using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFormShortComment : UIBase
{
    [SerializeField] private TextMeshProUGUI txtId;
    [SerializeField] private TextMeshProUGUI txtContent;
    private UIFormShorts ShortMain;

    public void SetData(SDComment data, UIFormShorts main)
    {
        txtId?.SetText(data.NickName);
        txtContent.SetText(data.Content);
        ShortMain = main;
    }

    public override void OnTextClicked(TMP_LinkInfo info)
    {
        ShortMain?.OnTextClicked(info);
    }
}
