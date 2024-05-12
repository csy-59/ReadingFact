using System;

/// <summary>
/// 뉴스 데이터
/// </summary>
[Serializable]
public class SDNews : StaticDataBase
{
    /// <summary>
    /// 제목
    /// </summary>
    public string Title;
    /// <summary>
    /// 내용
    /// </summary>
    public string Content;
    /// <summary>
    /// 분류
    /// </summary>
    public string Type;
    /// <summary>
    /// 상단에 뜰 URL
    /// </summary>
    public string URL;
}
