using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoLandingData
{
    public SDLanding SDLanding { get; private set; }
    
    public BoLandingData(SDLanding data)
    {
        SDLanding = data;
    }

    /// <summary>
    /// 결과를 보여준다.
    /// 정답이면 정답 페이지로, 오답이면 오답 페이지로 이동시킨다.
    /// </summary>
    public void ShowResult(bool answer)
    {
        // 정답 여부
        bool isCorrect = answer == SDLanding.Correct;

        if (isCorrect)
        {
            UIManager.Instance.ShowPopup(Define.UI.UISuccessScreen, out var _);
        }
        else
        {
            UIManager.Instance.ShowPopup(Define.UI.UIFailScreen, out var _);
        }
    }
}
