using System.Collections;
using System.Collections.Generic;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class UIHelper
{
    /// <summary>
    /// UGUI Button에 이벤트를 추가한다. 에디터의경우 Inspector창에서 보일 수 있게끔 추가하기 위해 따로 함수화 했다.
    /// 중복 추가를 막기 위해 한번 리스너를 제거한 뒤에 추가한다.
    /// </summary>
    public static void AddButtonEvent(Button btn, UnityAction action)
    {
        #if UNITY_EDITOR
        UnityEventTools.RemovePersistentListener(btn.onClick, action);
        UnityEventTools.AddPersistentListener(btn.onClick, action);
        #else
        btn.onClick.RemoveListener(action);
        btn.onClick.AddListener(action);
        #endif
    }
}
