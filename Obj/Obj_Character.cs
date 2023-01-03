using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Obj_Character : Obj
{
    #region 构造函数
    public Obj_Character()
    {
      

    }

    #endregion

    #region BindData
    private int m_BindParent;
    //更新父节点的绑定状态
    public int BindParent
    {
        get { return m_BindParent; }
        set
        {
            int oldId = m_BindParent;
            m_BindParent = value;
            OnBindParentChange(oldId, value);
        }
    }
    private List<int> m_BindChildren;
    public int GetBindChildIndex(int id)
    {
        for (int n = 0; n < m_BindChildren.Count; ++n)
        {
            if (m_BindChildren[n] == id)
            {
                return n;
            }
        }
        return -1;
    }
    //用于在装载模型之后的一次刷新
    public void UpdateAllBind()
    {
      
    }
    //更新子节点绑定状态
    public void UpdateBindChildren(List<int> data)
    {
        
        
    }
    //绑定父节点的变化响应
    public virtual void OnBindParentChange(int oldID, int newID)
    {
        
    }
    //绑定子节点的变化响应
    public virtual void OnBindChildChange(int oldID, int newID)
    {
        
        
    }
    //父节点：绑定子节点的操作内容
    public virtual void OnBindOpt(Obj_Character obj)
    {
        
    }
    //子节点：与父节点解绑的操作内容
    public virtual void OnUnBindOpt(Vector3 parentPos)
    {
       
    }
    //初始化
    public void InitBindFromData()
    {
    }
    #endregion
    #region Mono脚本接口
    #endregion

    #region 技能
    protected SkillCore m_SkillCore = null;
    public SkillCore SkillCore
    {
        get { return m_SkillCore; }
    }

    protected int m_curUseSkillId = -1;
    public int CurUseSkillId
    {
        get { return m_curUseSkillId; }
        set { m_curUseSkillId = value; }
    }

    //初始化Obj逻辑数据
    public virtual bool Init()
    {
        
        return true;
    }
    #endregion

    #region 重生
    //////////////////////////////////////////////////////////////////////////
    //NPC重生相关处理
    //////////////////////////////////////////////////////////////////////////
    //Obj创建时候如果是死亡状态时候调用
    public virtual bool OnCorpse()
    {
        
        return true;
    }
    //Obj死亡时候调用
    public virtual bool OnDie()
    {
        

        return true;
    }
    //Obj复活时调用
    public virtual bool OnRelife()
    {
        
        return true;
    }
    public bool IsDie()
    {
        return true;
    }
    private bool m_isAutoLife = false;      //是否自动重生
    public bool AutoLife
    {
        get { return m_isAutoLife; }
        set { m_isAutoLife = value; }
    }
    private short m_nAutoLifeTime;  //自动重生时间
    public short AutoLifeTime
    {
        get { return m_nAutoLifeTime; }
        set { m_nAutoLifeTime = value; }
    }
    #endregion


    #region UI及名字版
    //名字板相关
    protected GameObject m_HeadInfoBoard;        // 头顶信息板总节点
    public UnityEngine.GameObject HeadInfoBoard
    {
        get { return m_HeadInfoBoard; }

    }
    //protected UILabel m_NameBoard;              // 名字板 所有obj共有

    // 名字板list中的索引
    protected int m_NameBoardIndex;
    public int NameBoardIndex
    {
        get { return m_NameBoardIndex; }
        set { m_NameBoardIndex = value; }
    }

    // 头顶信息板高度调整
    protected float m_DeltaHeight;
    public float DeltaHeight
    {
        get { return m_DeltaHeight; }
        set { m_DeltaHeight = value; }
    }

    //显示姓名板
    public void ShowNameBoard()
    {
       
    }

    //关闭姓名板
    public void CloseNameBoard()
    {
    }
    //设置姓名板颜色
    public virtual void SetNameBoardColor()
    {
        
    }

    public virtual Color GetNameBoardColor()
    {
        return Color.black;
    }
    //List<MultiShowDamageBoard> m_MultiShowDamageInfo;
   
    public void UpdateShowMultiShowDamageBoard()
    {
        
    }
    //伤害
    public virtual void ShowDamageBoard()//GameDefine_Globe.DAMAGEBOARD_TYPE eType, int nValue = 0)
    {


    }
    //技能名字
    public virtual void ShowDamageBoard_SkillName()//GameDefine_Globe.DAMAGEBOARD_TYPE eType, string strValue, bool isProfessionSkill = true)
    {
       
    }

    //选择目标后更新UI信息
    public void UpdateTargetFrame(Obj_Character targetObj)
    {
       
    }
    #endregion

    #region AI
    protected bool m_bCanMove = false;
    private int m_nReputation = 0;
    public int ReputationID
    {
        get { return m_nReputation; }
        set { m_nReputation = value; }
    }

    private AIController m_aiController = null;
    public AIController Controller
    {
        get { return m_aiController; }
        set { m_aiController = value; }
    }

    public void InitAI()
    {
        m_aiController = this.gameObject.GetComponent<AIController>();
    }
    //战斗相关
    public virtual void OnEnterCombat(Obj_Character Attacker)
    {
    }
    public virtual void OnLevelCombat(Obj_Character Attacker)
    {
    }

    public Vector3 DefaultPosition()
    {
        //单机点以后统一在场景中增加叫做OffLine节点，不用每一个场景写一个else if了
        GameObject offLinePoint = GameObject.Find("OffLine");
        if (null != offLinePoint)
        {
            return offLinePoint.transform.position;
        }

        return new Vector3(0.0f, 0.0f, 0.0f);
    }
    #endregion



    #region 纸娃娃 重载模型
    public void ReloadPlayerModelVisual()
    {

    }

    public void RealoadPlayerWeaponVisual()
    {
      
    }

    public int GetCharModelID()
    {
        return 0;
    }

    public int GetWeaponModelID()
    {
        return 0;
    }
    #endregion

    #region 可见性
    protected bool m_bVisible = true;
    public virtual void SetVisible(bool bVisible)
    {
        m_bVisible = bVisible;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(m_bVisible);
        }
    }

    public bool IsVisibleChar() { return m_bVisible; }

    // 重载模型回调
    public virtual void OnReloadModle()
    {
      
    }
    public override void OptAfterInitMaterialInfo()
    {
       
    }
    // 返回隐藏权重值
    public int GetVisibleValue()
    {
       

        return 0;
    }

    // 和隐藏不一样，为模型是否可见
    private bool m_bModelInViewPort = true;
    public bool ModelInViewPort
    {
        get { return m_bModelInViewPort; }
        set { m_bModelInViewPort = value; }
    }
    #endregion
    #region 技能范围特效

    public void PlaySkillRangeEffect()
    {
        
    }
    public void PlaySkillRangeEffect(int skillid)
    {

        
    }
    void OnLoadSkillRangeEffect(GameObject SkillRangeEffect, object param)
    {

    }
    public void StopSkillRangeEffect()
    {
    }
    //boss加入技能环的功能
    public void StopSkillRangeEffect(int skillid)
    {

    }
    #endregion

}
