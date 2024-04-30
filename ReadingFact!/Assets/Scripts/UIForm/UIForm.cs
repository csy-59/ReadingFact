using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIForm : MonoBehaviour
{
    private bool isCorrect = false;

    public abstract bool SetData();

    public string AddLinkText()
    {
        return string.Empty;
    }
}
