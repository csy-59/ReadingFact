using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 고정데이터 베이스
/// 이 부분은 JSON으로 전환되었다가 파싱되기를 반복해야 하므로, 용이하기위해 public 변수를 사용한다.
/// 이 값은 변경되어서는 안된다.
/// </summary>
[Serializable]
public class StaticDataBase
{
    /// <summary>
    /// 고유한 아이디
    /// 1~50            인스타
    /// 51 ~ 100        쇼츠
    /// 101 ~ 200       검색
    /// 201 ~ 300       뉴스
    /// 301 ~ 400       논문
    /// </summary>
    public int ID;
}
