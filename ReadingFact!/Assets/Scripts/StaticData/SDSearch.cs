using System;
using System.Collections.Generic;

/// <summary>
/// 검색 데이터
/// </summary>
[Serializable]
public class SDSearch : StaticDataBase
{
    /// <summary>
    /// 검색한 내용
    /// </summary>
    public string SearchContent;
    /// <summary>
    /// 댓글 리스트
    /// </summary>
    public List<int> CommentList;
}
