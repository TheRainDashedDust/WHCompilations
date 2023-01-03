using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : Singleton<SceneManager>
{
    BaseScene mRuningScene;
    public BaseScene RuningScene { get { return mRuningScene; } set { mRuningScene = value; } }

    public void LoadScene<T>(params object[] mparams) where T : BaseScene, new()
    {
        if (mRuningScene != null)
        {
            mRuningScene.OnExit();
        }
        GameObject newObj = new GameObject(typeof(T).Name);
        mRuningScene = newObj.AddComponent<T>();
        mRuningScene.OnLoad(mparams);
    }
}
