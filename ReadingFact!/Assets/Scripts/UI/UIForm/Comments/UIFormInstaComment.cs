using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFormInstaComment : UIBase
{
    [SerializeField] private TextMeshProUGUI txtContent;
    private UIFormInstargram InstagramMain;

    public void SetData(SDComment data, UIFormInstargram main)
    {
        txtContent.SetText(string.Format("<b><color=black>{0}</color></b> {1}", data.NickName, data.Content));
        InstagramMain = main;
    }

    public override void OnTextClicked(TMP_LinkInfo info)
    {
        InstagramMain?.OnTextClicked(info);
    }
}
