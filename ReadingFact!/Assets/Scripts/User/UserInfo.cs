using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 유저 한 명의 정보가 들어있는 클래스.
/// PlayerPrefs에 List형태로 저장되어야 하므로 Serializable로 한다. 
/// </summary>
[System.Serializable]
public class UserInfo
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int score;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Score
    {
        get => score;
        set => score = value;
    }
}
