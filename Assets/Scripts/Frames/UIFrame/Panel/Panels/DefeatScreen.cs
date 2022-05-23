using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DefeatScreen : BasePanel
{
    static string ui_name = "DefeatScreen";
    static string ui_path ="UI/Screens/DefeatScreen";

    static UIType uiType = new UIType(ui_name,ui_path);

    Button _reLevel;
    Button _backToMenu;



    public DefeatScreen():base(uiType){

    }

//重玩本关
    void ReLevel(){

        GameRoot.Instance.UIManager_Root.PopAll();
         GameRoot.Instance.InitPlayer(Vector3.zero);

        GameRoot.Instance.SceneLoader_Root.LoadScene(SceneManager.GetActiveScene().name,
                             GameRoot.Instance.SceneLoader_Root.dict_scenes[SceneManager.GetActiveScene().name]);
      //  GameRoot.Instance.InitCamera();




    }

    void BackToMenu(){


        GameRoot.Instance.UIManager_Root.PopAll();
        Start_Scene start_Scene = new Start_Scene();
        Debug.Log("回到菜单");
         //先加载玩家，再重置关卡
        GameRoot.Instance.InitPlayer(Vector3.zero);

        GameRoot.Instance.SceneLoader_Root.LoadScene(start_Scene.scene_name,start_Scene);




    }

      public override void OnStart()
    {
        base.OnStart();
        _reLevel =UIMethod.Instance.GetOrAddComponentInChildren<Button>(_ActiveObj,"ReLevel_Button");
        _backToMenu = UIMethod.Instance.GetOrAddComponentInChildren<Button>(_ActiveObj,"BackToMenu_Button");

        _reLevel.onClick.AddListener(ReLevel);
        _backToMenu.onClick.AddListener(BackToMenu);
    }

    public override void OnDestroy()
    {
         _reLevel.onClick.AddListener(ReLevel);
        _backToMenu.onClick.AddListener(BackToMenu);
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }



}
