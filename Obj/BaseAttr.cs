/********************************************************************************
 *	功能说明：Obj基础战斗属性，以及基础属性换算公式
*********************************************************************************/
using UnityEngine;
using System.Collections;
using System;

public enum SKILLDELANDGAINTYPE //技能的消耗和收益
{
   
    HPTYPE_VALUE = 101,//血值
    HPTYPE_RATE = 102,//血百分百
    MPTYPE_VALUE = 201,//蓝值
    MPTYPE_RATE = 202,//蓝百分百
    XPTYPE_VALUE = 301,//战意值
    XPTYPE_RATE = 302,//战意百分百
    COINTYPE = 401,//金币
}
public enum COMBATATTE
{
    MAXHP = 0,     //血上限
    MAXMP = 1,     //蓝上限
    MAXXP = 2,     //战意上限
    PYSATTACK = 3,     //物理攻击
    MAGATTACK = 4,     //魔法攻击
    PYSDEF = 5,     //物理防御
    MAGDEF = 6,     //魔法防御
    HIT = 7,     //命中
    DODGE = 8,     //闪避
    CRITICAL = 9,     //暴击
    DECRITICAL = 10,    //暴抗
    STRIKE = 11,    //穿透
    DUCTICAL = 12,    //韧性
    CRITIADD = 13,    //暴击伤害加成
    CRITIMIS = 14,    //暴击伤害减免
    MOVESPEED = 15,    //移动速度
    ATTACKSPEED = 16,    //攻击速度
    COMBATATTE_MAXNUM,
}

public enum MIXBATATTR
{
    MIXATTR_BEGIN = 999,
    MIXATTR_ALLATTACK = 1000,
    MIXATTR_ALLDEF = 1001,
}

public class MaxBatAttrUtil
{
    public static bool IsContainType(MIXBATATTR nMixType, COMBATATTE nJudgeAttrType)
    {
        switch (nMixType)
        {
            case MIXBATATTR.MIXATTR_ALLDEF:
                {
                    if (nJudgeAttrType == COMBATATTE.PYSDEF || nJudgeAttrType == COMBATATTE.MAGDEF)
                    {
                        return true;
                    }
                }
                break;
            case MIXBATATTR.MIXATTR_ALLATTACK:
                {
                    if (nJudgeAttrType == COMBATATTE.PYSATTACK || nJudgeAttrType == COMBATATTE.MAGATTACK)
                    {
                        return true;
                    }
                }
                break;
            default:
                break;
        }
        return false;
    }
}

public class BaseAttr
{
    //生命值
    private int m_nHP = 0;
    public int HP
    {
        get { return m_nHP; }
        set { m_nHP = value; }
    }
    private int m_nMaxHP = 0;
    public int MaxHP
    {
        get { return m_nMaxHP; }
        set { m_nMaxHP = value; }
    }
    //法力值
    private int m_nMp = 0;
    public int MP
    {
        get { return m_nMp; }
        set { m_nMp = value; }
    }

    private int m_nMaxMp = 0;
    public int MaxMP
    {
        get { return m_nMaxMp; }
        set { m_nMaxMp = value; }
    }
    //战意
    private int m_nXp = 0;
    public int XP
    {
        get { return m_nXp; }
        set { m_nXp = value; }
    }

    private int m_nMaxXp = 0;
    public int MaxXP
    {
        get { return m_nMaxXp; }
        set { m_nMaxXp = value; }
    }

    public int Exp { set; get; }
    //名字
    private string m_RoleName = "";
    public string RoleName
    {
        get { return m_RoleName; }
        set { m_RoleName = value; }
    }

    //等级
    private int m_nLevel = 0;
    public int Level
    {
        get { return m_nLevel; }
        set { m_nLevel = value; }
    }

    // 头像
    private string m_strHeadPic = "";
    public string HeadPic
    {
        get { return m_strHeadPic; }
        set { m_strHeadPic = value; }
    }

    //数据表ID,既RoleBase中的ID
    private int m_nRoleBaseID = -1;
    public int RoleBaseID
    {
        get { return m_nRoleBaseID; }
        set { m_nRoleBaseID = value; }
    }

    private int m_nForce = -1;
    public int Force
    {
        get { return m_nForce; }
        set { m_nForce = value; }
    }

    private float m_fMoveSpeed = 5.0f;
    public float MoveSpeed
    {
        get { return m_fMoveSpeed; }
        set { m_fMoveSpeed = value; }
    }

    //死亡状态
    private bool m_bDie = false;
    public bool Die
    {
        get { return m_bDie; }
        set { m_bDie = value; }
    }

    //朝向
    private float m_fDirection = 0.0f;
    public float Direction
    {
        get { return m_fDirection; }
        set { m_fDirection = value; }
    }

    //战斗力
    private int m_nCombatValue = 0;
    public int CombatValue
    {
        get { return m_nCombatValue; }
        set { m_nCombatValue = value; }
    }
    //体能
    private int m_nCurStamina = 0;
    public int CurStamina
    {
        get { return m_nCurStamina; }
        set { m_nCurStamina = value; }
    }
    private int m_nOffLineExp = 0;
    public int OffLineExp
    {
        get { return m_nOffLineExp; }
        set { m_nOffLineExp = value; }
    }

}
