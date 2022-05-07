
using System.Text.RegularExpressions;
using UnityEngine;

public class BasePanel 
{
   public UIType _uiType;

   public GameObject _ActiveObj;

   //构造初始化
   public BasePanel(UIType uiType){
       _uiType = uiType;
   }

  public void SetActiveObj(GameObject activeObj){
        _ActiveObj = activeObj;

    }

   public virtual void OnStart(){
       _ActiveObj.SetActive(true);
       _ActiveObj.GetComponent<CanvasGroup>().interactable = true;

   }
    public virtual void OnEnable(){
         _ActiveObj.GetComponent<CanvasGroup>().interactable = true;
       
   }
    public virtual void OnDisable(){
         _ActiveObj.GetComponent<CanvasGroup>().interactable = false;
       
   }
    public virtual void OnDestroy(){
         _ActiveObj.GetComponent<CanvasGroup>().interactable =  false;
         _ActiveObj.SetActive(false);
       
   }
}
