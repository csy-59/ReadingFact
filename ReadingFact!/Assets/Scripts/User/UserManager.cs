using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

/// <summary>
/// 유저의 모든 정보를 관리하는 매니저.
/// </summary>
public class UserManager : MonoSingleton<UserManager>
{
    private List<UserInfo> userInfos;
    
    public override void Init()
    {
        // Json형태로 저장된 유저 데이터를 가져온다.
        var json = PlayerPrefs.GetString(Define.DefinePrefs.USER_INFO,"{}");
        // json을 파싱하여 유저 정보로 세팅한다. 
        userInfos = JsonUtility.FromJson<List<UserInfo>>(json);
        
        AddUser("A");
        AddUser("B");
        AddUser("C");
        AddUser("D");
        
        SetScore("A", 10);
        SetScore("B", 20);
        SetScore("C", 50);
        SetScore("D", 100);
    }

    public bool IsUserExist(string name)
    {
        return PlayerPrefs.HasKey(name);
    }

    public void AddUser(string name)
    {
        var newUser = new UserInfo();
        newUser.Name = name;
        userInfos.Add(newUser);

        var json = JsonUtility.ToJson(userInfos);
        PlayerPrefs.SetString(Define.DefinePrefs.USER_INFO, json);
        SetScore(name, 0);
    }

    public void SetScore(string name, int score)
    {
        var user = userInfos.Find(_ => _.Name == name);
        if (user == null) return;

        user.Score = score;
        PlayerPrefs.SetInt(name, score);
    }

    public int GetScore(string name)
    {
        var user = userInfos.Find(_ => _.Name == name);
        if (user == null) return 0;

        return user.Score;
    }

    /// <summary>
    /// count만큼의 랭커를 반환한다.
    /// 점수가 높은 순서대로 리스트에 들어있다.
    /// </summary>
    public List<UserInfo> GetRanker(int count)
    {
        var result = userInfos.OrderByDescending(_ => _.Score).ToList();
        if (result.Count > count)
        {
            result.RemoveRange(count, result.Count - count);
        }

        return result;
    }
}