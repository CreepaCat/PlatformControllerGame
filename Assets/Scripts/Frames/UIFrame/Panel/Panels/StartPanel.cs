
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class StartPanel : BasePanel
{
     static string _name = "StartPanel";
     static string _path = "UI/Panels/StartPanel";

    public static UIType uiType = new UIType(_name,_path);

  //  private List<Button> listener_btns;

    PlayerInput playerInput; 

   public StartPanel():base(uiType){
       //listener_btns = new List<Button>();

   }

   void OpenMenu(){
       GameRoot.Instance.UIManager_Root.Pop();
       GameRoot.Instance.UIManager_Root.Push(new MenuPanel());
   }
   
  

  public override void OnStart()
    {    //动态绑定按钮事件
         UIMethod.Instance.GetOrAddComponentInChildren<Button>(_ActiveObj,"Start_Button").onClick.AddListener(OpenMenu);
         playerInput = new PlayerInput();
         
        base.OnStart();
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
        UIMethod.Instance.GetOrAddComponentInChildren<Button>(_ActiveObj,"Start_Button").onClick.RemoveAllListeners();
        base.OnDestroy();
    }


 
}
