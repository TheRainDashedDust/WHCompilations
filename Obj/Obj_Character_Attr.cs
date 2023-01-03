/********************************************************************************
 *	功能说明：游戏逻辑Obj_Character类的属性相关部分
*********************************************************************************/

using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;


public partial class Obj_Character : Obj
{
    protected BaseAttr m_BaseAttr;
    public virtual BaseAttr BaseAttr
    {
        get { return m_BaseAttr; }
        set { m_BaseAttr = value; }
    }

    public virtual void OptHPChange() //血量变化后的操作
    {
    }
    ///
    public virtual void OptMPChange()//法力变化后的操作
    {
    }
    public virtual void OptXPChange()//XP变化后的操作
    {
    }

    public virtual void OptLevelChange()//等级变化后的操作
    {
    }

    public virtual void OptHeadPicChange()//头像变化后的操作
    {
    }

    public virtual void OptNameChange()//名字变化后的操作
    {
    }

    public virtual void OptForceChange()//势力变化后的操作
    {
            
    }

    public virtual void OptStealthLevChange() //隐身级别变化后的操作
    {
           
    }

    public virtual void OptOutLineChange() //隐身级别变化后的操作
    {
            
    }
    public virtual void OnExpChange()   // 经验变化后的操作
    {
    }
    public virtual void UpdateAttrBroadcastPackt()
    {

    }
}

