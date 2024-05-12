using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// 모든 UI의 기본이 될 클래스
/// 인스턴스 되는 시점과 삭제되는 시점을 체크할 수 있다.
/// </summary>
public abstract class UIBase : MonoBehaviour
{
    /// <summary>
    /// 팝업이 열리고 난 후에 호출되는 함수
    /// </summary>
    public virtual void OnOpen()
    {
        
    }

    /// <summary>
    /// 팝업이 닫히기 전에 호출되는 함수
    /// </summary>
    public virtual void OnClose()
    {
        
    }

    /// <summary>
    /// 자식 팝업이 닫힌경우 호출된다. 
    /// </summary>
    public virtual void OnChildClosed()
    {
        
    }

    public virtual void OnTextClicked(TMP_LinkInfo info)
    {

    }
    
    /// <summary>
    /// 팝업을 닫는 함수
    /// </summary>
    public void Close()
    {
        UIManager.Instance.Close();
    }
}
