using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

/// <summary>
/// Obj基类
/// </summary>
public class Obj : MonoBehaviour
{
    public Obj()
    {
        m_ObjType = GameDefine_Globe.OBJ_TYPE.OBJ;
    }

    void Awake()
    {
        m_ObjTransform = transform;
    }


    public GameDefine_Globe.OBJ_TYPE m_ObjType;  //Obj类型
    private Shader m_OldShader = null;

    public GameDefine_Globe.OBJ_TYPE ObjType
    {
        get { return m_ObjType; }
    }
    protected bool m_bCanLogic = false;             //是否可以进行逻辑操作
    public bool CanLogic
    {
        get { return m_bCanLogic; }
        set { m_bCanLogic = value; }
    }

    protected int m_ServerID;                       //Obj的ServerID
    public int ServerID
    {
        get { return m_ServerID; }
        set { m_ServerID = value; }
    }

    protected int m_ModelID;                        //Obj的模型ID,在CharModel表中定义
    public int ModelID
    {
        get { return m_ModelID; }
        set { m_ModelID = value; }
    }

    private GameObject m_ModelNode = null;           //暂存Model节点
    public UnityEngine.GameObject ModelNode
    {
        get { return m_ModelNode; }
        set { m_ModelNode = value; }
    }
    //////////////////////////////////////////////////////////////////////////
    //常用基础方法属性接口
    //////////////////////////////////////////////////////////////////////////
    protected Transform m_ObjTransform = null;        //缓存Transform，提高运行效率,必须在Awake的时候就进行赋值
    public Transform ObjTransform
    {
        get { return m_ObjTransform; }
    }
    public Vector3 Position
    {
        get { return m_ObjTransform.localPosition; }
        set
        {
            //value.y = 0;
            m_ObjTransform.localPosition = value;
        }
    }
    public Quaternion Rotation
    {
        get { return m_ObjTransform.localRotation; }
        set { m_ObjTransform.localRotation = value; }
    }
    public Vector3 Scale
    {
        get { return m_ObjTransform.localScale; }
        set { m_ObjTransform.localScale = value; }
    }
    public string GameObjectName
    {
        get { return this.gameObject.name; }
        set { this.gameObject.name = value; }
    }

    //设置大小
    public void SetScale(float fScale)
    {
        
    }

    //判断物体是否在自己前方
    public bool IsInFront(Obj targetObj)
    {

        return false;
    }

    #region 材质
    ///////////////////////////////////////////////////////////////////////////////
    //材质相关
    ///////////////////////////////////////////////////////////////////////////////
    protected List<Material> m_WeaponMaterialList = new List<Material>();//!!!缓存武器材质信息 使用前记得判空防止出现丢失的情况
    protected List<Material> m_BodyMaterialList = new List<Material>();//!!!缓存身体材质信息 使用前记得判空防止出现丢失的情况
    protected Dictionary<string, Color> m_BodyInitColorDic = new Dictionary<string, Color>(); //!!!缓存身体材质的颜色 使用前记得判空防止出现丢失的情况
    protected Dictionary<string, Color> m_WeaponInitColorDic = new Dictionary<string, Color>(); //!!!缓存武器材质的颜色 使用前记得判空防止出现丢失的情况
    protected Dictionary<string, Shader> m_BodyInitShaderDic = new Dictionary<string, Shader>(); //!!!缓存身体材质的shader 使用前记得判空防止出现丢失的情况
    protected Dictionary<string, Shader> m_WeaponInitShaderDic = new Dictionary<string, Shader>(); //!!!缓存武器材质的shader 使用前记得判空防止出现丢失的情况
    protected bool m_bIsPlayDissolve = false;//是否开始播放溶解效果
    protected float m_fPlayDissolveSpeed = 2.0f;//是否开始播放溶解效果
    protected float m_fPlayDissolveDelay = 0.5f;//延迟时间
    protected bool m_bIsPlayUnDissolve = false;//是否开始播放反溶解效果
    protected float m_fPlayUnDissolveSpeed = 2.0f;//是否开始播放溶解效果
    protected float m_fPlayUnDissolveDelay = 0.5f;//延迟时间
    //初始材质数据
    public void InitMaterialInfo()
    {
    }

    //初始化武器的材质
    public void InitWeaponMaterialInfo()
    {
        
    }
    public virtual void OptAfterInitMaterialInfo()
    {
       
    }
    //是否是身体的渲染
    public bool IsBodyRenderer(Renderer _Renderer)
    {
        return false;
    }
    //是否是武器的渲染
    public bool IsWeaponRenderer(Renderer _Renderer)
    {
       
        return false;
    }
    #endregion
    #region 材质变色
    //设置为初始颜色
    public void SetMaterialInitColor()
    {
       
    }

    //设置模型材质颜色
    public void SetMaterialColor(Material _material, float red, float green, float blue)
    {
        
    }
    //设置模型材质颜色
    public void SetMaterialColor(float red, float green, float blue)
    {
       
    }

    #endregion



    public void SetShanBai()
    {
        

    }
    public void UpdateShanBai()
    {

    }
    public void CanselShanBai()
    {
        
    }
    public void SetOutLine()
    {
    }


    public void CancelOutLine()
    {

    }
    //设置溶解
    public void SetDissolve()
    {

    }

    //取消溶解
    public void CancelDissolve()
    {
        
    }
    #region 隐身设置

    private int m_nStealthLev = 0;
    public virtual int StealthLev
    {
        get { return m_nStealthLev; }
        set { m_nStealthLev = value; }
    }
    //设置隐身
    public void SetStealthState()
    {
    }

    //取消隐身
    public void CancelStealthState()
    {
        
    }
    #endregion
    #region 溶解效果
    //更新溶解效果
    public void UpdateDissolve()
    {
       
    }

    //溶解效果
    public void PlayDissolve(float _Speed, float _delaytime)
    {
       
    }

    //反溶解效果
    public void PlayUnDissolve(float _Speed, float _delaytime)
    {

        
    }

    /// <summary>
    /// 显示溶解的NPC
    /// </summary>
    public void ShowDissolveNPC()
    {
       
    }

    #endregion


    #region 隐身设置

    private bool m_bianshen = false;
    public bool BianShen
    {
        get { return m_bianshen; }
        set { m_bianshen = value; }
    }
    private Color oldColor = Color.white;
    private Color oldWeaponColor = Color.white;
    //设置变身
    public void SetBianshen(Color col)
    {

    }

    //取消变身
    public void CancelBianshen()
    {
        
    }
    #endregion
    #region 效果逻辑
 

    //初始化特效
    public void InitEffect()
    {
        
    }

    //播放特效
    public void PlayEffect()
    {
       
    }
    //停止特效
    public void StopEffect(int effectID, bool bStopAll = true)
    {
   
    }
    public bool IsHaveBindPoint(string strPoint)
    {
  
        return false;
    }
    //获取特效数量
    public int GetEffectCountById(int id)
    {
    
        return 0;
    }
    #endregion
}
