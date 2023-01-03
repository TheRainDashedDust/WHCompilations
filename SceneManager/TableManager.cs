using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public delegate void SerializableTable(string[] valuesList, int skey, Dictionary<int, List<object>> _hash);
[Serializable]
public class TableManager
{
    private static string GetLoadPath(string localName)
    {
        string localPath = Application.persistentDataPath + "/ResData/Tables/" + localName + ".txt";
        if (File.Exists(localPath))
        {
            return localPath;
        }
#if UNITY_ANDROID && !UNITY_EDITOR
 return localPath;
#elif UNITY_EDITOR
        return Application.dataPath + "/BundleAssets/Tables/" + localName + ".txt";
#else
 return Application.streamingAssetsPath + "/Tables/" + localName + ".txt";
#endif
    }
    private static string[] MySplit(string str, string[] nTypeList, string regix)
    {
        if (string.IsNullOrEmpty(str))
        {
            return null;
        }
        String[] content = new String[nTypeList.Length];
        int nIndex = 0;
        int nstartPos = 0;
        while (nstartPos <= str.Length)
        {
            int nsPos = str.IndexOf(regix, nstartPos);
            if (nsPos < 0)
            {
                String lastdataString = str.Substring(nstartPos);
                if (string.IsNullOrEmpty(lastdataString) && nTypeList[nIndex].ToLower() != "string")
                {
                    content[nIndex++] = "--";
                }
                else
                {
                    content[nIndex++] = lastdataString;
                }
                break;
            }
            else
            {
                if (nstartPos == nsPos)
                {
                    if (nTypeList[nIndex].ToLower() != "string")
                    {
                        content[nIndex++] = "--";
                    }
                    else
                    {
                        content[nIndex++] = "";
                    }
                }
                else
                {
                    content[nIndex++] = str.Substring(nstartPos, nsPos - nstartPos);
                }
                nstartPos = nsPos + 1;
            }
        }
        return content;
    }
    private static string m_Key = "";
    private static string[] m_Value;
    public static bool ReaderPList(String xmlFile, SerializableTable _fun, Dictionary<int, List<object>> _hash)
    {
        string[] list = xmlFile.Split('.');
        string relTablePath = list[0].Substring(7);
        string tableFilePath = GetLoadPath(relTablePath);
        string[] alldataRow;
        if (File.Exists(tableFilePath))
        {
            StreamReader sr = null;
            sr = File.OpenText(tableFilePath);
            string tableData = sr.ReadToEnd();
            sr.Close();
            alldataRow = tableData.Split('\n');
        }
        else
        {
            TextAsset testAsset = Resources.Load(list[0], typeof(TextAsset)) as TextAsset;
            alldataRow = testAsset.text.Split('\n');
        }
        //skip fort three
        int skip = 0;
        string[] typeList = null;
        foreach (string line in alldataRow)
        {
            int nKey = -1;
            if (skip == 1)
            {
                string sztemp = line;
                if (sztemp.Length >= 1)
                {
                    if (sztemp[sztemp.Length - 1] == '\r')
                    {
                        sztemp = sztemp.TrimEnd('\r');
                    }
                }
                typeList = line.Split('\t');
                m_Value = new string[typeList.Length];
                ++skip;
                continue;
            }
            if (++skip < 4) continue;
            if (String.IsNullOrEmpty(line)) continue;
            if (line[0] == '#') continue;
            string szlinetemp = line;
            if (szlinetemp.Length >= 1)
            {
                if (szlinetemp[szlinetemp.Length - 1] == '\r')
                {
                    szlinetemp = szlinetemp.TrimEnd('\r');
                }
            }
            string[] strCol = MySplit(szlinetemp, typeList, "\t");
            if (strCol.Length == 0) continue;
            string skey = strCol[0];
            string[] valuesList = new string[strCol.Length];

            if (string.IsNullOrEmpty(skey) || skey.Equals("--"))
            {
                skey = m_Key;
                nKey = Int32.Parse(skey);
                valuesList[0] = skey;
                for (int i = 1; i < strCol.Length; ++i)
                {
                    if (String.IsNullOrEmpty(strCol[i]) || strCol[i] == "--")
                    {
                        valuesList[i] = m_Value[i];
                    }
                    else
                    {
                        valuesList[i] = strCol[i];
                        m_Value[i] = strCol[i];
                    }
                }

            }
            else
            {
                m_Key = skey;
                nKey = Int32.Parse(skey);

                for (int i = 0; i < strCol.Length; ++i)

                {
                    if (strCol[i] == "--")
                    {
                        valuesList[i] = "0";
                        m_Value[i] = "0";
                    }
                    else
                    {
                        valuesList[i] = strCol[i];
                        m_Value[i] = strCol[i];
                    }
                }
            }
            _fun(valuesList, nKey, _hash);
        }
        return true;
    }
    private static Dictionary<int, List<Tab_SceneClass>> g_SceneClass = new Dictionary<int, List<Tab_SceneClass>>();
    public static bool InitTable_SceneClass()
    {
        g_SceneClass.Clear();
        Dictionary<int, List<object>> tmps = new Dictionary<int, List<object>>();
        if (!Tab_SceneClass.LoadTable(tmps)) return false;
        foreach (KeyValuePair<int, List<object>> kv in tmps)
        {
            List<Tab_SceneClass> values = new List<Tab_SceneClass>();
            foreach (object subit in kv.Value)
            {
                values.Add((Tab_SceneClass)subit);
            }
            g_SceneClass.Add(kv.Key, values);
        }
        return true;
    }
    public static List<Tab_SceneClass> GetSceneClassByID(int nKey)
    {
        if (g_SceneClass.Count == 0)
        {
            InitTable_SceneClass();
        }
        if (g_SceneClass.ContainsKey(nKey))
        {
            return g_SceneClass[nKey];
        }
        return null;
    }
    public static Tab_SceneClass GetSceneClassByID(int nKey, int nIndex)
    {
        if (g_SceneClass.Count == 0)
        {
            InitTable_SceneClass();
        }
        if (g_SceneClass.ContainsKey(nKey))
        {
            if (nIndex >= 0 && nIndex < g_SceneClass[nKey].Count)
                return g_SceneClass[nKey][nIndex];
        }
        return null;
    }
}
