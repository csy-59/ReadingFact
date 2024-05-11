using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormData
{
    public enum FormType
    {
        FORM_INSTAR,
        FORM_SHORT,
        FORM_NEWS,
        FORM_WEBSEARCH,
        FORM_DOCUMENT,
        FORM_MAX
    }

    public int Index { get; set; }
    public FormType Type { get; set; }
}
