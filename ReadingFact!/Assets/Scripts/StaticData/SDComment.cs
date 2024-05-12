using System;

/// <summary>
/// 댓글 데이터
/// </summary>
[Serializable]
public class SDComment : StaticDataBase
{
    /// <summary>
    /// 닉네임
    /// </summary>
    public string NickName;
    /// <summary>
    /// 내용
    /// </summary>
    public string Content;
}
