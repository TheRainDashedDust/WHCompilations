using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerBase<T> : MonoBehaviour
{
    public GameObject[] childWindows;

    private static T _Instance;

    // ��ȷ�������Ƿ����ʱ��Ҫ�п�
    public static T Instance()
    {
        return _Instance;
    }

    public static void SetInstance(T instance)
    {
        _Instance = instance;
    }

    // ���������OnDestroy��Ҫ��_Instance�ÿգ���ֹ��Դ�޷��ͷ�
    void OnDestroy()
    {
        Release();
    }

    void Release()
    {
        _Instance = default(T);
    }

    public void SwitchWindow(int index)
    {
        if (null == childWindows)
        {
           /// LogModule.WarningLog("child window is not set");
            return;
        }

        if (index >= childWindows.Length)
        {
            ///LogModule.WarningLog("child window index out range :" + index.ToString() + " " + childWindows.Length.ToString());
            return;
        }

        for (int i = 0; i < childWindows.Length; i++)
        {
            childWindows[i].SetActive(i == index);
        }
    }
}
