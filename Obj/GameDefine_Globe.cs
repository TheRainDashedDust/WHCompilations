using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefine_Globe
{

    public enum OBJ_TYPE                    //Obj类型
    {
        OBJ,

    }
    //NPC类别（0普通 1精英 2 BOSS）
    public enum NPC_TYPE
    {
        NORMAL = 0,//普通
        ELITE,//精英
        BOSS,//BOSS
    }
    //obj状态 相关 !!!跟服务器 ANIMATIONSTATE　保持一致
    public enum OBJ_ANIMSTATE
    {
        STATE_INVAILD = -1,
  
    }
}
