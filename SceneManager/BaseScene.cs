using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    public virtual void OnLoad(params object[] mparam) { }
    public virtual void OnExit() { Destroy(gameObject); }
}
