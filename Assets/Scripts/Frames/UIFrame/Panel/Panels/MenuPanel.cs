using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : BasePanel
{
    static string ui_name = "MenuPanel";
    static string ui_path = "UI/Panels/MenuPanel";

   public static  UIType uiType = new UIType(ui_name,ui_path);

   public MenuPanel():base(uiType){


   }

   void Restart(){
       Level01_Scene level01 = new Level01_Scene();
      // this.OnDestroy();
       GameRoot.Instance.UIManager_Root.PopAll();
       GameRoot.Instance.SceneLoader_Root.LoadScene(level01.scene_name,level01);
   }

    public override void OnStart()
    {
        base.OnStart();
        UIMethod.Instance.GetOrAddComponentInChildren<Button>(_ActiveObj,"Restart_Button").onClick.AddListener(Restart);
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDestroy()
    {

        UIMethod.Instance.GetOrAddComponentInChildren<Button>(_ActiveObj,"Restart_Button").onClick.RemoveAllListeners();
        base.OnDestroy();
    }
}
