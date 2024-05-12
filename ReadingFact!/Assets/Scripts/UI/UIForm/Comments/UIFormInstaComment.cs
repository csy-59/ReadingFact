using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFormInstaComment : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtId;
    [SerializeField] private TextMeshProUGUI txtContent;

    public void SetData(SDComment data)
    {
        txtId.SetText(data.NickName);
        txtContent.SetText(data.Content);
    }
}
