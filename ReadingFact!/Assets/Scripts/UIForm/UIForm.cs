using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIForm : MonoBehaviour
{
    private bool isCorrect = false;

    public abstract bool SetData();

    private string AddLinkText(string text, string addText, string linkID)
    {
        return text + "<link=\"" + linkID + "\">" + addText + "</link>";
    }
}
