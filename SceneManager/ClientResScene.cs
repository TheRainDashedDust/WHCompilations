using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseWidget : MonoBehaviour
{
    public virtual void OnLoad() { }
    public virtual void OnExit() { }
}
public class ClientResScene : BaseScene
{
    AsyncOperation async;
    // EC_Row row;
    //public ResTestPlayer ScenePlayer;
    int LoadRoleType;
    int ItemVisualType;
    string LoadSceneName;

    BaseWidget SkillBar;

    Tab_SceneClass sceneclass;
    Dictionary<string, float> YKVList;
    GameObject ParentTestG;

    float TestLoopTime = 3.5f;
    public override void OnLoad(params object[] mparam)
    {
        // EC_Table table = ExcelTableManager.GetTable("SceneClass");
        // row = table.TableRows[(int)mparam[0]][0];
        sceneclass = TableManager.GetSceneClassByID((int)mparam[0], 0);
        string sceneName = TableManager.GetSceneClassByID((int)mparam[0], 0).ResName;  // row.Value<string>("ResName");
        LoadSceneName = sceneName;
        GameObject.DontDestroyOnLoad(gameObject);
        async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        LoadRoleType = (int)mparam[1];
        ItemVisualType = (int)mparam[2];

        YKVList = new Dictionary<string, float>()
        {
            {"julu",-0.168f},
            {"taoyuan",20.00816f},
            {"HuLaoGuan",0.186157f},
            {"fb_wushenta",5.6f},
            {"HuLaoGuanfuben",-0.04260823f},
            {"zc_jiangxia",12.34f}
        };
    }


    void Update()
    {
        if (async != null && async.isDone)
        {
            LoadDone();
        }


        //BundleManager.BundleQueueLoadTick(this);

        TestLoopTime -= Time.deltaTime;
        if (TestLoopTime <= 0)
        {
            TestLoopTime = 3.5f;
            // ParentTestG.SetActive(false);
            //  ParentTestG.SetActive(true);
        }
    }

    void LoadDone()
    {
        // Destroy(GameObject.Find("UI Root"));
        async = null;
        LoadPlayer();
        LoadSkillBar();
        LoadOtherUI();
        ParentTestG = new GameObject("ParentTestG");
    }

    void LoadPlayer()
    {
        /*GameObject ObjPlayerRoot = (GameObject)GameObject.Instantiate(Resources.Load("Prefab/Model/PlayerRoot"));
        ResTestPlayer testPlayer = ObjPlayerRoot.AddComponent<ResTestPlayer>();
        testPlayer.Load(new Vector3(sceneclass.EntryX, YKVList[LoadSceneName], sceneclass.EntryZ), LoadRoleType, ItemVisualType, 0);
        this.ScenePlayer = testPlayer;
        testPlayer.RoleType = LoadRoleType;

        GameObject.Instantiate(Resources.Load("Prefab/EasyTouch"));*/
    }

    void LoadSkillBar()
    {

        //SkillBar = SGUIManager.Instance.Load<ResViewSkillBar>();
    }

    void LoadOtherUI()
    {
        /*UIButtonMessage AddNPCMsg = SkillBar.transform.Find("Camera/TL/Panel/AddNPC").gameObject.AddComponent<UIButtonMessage>();
        AddNPCMsg.target = gameObject;
        AddNPCMsg.functionName = "OnAddNPC";

        UIButtonMessage BackMsg = SkillBar.transform.Find("Camera/TL/Panel/Back").gameObject.AddComponent<UIButtonMessage>();
        BackMsg.target = gameObject;
        BackMsg.functionName = "OnBack";*/



    }

    public void OnAddNPC(GameObject go)
    {
        //≥ı ºªØNPC
        /*GameObject TestObj = (GameObject)Instantiate((GameObject)Resources.Load("Model/swordsman0_skin"));
        TestObj.transform.parent = ParentTestG.transform;
        TestObj.transform.position = this.ScenePlayer.transform.position;
        GameObject EffectObj = (GameObject)Instantiate((GameObject)Resources.Load("Effect/swordsman_skill10"));
        EffectObj.transform.parent = TestObj.transform;
        EffectObj.transform.localPosition = Vector3.zero;*/

    }

    public void OnBack(GameObject go)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ClientViewScene");
    }
}
