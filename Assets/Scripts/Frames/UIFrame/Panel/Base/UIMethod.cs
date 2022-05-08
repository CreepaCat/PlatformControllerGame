using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMethod
{
    private static UIMethod _instance;

    public static UIMethod Instance{
        get{
            if(_instance == null)
                return new UIMethod();
            else
                return _instance;
        }
    }

    public UIMethod(){
        _instance = this;
    }

//动态获取Canvas
      public Canvas FindCanvas(string name){
         Canvas[] canvases = GameObject.FindObjectsOfType<Canvas>();

         foreach (var can in canvases)
         {
             if(can.name == name){
                 return can;
             }
         }

         Debug.Log("没有找到Canvas!");
         return null;

    }

    //动态获取虚拟相机
    /// <summary>
    /// 查找游戏物体
    /// </summary>
    /// <param name="name">要查找物体的名称</param>
    /// <param name="tag">要查找物体的标签</param>
    /// <returns></returns>
    public GameObject FindGameObject(string name, string tag){

        GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);

        foreach (var obj in objs)
        {
            if(obj.name == name)
            return obj;
        }
         Debug.Log($"没有找到{name  + tag}!");
         return null;

    }


    public T GetOrAddComponent<T>(GameObject gameObject) where T: UnityEngine.Component{

       // T[] objs = GameObject.FindObjectsOfType<T>();
        if(gameObject.GetComponent<T>() == null){
            gameObject.AddComponent<T>();
        }

        return gameObject.GetComponent<T>();

    }

    public T GetOrAddComponentInChildren<T>(GameObject gameObject, string ui_name) where T : UnityEngine.Component{

       T[] objs = gameObject.GetComponentsInChildren<T>();
       foreach (var obj in objs)
       {
           if(obj.name == ui_name)
           return obj;
       }

       gameObject.AddComponent<T>();
       return gameObject.GetComponent<T>();

    }



}
