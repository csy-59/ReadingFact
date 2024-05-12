using System;

/// <summary>
/// 논문 데이터
/// </summary>
[Serializable]
public class SDThesis : StaticDataBase
{
    /// <summary>
    /// 한글 제목
    /// </summary>
    public string TitleKo;
    /// <summary>
    /// 영어 제목
    /// </summary>
    public string TitleEn;
    /// <summary>
    /// 이미지 에셋 경로
    /// </summary>
    public string ImagePath;
}
