using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISearchNews : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtTitle;
    [SerializeField] private TextMeshProUGUI txtContent;
    [SerializeField] private Button button;
    UIFormMain main;

    public void SetData(SDNews data, UIFormMain main)
    {
        txtTitle.SetText(data.Title);
        txtContent.SetText(data.Content);

        button.onClick.AddListener(() => { main.OpenForm(data.ID); });
    }
}
