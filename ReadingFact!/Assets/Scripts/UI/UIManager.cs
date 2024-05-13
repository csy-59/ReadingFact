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
    /// <summary>
    /// 실제로 화면에 출력할 UI가 존재할 캔버스
    /// </summary>
    [SerializeField] private Canvas mainCanvas;
    /// <summary>
    /// 사용이 끝난 UI를 캐싱할 캔버스.
    /// </summary>
    [SerializeField] private Canvas cacheCanvas;

    /// <summary>
    /// 실제로 화면에 출력할 UI의 부모 트랜스폼
    /// </summary>
    [SerializeField] private RectTransform safeArea;

    /// <summary>
    /// cacheCanvas하위에 있는 UI
    /// </summary>
    private Dictionary<string, UIBase> cachedUI;

    /// <summary>
    /// UI가 쌓여있는 스택.
    /// 현재 UI를 보여주다가 돌아가기 버튼이나 닫기 버튼이 눌리면 이전 UI로 돌아가야 하므로, 스택 형식으로 표현한다.
    /// </summary>
    private Stack<UIBase> uiStack;
    
    public override void Init()
    {
        cachedUI = new Dictionary<string, UIBase>();
        uiStack = new Stack<UIBase>();
        
        // 최초로 실행되어야 하는 UI인 HomeScreen을 출력한다.
        ShowPopup(Define.UI.UIHomeScreen, out var _);
        
        var setWidth = 720;
        var setHeight = 1280;

        var deviceWidth = Screen.width; // 기기 너비 저장
        var deviceHeight = Screen.height; // 기기 높이 저장

        var setRatio = (float)setWidth / setHeight;
        var deviceRatio = (float)deviceWidth / deviceHeight;
        
        Screen.SetResolution((int)(deviceRatio * setWidth), setHeight, true); // SetResolution 함수 제대로 사용하기

        if (setRatio < deviceRatio) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = setRatio / deviceRatio; // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = deviceRatio / setRatio; // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }

    /// <summary>
    /// 팝업을 생성해서 화면에 출력한다.
    /// 이미 인스턴스를 캐싱해두었다면, 캐싱된 UI를 출력한다.
    /// </summary>
    public void ShowPopup(string path, out UIBase ui)
    {
        if (TryGetCachedUI(path, out var cachedUI))
        {
            ui = cachedUI;
        }
        else
        {
            var prefab = Resources.Load<UIBase>(path);
            ui = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        }

        // 가장 상위에 있는 UI의 액티브를 끄고 캐시 캔버스로 옮긴다.
        if (uiStack.TryPeek(out var topUI))
        {
            // 액티브를 미리 끄고 부모를 옮겨야 추가 연산이 없다.
            topUI.gameObject.SetActive(false);
            topUI.transform.SetParent(cacheCanvas.transform);
        }
        
        uiStack.Push(ui);
        ui.transform.SetParent(safeArea, false);
        ui.gameObject.SetActive(true);
        ui.OnOpen();
    }

    /// <summary>
    /// 가장 상단에 있는 UI를 종료한다.
    /// </summary>
    public void Close()
    {
        var topUI = uiStack.Peek();
        uiStack.Pop();
        topUI.OnClose();
        topUI.gameObject.SetActive(false);
        topUI.transform.SetParent(cacheCanvas.transform);
        
        topUI = uiStack.Peek();
        // 자식 팝업이 닫혔으므로 콜백을 보낸다.
        topUI.OnChildClosed();
        topUI.transform.SetParent(safeArea, false);
        topUI.gameObject.SetActive(true);
    }

    /// <summary>
    /// 입력된 경로의 UI의 인스턴스가 이미 캐싱되어있는지 확인한다.
    /// 캐싱되어있다면 반환하고, 그렇지 않다면 null을 반환한다.
    /// </summary>
    private bool TryGetCachedUI(string path, out UIBase ui)
    {
        if (cachedUI.ContainsKey(path) == false)
        {
            ui = null;
            return false;
        }

        ui = cachedUI[path];

        return true;
    }
}
