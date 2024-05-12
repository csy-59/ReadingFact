using System;
using System.Collections.Generic;

/// <summary>
/// 쇼츠 데이터
/// </summary>
[Serializable]
public class SDShort : StaticDataBase
{
    /// <summary>
    /// 제목
    /// </summary>
    public string Title;
    /// <summary>
    /// 영상 에셋 경로
    /// </summary>
    public string VideoPath;
    /// <summary>
    /// 댓글 리스트
    /// </summary>
    public List<int> CommentList;
    /// <summary>
    /// 고정댓글 아이디
    /// </summary>
    public int FixedComment;
    /// <summary>
    /// 검색 아이디
    /// </summary>
    public int SearchID;
}
