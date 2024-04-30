using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class UIFormManager : MonoBehaviour
{
    [SerializeField]
    private UIForm[] uiForms;

    private void Awake()
    {
        foreach (UIForm form in uiForms)
        {

        }
    }
}

