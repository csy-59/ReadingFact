using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private int QuizCount = 0;
    private const int QuizeMaxCount = 5;

    private bool[] HasQuized;

    public override void Init()
    {

    }

    public void StartGame()
    {
        if(HasQuized == null)
        {
            HasQuized = new bool[SDManager.Instance.Landing.dataList.Count];
        }

        int totalQuizCount = HasQuized.Length;
        for (int i = 0; i < totalQuizCount; ++i)
        {
            HasQuized[i] = false;
        }

        QuizCount = QuizeMaxCount;
        UserManager.Instance.MyUserInfo.Score = 0;
    }

    public void EndGame()
    {
        UserManager.Instance.SetScore(UserManager.Instance.MyUserInfo.Name, UserManager.Instance.MyUserInfo.Score);
        UIManager.Instance.ShowPopup(Define.UI.UIScoreScreen, out var _);
    }

    public void OnAddScore(int addScore)
    {
        UserManager.Instance.MyUserInfo.Score += addScore;
    }
    
    public int GetNextQuiz()
    {
        QuizCount -= 1;
        if(QuizCount < 0)
        {
            return -1;
        }

        bool moreQuiz = false;
        foreach(var isQuized in HasQuized)
        {
            if (isQuized == false)
            {
                moreQuiz = true;
                break;
            }
        }

        if (moreQuiz == false)
        {
            return -1;
        }

        int totalQuizCount = HasQuized.Length;
        int index = 0;
        do
        {
            index = Random.Range(0, totalQuizCount);
        } while (HasQuized[index] == true);
        HasQuized[index] = true;

        return index;
    }
}
