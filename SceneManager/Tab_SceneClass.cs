using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tab_SceneClass
{
    private const string TAB_FILE_DATA = "Tables/SceneClass.txt";
    enum _ID
    {

    }
    public static string GetInstanceFile() { return TAB_FILE_DATA; }

    private int m_BGMusic;
    public int BGMusic { get { return m_BGMusic; } }

    private int m_CopySceneID;
    public int CopySceneID { get { return m_CopySceneID; } }

    private int m_DeadPunishRule;
    public int DeadPunishRule { get { return m_DeadPunishRule; } }

    private float m_EntryX;
    public float EntryX { get { return m_EntryX; } }

    private float m_EntryZ;
    public float EntryZ { get { return m_EntryZ; } }

    private int m_IsCanUseXp;
    public int IsCanUseXp { get { return m_IsCanUseXp; } }

    private int m_Length;
    public int Length { get { return m_Length; } }

    private string m_Name;
    public string Name { get { return m_Name; } }

    private string m_Obstacle;
    public string Obstacle { get { return m_Obstacle; } }

    private int m_PVPRule;
    public int PVPRule { get { return m_PVPRule; } }

    private int m_PlayersMaxA;
    public int PlayersMaxA { get { return m_PlayersMaxA; } }

    private int m_PlayersMaxB;
    public int PlayersMaxB { get { return m_PlayersMaxB; } }

    public int getReliveTypeCount() { return 3; }
    private int[] m_ReliveType = new int[3];
    public int GetReliveTypebyIndex(int idx)
    {
        if (idx >= 0 && idx < 3) return m_ReliveType[idx];
        return -1;
    }
    //字段属性
    private string m_ResName;
    public string ResName { get { return m_ResName; } }

    private int m_SceneID;
    public int SceneID { get { return m_SceneID; } }

    private int m_SceneMapHeight;
    public int SceneMapHeight { get { return m_SceneMapHeight; } }

    private int m_SceneMapLogicWidth;
    public int SceneMapLogicWidth { get { return m_SceneMapLogicWidth; } }

    private string m_SceneMapTexture;
    public string SceneMapTexture { get { return m_SceneMapTexture; } }

    private int m_SceneMapWidth;
    public int SceneMapWidth { get { return m_SceneMapWidth; } }

    private string m_SceneScript;
    public string SceneScript { get { return m_SceneScript; } }

    private int m_TerrainHeightMapLength;
    public int TerrainHeightMapLength { get { return m_TerrainHeightMapLength; } }

    private int m_TerrainHeightMapWidth;
    public int TerrainHeightMapWidth { get { return m_TerrainHeightMapWidth; } }

    private int m_TerrainHeightMax;
    public int TerrainHeightMax { get { return m_TerrainHeightMax; } }

    private int m_Type;
    public int Type { get { return m_Type; } }

    private int m_Width;
    public int Width { get { return m_Width; } }

    public static bool LoadTable(Dictionary<int, List<object>> _tab)
    {
        if (!TableManager.ReaderPList(GetInstanceFile(), SerializableTable, _tab))
        {
            //throw TableException.ErrorReader("Load File{0} Fail!!!", GetInstanceFile());
        }
        return true;
    }
    public static void SerializableTable(string[] valuesList, int skey, Dictionary<int, List<object>> _hash)
    {
        //场景信息判断
        /*if ((int)_ID.MAX_RECORD != valuesList.Length)
        {
            throw TableException.ErrorReader("Load {0} error as CodeSize:{1} not Equal DataSize:{2}", GetInstanceFile(), _ID.MAX_RECORD, valuesList.Length);
        }*/
        Tab_SceneClass _values = new Tab_SceneClass();
        //_values.m_BGMusic = Convert.ToInt32(valuesList[(int)_ID.ID_BGMUSIC] as string);
        

        if (_hash.ContainsKey(skey))
        {
            List<object> tList = _hash[skey];
            tList.Add(_values);
        }
        else
        {
            List<object> tList = new List<object>();
            tList.Add(_values);
            _hash.Add(skey, (List<object>)tList);
        }
    }
}
