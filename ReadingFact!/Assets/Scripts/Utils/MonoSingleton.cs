using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MonoBehaviour를 상속받은 싱글톤.
/// OnInit이라는 초기화 함수를 제공한다.
/// Start는 이미 사용중이므로 사용해서는 안된다.
/// </summary>
public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    private bool isInit;

    public static T Instance
    {
        get
        {
            if (instance != null) return instance;

            instance = FindObjectOfType<T>();

            if (instance != null) return instance;

            instance = new GameObject(nameof(T)).AddComponent<T>();

            return instance;
        }
    }

    private void Start()
    {
        if (isInit)
        {
            // 이미 초기화가 이루어졌는데 들어왔다면, 두 개의 인스턴스가 있다는 의미이므로 제거한다.
            Destroy(gameObject);
            return;
        }

        isInit = true;
        
        Init();
    }

    /// <summary>
    /// 생성 시 최초 1회 호출되는 초기화 함수.
    /// </summary>
    public abstract void Init();
}
