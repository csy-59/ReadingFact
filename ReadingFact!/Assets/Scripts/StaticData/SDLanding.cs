using System;

/// <summary>
/// 랜딩 데이터
/// </summary>
[Serializable]
public class SDLanding : StaticDataBase
{
    /// <summary>
    /// 정답 여부
    /// </summary>
    public bool Correct;
    /// <summary>
    /// 단서 아이디
    /// </summary>
    public int ClueID;
    /// <summary>
    /// 사유 아이디
    /// </summary>
    public int ReasonID;
}
