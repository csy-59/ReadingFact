using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFormNews : UIBase
{
    [SerializeField] private TextMeshProUGUI txtURL;
    [SerializeField] private TextMeshProUGUI txtTitle;
    [SerializeField] private TextMeshProUGUI txtType;
    [SerializeField] private TextMeshProUGUI txtContext;
    private SDNews data;

    public void SetData(SDNews newsData)
    {
        data = newsData;

        txtURL.SetText(newsData.URL);
        txtTitle.SetText(newsData.Title);
        txtType.SetText(string.Format("<color=red>{0} : </color> {0} 일반", newsData.Type));
        txtContext.SetText(newsData.Content);
    }
}
