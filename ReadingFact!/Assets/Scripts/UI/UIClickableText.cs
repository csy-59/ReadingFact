using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIClickableText : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI text;
    [SerializeField]
    private UIBase _onClickHandler;
    public UIBase OnClickHandler { get => _onClickHandler; set => _onClickHandler = value; }

    public void Start()
    {
        text = this.GetComponent<TextMeshProUGUI>();
        if (text == null)
            this.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, Input.mousePosition, null);
        if (linkIndex == -1)
            return;
        else
            OnClickHandler.OnTextClicked(text.textInfo.linkInfo[linkIndex]);
    }
}
