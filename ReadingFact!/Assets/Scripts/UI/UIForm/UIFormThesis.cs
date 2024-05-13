using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFormThesis : UIBase
{
    [SerializeField] private TextMeshProUGUI txtTitle;
    [SerializeField] private TextMeshProUGUI txtEngTitile;
    [SerializeField] private Image image;

    public void SetData(SDThesis thesisData)
    {
        txtTitle.SetText(thesisData.TitleKo);
        txtEngTitile.SetText(thesisData.TitleEn);
        image.sprite = Resources.Load<Sprite>(thesisData.ImagePath);
    }
}
