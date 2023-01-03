
using UnityEngine;
using System.Collections.Generic;
//雷达图
public class Radar : MonoBehaviour
{
    private float m_mapTexWidth = 735;      // 地图图片宽度
    private float m_mapTexHeight = 735;     // 地图图片高
    //private float m_mapRealWidth = 42;      // 图片宽度对应的逻辑宽度

    private float MapScreenHalfWidth = 68;  // 显示区域宽度的一半
    private float MapScreenHalfHeight = 53; // 显示区域高度的一半

    public float UPDATE_DELAY = 0.5f;       // 更新延迟

    public GameObject   MapClip;
    public GameObject   ObjArrow;       // 主角箭头
	public GameObject   FriendPoint;		//Friend Unit Radar Point, Never show up, just for Instance 
	public GameObject	  NeutralPoint;	//Neutral Unit Radar Point, Never show up, just for Instance 
	public GameObject	  EnemyPoint;	//Enemy Unit Radar Point, Never show up, just for Instance 
	public GameObject	  OtherPoint;	    //Other Unit Radar Point, Never show up, just for Instance 
    public GameObject TexTarget;      // 寻路目标位置提示图片
    /*public UILabel      LabelPos;       // 位置信息Label
	
    public UILabel      LabelSceneName; // 当前场景名
    public UILabel      LabelChannel;   // 当前频道
    public UIPanel      PanelMapClip;*/
    private Vector3 arrowPos    = Vector3.zero;     
    private Vector3 arrowRot    = Vector3.zero;
    private Vector3 mapPos      = Vector3.zero;  

	/*private  List<UISprite> TexListFriend     = new List<UISprite>();
	private  List<UISprite> TexListNeutral    = new List<UISprite>();
	private  List<UISprite> TexListEnemy      = new List<UISprite>();
	private  List<UISprite> TexListOther      = new List<UISprite>();*/

    private float m_scale = 1.0f;     // 当前地图与实际地形比例
    private bool m_bLoadMap = false;   //不可刷新
    
    void Start()
    {
        /*//主角箭头先失活
        ObjArrow.SetActive(false);
        //不可刷新
        m_bLoadMap = false;
        //获取当前场景
        Tab_SceneClass curScene = TableManager.GetSceneClassByID(GameManager.gameManager.RunningScene, 0);
        //判断当前场景  //判断当前场景是不是武神塔
        if (null == curScene)
        {
          //  LogModule.ErrorLog("load scene map table fail :" + GameManager.gameManager.RunningScene);
            return;
        }
        LabelSceneName.color = SceneData.GetSceneNameColor(GameManager.gameManager.RunningScene);
        LabelSceneName.text = curScene.Name;
        if (curScene.SceneID == (int)GameDefine_Globe.SCENE_DEFINE.SCENE_WUSHENTA)
        {
            int tier = GameManager.gameManager.PlayerDataPool.CommonData.GetCommonData((int)Games.UserCommonData.USER_COMMONDATA.CD_COPYSCENE_CANGJINGGE_TIER);
            //Tab_CangJingGeInfo cjg = TableManager.GetCangJingGeInfoByID(tier,0);
            LabelSceneName.text = StrDictionary.GetClientDictionaryString("#{2221}", tier);
        }
        //地图图片宽度等于当前场景实际的宽度
        //地图图片长度等于当前场景实际的长度
        m_mapTexWidth = curScene.SceneMapWidth;
        m_mapTexHeight = curScene.SceneMapHeight;
        //判断当前场景信息的SceneMapLogicWidth为不为0
        if (curScene.SceneMapLogicWidth == 0)
        {
           // LogModule.ErrorLog("load scene with is 0 :" + curScene.SceneMapTexture);
            return;
        }
        //获得比例值
        m_scale = m_mapTexWidth / curScene.SceneMapLogicWidth;
        //加载一个地图纹理
        Texture curTexture = ResourceManager.LoadResource(curScene.SceneMapTexture, typeof(Texture)) as Texture;
        //判空
        if (null == curTexture)
        {
            //LogModule.ErrorLog("load scene map fail :" + curScene.SceneMapTexture);
			return;
        }
        else
        {
            // 不等于空重新给显示区域高度的一半赋值
            //不等于空重新给显示区域宽度的一半赋值
            MapScreenHalfHeight = PanelMapClip.clipRange.w * 0.5f;
            MapScreenHalfWidth = PanelMapClip.clipRange.z * 0.5f;
            //给MapClip身上的纹理赋值参数
            MapClip.GetComponent<UITexture>().mainTexture = curTexture;
            MapClip.GetComponent<UITexture>().width = (int)m_mapTexWidth;
            MapClip.GetComponent<UITexture>().height = (int)m_mapTexHeight;
            MapClip.GetComponent<UITexture>().pivot = UIWidget.Pivot.BottomLeft;
        }
        //给主角箭头激活
        ObjArrow.SetActive(true);
       
        LabelChannel.text = StrDictionary.GetClientDictionaryString("{#1177}", SceneData.SceneInst + 1);
        // m_bLoadMap = true;可以刷新
        m_bLoadMap = true;

        InvokeRepeating("UpdateMap", 0, UPDATE_DELAY);*/
    }

    //0.5秒调用一次，相当于刷新
    void UpdateMap()
    {
        //是否初始化完成，是否可以刷新
        if (!m_bLoadMap)
        {
            return;
        }
        //获取主玩家//判空
        ///Obj_MainPlayer curPlayer = Singleton<ObjManager>.GetInstance().MainPlayer;
        /*if (null == curPlayer)
        {
            return;
        }*/
        //获取主角箭头的位置
        ///arrowPos = GetMapPos(curPlayer.transform.position);
        ////赋值给主角箭头注意此刻是localPosition
        ObjArrow.transform.localPosition = arrowPos;
        //获取主角的旋转角度因为是平面的，所以只知道y值就行
        ///arrowRot.z = -curPlayer.transform.localRotation.eulerAngles.y;
        ObjArrow.transform.rotation = Quaternion.Euler(arrowRot);
        //特殊的算法来计算地图的位置
        mapPos.x = Mathf.Min(-MapScreenHalfWidth, Mathf.Max(-arrowPos.x, MapScreenHalfWidth - m_mapTexWidth));
        mapPos.y = Mathf.Min(-MapScreenHalfHeight, Mathf.Max(-arrowPos.y, MapScreenHalfHeight - m_mapTexHeight));
       // 相当于移动的是地图的位置
        MapClip.transform.localPosition = mapPos;
        //给文字赋值，是挡在所在的坐标//即是当前玩家的z值 和 z值
    /*
        if (null != LabelPos)
		{
            
			LabelPos.text =((int)curPlayer.transform.position.x).ToString() + ", " + ((int)curPlayer.transform.position.z).ToString();
		}
        //是否自动寻路中标记位
        if (GameManager.gameManager && GameManager.gameManager.AutoSearch && GameManager.gameManager.AutoSearch.IsAutoSearching)
		{
            //自动寻路路径类，只保存数据
            AutoSearchPath path = GameManager.gameManager.AutoSearch.Path;
            //判断自动寻路点缓存的个数大于0
            if (path.AutoSearchPosCache.Count > 0 )
			{
                //找到最后一个缓存点
                //
                AutoSearchPoint lastPoint = path.AutoSearchPosCache[path.AutoSearchPosCache.Count-1];
                //判断是不是同一个地图
                if (lastPoint.SceneID == GameManager.gameManager.RunningScene)
				{
                    //设置寻路目标位置提示图片的位置
                    TexTarget.transform.localPosition = GetMapPos(lastPoint.PosX, lastPoint.PosZ);
				}
			}
        }//为空
        else
		{
			TexTarget.transform.localPosition = GetMapPos(100000, 10000);
		}*/

        //每次都重新去找敌人，队友等重新赋值为0

        int curFriendCount = 0;
        int curNeutralCount = 0;
        int curEnemyCount = 0;
        int curOtherCount = 0;
        //从对象池中去遍历
        /*foreach (Obj curObj in Singleton<ObjManager>.GetInstance().ObjPools.Values)
        {
            //MainPlayer在前面设置过位置，伙伴不显示，所以这两个排除
            if (curObj.ObjType == GameDefine_Globe.OBJ_TYPE.OBJ_MAIN_PLAYER || curObj.ObjType == GameDefine_Globe.OBJ_TYPE.OBJ_FELLOW)
            {
                continue;
            }

            //只显示如下三种类型：角色，NPC，其他玩家
            if (curObj.ObjType != GameDefine_Globe.OBJ_TYPE.OBJ_CHARACTER &&
                curObj.ObjType != GameDefine_Globe.OBJ_TYPE.OBJ_NPC &&
                curObj.ObjType != GameDefine_Globe.OBJ_TYPE.OBJ_OTHER_PLAYER)
            {
                continue;
            }
            //获取当前的角色

            Obj_Character curChar = curObj as Obj_Character;
            //判空
            if (null == curChar)
            {
                continue;
            }
            //获取目标角色和主角色之间的位置差
            float xPosDiff = curChar.transform.localPosition.x - curPlayer.transform.localPosition.x;
			float yPosDiff = curChar.transform.localPosition.z - curPlayer.transform.localPosition.z;
            //判断位置差是否大于显示区域一半的宽度和高度
            if (Mathf.Abs(xPosDiff) * m_scale > MapScreenHalfWidth || Mathf.Abs(yPosDiff) * m_scale > MapScreenHalfHeight)
			{
                //如果大于就跳过此次，不显示
                continue;
			}
            //获取角色之间的关系
            CharacterDefine.REPUTATION_TYPE type = Reputation.GetObjReputionType(curChar);
            //友好
            if (CharacterDefine.REPUTATION_TYPE.REPUTATION_FRIEND == type)
            {//当前友军的个数++
                AddDotToList(TexListFriend, curFriendCount, FriendPoint, curObj, CharacterDefine.NPC_COLOR_FRIEND);
				setTexColor(curChar,TexListFriend,curFriendCount);
                curFriendCount++;
            }
            //中立
            else if (CharacterDefine.REPUTATION_TYPE.REPUTATION_NEUTRAL == type)
            {
                //当前中立的个数++
                AddDotToList(TexListNeutral, curNeutralCount, NeutralPoint, curObj, CharacterDefine.NPC_COLOR_NEUTRAL);
				setTexColor(curChar,TexListNeutral,curNeutralCount);
				curNeutralCount++;
            }
            //敌人
            else if (CharacterDefine.REPUTATION_TYPE.REPUTATION_HOSTILE == type)
            {
                //当前敌人的个数++
                AddDotToList(TexListEnemy, curEnemyCount, EnemyPoint, curObj, CharacterDefine.NPC_COLOR_ENEMY);
				setTexColor(curChar,TexListEnemy,curEnemyCount);
                curEnemyCount++;
            }
            else
            {
                AddDotToList(TexListOther, curOtherCount, OtherPoint, curObj, Color.white);
				setTexColor(curChar,TexListOther,curOtherCount);
                curOtherCount++;
            }

        }*/

		/*DeActiveList(curFriendCount, TexListFriend, arrowPos);
		DeActiveList(curNeutralCount, TexListNeutral,arrowPos);
		DeActiveList(curEnemyCount, TexListEnemy,arrowPos);
		DeActiveList(curOtherCount, TexListOther,arrowPos);*/
        
    }


	/*private void setTexColor(Obj_Character curChar,List<UISprite> texList,int index)
	{
		if(curChar.BaseAttr.Die)
		{
			if(texList[index].enabled)
			{
				texList[index].color = GlobeVar.TRANSPARENT_COLOR;
				texList[index].enabled = false;
			}
		}
	}*/

    // 将小点加入缓存列表
    /*void AddDotToList(List<UISprite> curList,  int curIndex, GameObject instanceObj,  Obj curShowObj, Color color)
    {
        if (curIndex >= curList.Count)
        {
			GameObject newObj = CreateRadarPoint(instanceObj, curShowObj.gameObject.transform.localPosition);
			if (null == newObj)
				return;

			UISprite sprite = newObj.GetComponent<UISprite>();
//			GameObject newObj = CreateTexture(color, curShowObj.transform.localPosition);
			if (null != sprite)
				curList.Add(sprite);
        }
        else
        {
			//            curList[curIndex].SetActive(true);
			Obj_Character curChar = curShowObj as Obj_Character;
			if(!curChar.BaseAttr.Die)
			{
				curList[curIndex].enabled = true;
				curList[curIndex].color = Color.white;
				curList[curIndex].gameObject.transform.localPosition = GetMapPos(curShowObj.gameObject.transform.localPosition);
			}else{
				curList[curIndex].enabled = false;
			}

        }
    }*/

    // 逻辑位置转换地图位置
    Vector3 GetMapPos(Vector3 curPos)
    {
        //根据求得的比例m_scale去获取玩家在小地图中的位置
        return GetMapPos(curPos.x, curPos.z);
	}

    // 逻辑位置转换地图位置
	Vector3 GetMapPos(float xPos, float zPos)
	{
			Vector3 tempPos = Vector3.zero;
			tempPos.x = xPos * m_scale;
			tempPos.y = zPos * m_scale;
			return tempPos;
	}

	// Create a Radar Point
	GameObject CreateRadarPoint(GameObject obj, Vector3 targetPos)
	{
		if (null == obj)
			return null;

		GameObject newObj = (GameObject)GameObject.Instantiate(obj);
		if (null == newObj)
			return null;

		newObj.transform.parent = MapClip.transform;
		newObj.transform.localScale = Vector3.one;
		newObj.transform.localPosition = GetMapPos(targetPos);
		newObj.layer = MapClip.layer;
		newObj.SetActive(true);

		return newObj;
	}
	
    // 将不用的小点隐藏
    /*void DeActiveList(int useCount, List<UISprite> curList, Vector3 centerPos)
    {
        Vector3 finalPos = centerPos;
        for (int i = useCount; i < curList.Count; i++)
        {
            if (curList[i].color != GlobeVar.TRANSPARENT_COLOR)
            {
                finalPos.x = centerPos.x - MapScreenHalfWidth / 2 + Random.Range(0, MapScreenHalfWidth);
                finalPos.y = centerPos.y - MapScreenHalfHeight / 2 + Random.Range(0, MapScreenHalfHeight);
                curList[i].color = GlobeVar.TRANSPARENT_COLOR;
                curList[i].transform.localPosition = finalPos;
            }
        }
    }*/

}