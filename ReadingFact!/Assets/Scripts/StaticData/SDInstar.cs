using System;
using System.Collections.Generic;

/// <summary>
/// 인스타 데이터
/// </summary>
[Serializable]
public class SDInstar : StaticDataBase
{
    /// <summary>
    /// 내용
    /// </summary>
    public string Content;
    /// <summary>
    /// 댓글 리스트
    /// </summary>
    public List<int> CommentList;
    /// <summary>
    /// 검색 아이디
    /// </summary>
    public int SearchID;
}
