using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDManager : MonoSingleton<SDManager>
{
    public StaticDataList<SDShort> Short;
    public StaticDataList<SDInstar> Instar;
    public StaticDataList<SDComment> Comment;
    public StaticDataList<SDSearch> Search;
    public StaticDataList<SDThesis> Thesis;
    public StaticDataList<SDNews> News;
    public StaticDataList<SDLanding> Landing;
    public StaticDataList<SDClue> Clue;
    
    public override void Init()
    { 
        Short = JsonUtility.FromJson<StaticDataList<SDShort>>(GetJson("StaticData/Short"));
        Instar = JsonUtility.FromJson<StaticDataList<SDInstar>>(GetJson("StaticData/Instar"));
        Comment = JsonUtility.FromJson<StaticDataList<SDComment>>(GetJson("StaticData/Comment"));
        Search = JsonUtility.FromJson<StaticDataList<SDSearch>>(GetJson("StaticData/Search"));
        Thesis = JsonUtility.FromJson<StaticDataList<SDThesis>>(GetJson("StaticData/Thesis"));
        News = JsonUtility.FromJson<StaticDataList<SDNews>>(GetJson("StaticData/News"));
        Landing = JsonUtility.FromJson<StaticDataList<SDLanding>>(GetJson("StaticData/Landing"));
        Clue = JsonUtility.FromJson<StaticDataList<SDClue>>(GetJson("StaticData/Clue"));
    }

    private string GetJson(string path)
    {
        var text = Resources.Load<TextAsset>(path);
        return text.text;
    }
}
