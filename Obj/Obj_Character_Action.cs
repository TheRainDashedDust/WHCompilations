/********************************************************************************
*	功能说明：游戏逻辑Obj_Character类的移动相关部分

*********************************************************************************/

using System.Security.Permissions;

using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine.AI;
using UnityEngine.Diagnostics;


public partial class Obj_Character : Obj
{

    #region Obj移动相关
    //obj的移动速度,无NavAgent时使用
    public float m_fMoveSpeed = 5.0f;

    //是否在移动中
    private bool m_bIsMoving;
    public bool IsMoving
    {
        get { return m_bIsMoving; }
        set
        {
            m_bIsMoving = value;
        }
    }

    private bool m_bIsTracing = false;//是否在追踪
    public bool IsTracing
    {
        get { return m_bIsTracing; }
        set { m_bIsTracing = value; }
    }

    //移动的目标点
    private Vector3 m_vecTargetPos;
    public Vector3 VecTargetPos
    {
        get { return m_vecTargetPos; }
        set
        {
            m_vecTargetPos = value;
            m_bIsMoving = true;
        }
    }

    //寻路代理
    private NavMeshAgent m_NavAgent = null;
    public NavMeshAgent NavAgent
    {
        get { return m_NavAgent; }
        set { m_NavAgent = value; }
    }

    //初始化寻路代理
    public void InitNavAgent()
    {
        if (NavAgent == null)
        {
            NavAgent = gameObject.AddComponent<NavMeshAgent>();
        }
        //NavAgent = gameObject.GetComponent<NavMeshAgent>();

        //初始化自动寻路
        if (null != NavAgent && 0 != gameObject.transform.localScale.x)
        {
            NavAgent.enabled = true;
            //设置成0，否则gameobject之间会互相碰撞
            NavAgent.speed = BaseAttr.MoveSpeed;
            NavAgent.radius = 0.0f;
            NavAgent.height = 2.0f / gameObject.transform.localScale.x;
            NavAgent.acceleration = 10000.0f;
            NavAgent.angularSpeed = 30000.0f;
            NavAgent.autoRepath = false;
            NavAgent.autoBraking = true;
        }
    }

    private bool m_bIsMoveToNoFaceTo = false; //调用moveto时 是否禁用了朝向旋转
    public bool IsMoveToNoFaceTo
    {
        get { return m_bIsMoveToNoFaceTo; }
        set { m_bIsMoveToNoFaceTo = value; }
    }
    //是否允许移动过程中根据目标点调整方向
    private bool m_EnableMovingRotation = true;
    public void EnableMovingRotation(bool bEnable)
    {
        if (null != NavAgent)
        {
            if (bEnable)
            {
                NavAgent.angularSpeed = 30000.0f;
            }
            else
            {
                NavAgent.angularSpeed = 0.0f;
            }
        }

        m_EnableMovingRotation = bEnable;
    }

    //保存路径
    //private PathNodeCollection m_MovePathList = new PathNodeCollection();


    private GameObject m_MoveTarget = null;

    public GameObject MoveTarget
    {
        get { return m_MoveTarget; }
        set
        {
            if (value != m_MoveTarget)
            {
                m_MoveTarget = value;
                if (null != m_MoveTarget)
                {
                    m_moveTargetTrans = m_MoveTarget.transform;
                }
                else
                {
                    m_moveTargetTrans = null;
                }
            }
        }
    }
    //停止距离
    private float m_fStopRange;
    public float StopRange
    {
        get { return m_fStopRange; }
        set { m_fStopRange = value; }
    }


    //防卡住措施
    private Vector3 m_LastPosition = new Vector3(0, 0, 0);
    private float m_LastPositionTime = 0.0f;

    public bool m_IsMJ = false;
    void ResetMoveOverEvent()
    {
       
    }

    //移动对外接口
    //设置好了目标点和停止距离之后会自动在Update中移动
    public void BeforeMoveTo(bool bIsAutoSearch)
    {

       
    }

    public void MoveTo(Vector3 targetPos, GameObject targetObj = null, float fStopRange = 2.0f, bool bIsAutoSearch = false)
    {

    }

    //朝向屏幕
    public void FaceToScreen()
    {
        gameObject.transform.Rotate(new Vector3(0, 145, 0));
    }

    //NPC面向某一点
    public void FaceTo(Vector3 facePos)
    {
        if (!m_EnableMovingRotation)
        {
            return;
        }

        //facePos.y = 0;
        Vector3 lookRot = facePos - m_ObjTransform.position;
        lookRot.y = 0;
        if (lookRot == Vector3.zero)
        {
            return;
        }
        //if (m_SkillCore == null || m_SkillCore.IsUsingSkill == false)//正在使用技能的时候不转向
        //{
        //    m_ObjTransform.rotation = Quaternion.LookRotation(lookRot);
        //}
    }

    //Obj向自己的目标点移动
    Transform m_moveTargetTrans = null;

    protected void UpdateTargetMove()
    {
       
    }

    //移动结束后的操作 
    protected virtual void OnMoveOver()
    {
    }

    //防卡死校验间隔
    static float s_MovingCheckInterval = 0.5f;
    //临时解决 记录上次距离移动目标的距离
    public void MoveToPosition(Vector3 targetPos, float fStopRange)
    {

    }

    private int m_Tag = 0;
    private void OtherPlayerMove()
    {
        
    }

    private bool OtherPlayerIsMove(Vector3 targetPos, float fStopRange)
    {
        return true;
    }

    #endregion

    #region Obj动作相关
    private GameDefine_Globe.OBJ_ANIMSTATE m_CurObjAnimState;
    //!!注意 访问 m_CurObjAnimState 时 请使用属性CurObjAnimState访问
    public GameDefine_Globe.OBJ_ANIMSTATE CurObjAnimState
    {
        get { return m_CurObjAnimState; }
        set
        {
            OnSwithObjAnimState(value);
        }
    }
    //Obj动作文件路径,涉及到在运行中是否需要动态加载动作
    private string m_AnimationFilePath = "";
    public string AnimationFilePath
    {
        get { return m_AnimationFilePath; }
        set { m_AnimationFilePath = value; }
    }

    public float walkMaxAnimationSpeed = 0.75f;

    protected Animation m_Objanimation; //!!!使用前记得判空
    public UnityEngine.Animation Objanimation//!!!使用前记得判空
    {
        get { return m_Objanimation; }

    }

    //初始化动作接口，目前是硬代码，之后会根据配表之类的实现
    public void InitAnimation()
    {
       
    }

    protected void UpdateAnimation()
    {
        
    }

    private float m_fLastPlayHitSoundTime = 0; //上次玩家受击音效播放的时间
                                                //   private float m_fLastPlayDamageSoundTime = 0; //上次玩家受伤害音效播放的时间
    public virtual void OnSwithObjAnimState(GameDefine_Globe.OBJ_ANIMSTATE ObjState)
    {

    }
    //待机状态处理
    void ProcessIdleAnimState()
    {
       
    }
    //行走状态处理
    void ProcessWalkAnimState()
    {
       
    }

    //有衰减的音效播放，目前用在NPC的受击、死亡音效上
    public void PlaySoundAtPos(GameDefine_Globe.OBJ_TYPE ObjType, int nSoundID, Vector3 playingPos)
    {
       
    }

    //行走状态处理
    void ProcessDeathAnimState()
    {
       
    }
    //受击状态处理
    void ProcessHitAnimState()
    {
       
    }
    //隐身
    public float m_fXSLastTime = 8.0f;
    private float m_fYScurTime = 0.0f;
    public bool m_bIsYS = false;
    GameObject obj3 = null;
    GameObject obj4 = null;
    GameObject obj5 = null;
    public void AttackYS()
    {
        

    }

    public void UpdateAttckYS()
    {


    }

    //消失
    private float m_fXSLastTime2 = 0.467f;
    private float m_fXSLastTime3 = 1.667f;
    private float m_fXScurTime = 0.0f;
    private bool m_bIsXS = false;
    public void AttackXS()
    {
      

    }
    GameObject obj2 = null;
    public void UpdateAttckXS()
    {

    }
    //后退
    private float m_fHTLastTime = 1.1f;
    private float m_fHTcurTime = 0.0f;
    private bool m_bIsCanHT = false;
    private Vector3 m_vecHTTarget = Vector3.zero;
    private float m_fHTSpeed = 1;
    private Vector3 m_vecHTTar2 = Vector3.zero;
    public void AttackHT()
    {
    }

    public void UpdateAttckHT()
    {

    }

    //瞬移
    private float m_fSXLastTime = 1.0f;
    private float m_fSXcurTime = 0.0f;
    private bool m_bIsCanSY = false;
    private Vector3 m_vecTarget = Vector3.zero;
    private float m_fSYSpeed = 300;
    private Vector3 m_vecTar2 = Vector3.zero;
    public void AttackSY()
    {
    
    }

    public void UpdateAttckSY()
    {

    }
    //普攻前的冲锋
    private float m_fAttackPGCFSpeed = 12.0f;
    private float m_fAttackPGCFLastTime = 3.0f;
    private float m_fAttackPGCFMaxHight = 0.0f;
    private float m_fAttckPGCFBeginTime = 0.0f;
    private Vector3 m_VecAttcakPGCFSrc = new Vector3(0, 0, 0);
    private Vector3 m_VecAttcakPGCFDst = new Vector3(0, 0, 0);
    public bool m_bIsCanPGCF = false;
    private Obj_Character m_cfPGTarget = null;
   
    public void AttackPGCF(Obj_Character vtarget)
    {
       
    }

    public void UpdateAttckPGCF(int profess)
    {
      
    }
    public void EndAttckPGCF()
    {
       
    }

    //冲锋
    private float m_fAttackCFSpeed = 12.0f;
    private float m_fAttackCFLastTime = 3.0f;
    private float m_fAttackCFMaxHight = 0.0f;
    private float m_fAttckCFBeginTime = 0.0f;
    private Vector3 m_VecAttcakCFSrc = new Vector3(0, 0, 0);
    private Vector3 m_VecAttcakCFDst = new Vector3(0, 0, 0);
    public bool m_bIsCanCF = false;
    private Obj_Character m_cfTarget = null;
    public void AttackCF(Obj_Character vtarget)
    {
     
    }

    public void UpdateAttckCF(int profess)
    {
      
    }
    public void EndAttckCF()
    {
      
    }

    //击飞
    private float m_fAttackFlySpeed = 0.0f;
    private float m_fAttackFlyTime = 0.0f;
    private float m_fAttackFlyMaxHight = 0.0f;
    private float m_fAttckFlyBeginTime = 0.0f;
    private Vector3 m_VecAttcakFlySrc = new Vector3(0, 0, 0);
    private Vector3 m_VecAttcakFlyDst = new Vector3(0, 0, 0);
    private bool m_bIsCanAttckFly = false;
    public void AttackFly(int nDis, int nHight, float fTime)
    {
       
    }

    public void UpdateAttckFly()
    {
       
    }

    virtual public void OnAnimationCallBack(int animationID)
    {

      
    }
    virtual public void OnAnimationFinish(int animationID)
    {

    }

    private int m_AnimInfoNextAnimId; //指定当前动作ID用于判断该动作时各职业武器挂点
    public int AnimInfoNextAnimId
    {
        get { return m_AnimInfoNextAnimId; }
        set { m_AnimInfoNextAnimId = value; }
    }

    virtual public void OnAnimationStop(int aninationID)
    {
        
    }
    //by dsy 检查是否是冲锋
    public bool CheckChongFeng(int skillid)
    {
        return false;
    }
    public bool IsMoveNavAgent(Vector3 targetVector3)
    {
      return false;
    }


    // by dys 检查是否是普攻
    public bool CheckPG(SkillCore skillcore)
    {
       
        return false;
    }
    //设置慢镜头
    public void SetMJ()
    {
        m_IsMJ = !m_IsMJ;
    }
    #endregion
}
