/********************************************************************************
 *	文件名：	SkillCore.cs
 *	全路径：	\Script\GameManager\SkillCore.cs
 *	创建人：	罗勇
 *	创建时间：2013-11-06
 *
 *	功能说明：客户端技能逻辑核心，负责客户端技能逻辑处理
 *	修改记录：
*********************************************************************************/
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngineInternal;
using Unity.VisualScripting;


public class SkillCore
{
    private class BulletData
    {
        public BulletData(int selfID, int targetID)
        {
            _selfID = selfID;
            _targetID = targetID;
        }

        public int _selfID;
        public int _targetID;
    }
    public SkillCore()
    { 
    }

    //检查技能是否结束
    public void CheckSkillShouldFinish()
    {

    }
    //使用技能
    public void UseSkill(int skillId, int senderId, int targetId, string skillname = "")
    {

    }
    //是否能够显示技能进度
    bool CanShowSkillProgress()
    {
        return false;
    }

    //加载子弹
    void OnLoadBullet(GameObject bulletEffect, object param)
    {

    }

    //播放动画
    void PlayAnimation(int AnimationId)
    {

    }

    //打断当前的技能
    public void BreakCurSkill()
    {
    }

    //技能结束
    public void SkillFinsh() { }

    //控制摄像头 createInstance
    void CameraOpt() { }

    //显示技能名字
    public static void ShowSkillName(int skillId, int senderId, string skillName = "") { }
}

