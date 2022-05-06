using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel 
{
   private UIType _uiType;

   GameObject _ActiveObj;


   public BasePanel(GameObject activeObj){
       activeObj = _ActiveObj;

   }
   //构造初始化
   public BasePanel(UIType uiType){
       _uiType = uiType;

   }
}
