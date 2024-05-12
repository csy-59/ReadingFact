using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 데이터 리스트.
/// 여러개의 StaticData가 들어있는 리스트
/// </summary>
public class StaticDataList<T> where T : StaticDataBase
{
    public List<T> dataList;
}
