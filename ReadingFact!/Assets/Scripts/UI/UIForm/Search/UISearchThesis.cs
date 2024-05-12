using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISearchThesis : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtTitle;
    [SerializeField] private Image image;
    [SerializeField] private Button button;
    UIFormMain main;

    public void SetData(SDThesis data, UIFormMain main)
    {
        txtTitle.SetText(data.TitleKo);
        image = Resources.Load<Image>(data.ImagePath);

        button.onClick.AddListener(() => { main.OpenForm(data.ID); });
    }
}
