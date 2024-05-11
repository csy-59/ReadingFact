using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI를 관리하는 매니저.
/// 원하는 UI의 인스턴스를 생성해서 화면에 출력한다.
/// 사용하지 않는 UI는 cacheCanvas에 캐싱한다.
/// </summary>
public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Canvas mainCanvas;
    [SerializeField] private Canvas cacheCanvas;
    
    public override void Init()
    {
        
    }

    /// <summary>
    /// 팝업을 출력한다.
    /// 경로에 맞는 팝업이 출력된다.
    /// </summary>
    public void ShowPopup(string path)
    {
        // 인스턴스화 하기
    }
}
