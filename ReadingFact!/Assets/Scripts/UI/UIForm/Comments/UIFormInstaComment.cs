using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFormInstaComment : UIBase
{
    [SerializeField] private TextMeshProUGUI txtId;
    [SerializeField] private TextMeshProUGUI txtContent;
    private UIFormInstargram InstagramMain;

    public void SetData(SDComment data, UIFormInstargram main)
    {
        txtId.SetText(data.NickName);
        txtContent.SetText(data.Content);
        InstagramMain = main;
    }

    public override void OnTextClicked(TMP_LinkInfo info)
    {
        InstagramMain?.OnTextClicked(info);
    }
}
