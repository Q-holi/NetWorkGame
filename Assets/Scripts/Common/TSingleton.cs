using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSingleton<T> : MonoBehaviour where T : TSingleton<T>
{
    protected static volatile T _uniqueInstance = null;
    protected static volatile GameObject _uniqueObject = null;

    // ����� ���� ���� ��Ȳ������ ���� ���ϰ� �ϱ� ���� protected�� �����ڸ� ����
    protected TSingleton()
    {
    }

    public static T I
    {
        get
        {
            if (_uniqueInstance == null)
            {
                // ���� �����忡�� ���� ������ ���� ���� lock Ű���带 ���. ������ �߻��� �ؼ� �ϱ� ���� ���
                lock (typeof(T))
                {
                    // _uniqueObject�� null�ΰ��� Ȯ���� �غ�����
                    if (_uniqueInstance == null && _uniqueObject == null)
                    {
                        _uniqueObject = new GameObject(typeof(T).Name, typeof(T));
                        _uniqueInstance = _uniqueObject.GetComponent<T>();
                        _uniqueInstance.Init();
                    }
                }
            }

            return _uniqueInstance;
        }
    }

    protected virtual void Init()
    {
        DontDestroyOnLoad(gameObject);
    }
    public virtual void OnSceneAwake()
    {

    }
}
