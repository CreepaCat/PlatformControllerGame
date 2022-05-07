using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader 
{
    private static SceneLoader _instance;

    public Dictionary<string, BaseScene> dict_scenes;
    public static SceneLoader Instance{
        get{
            if(_instance == null){
                Debug.Log("SceneLoader单例失败！");
                return _instance;
            }
                return _instance;
            
        }
    }

    public SceneLoader(){
        _instance = this;
        dict_scenes = new Dictionary<string, BaseScene>();
    }

    public void LoadScene(string scene_name,BaseScene baseScene){
       // SceneManager.GetActiveScene().name

       if(!dict_scenes.ContainsKey(scene_name)){
          // SceneLoader.Instance.
          dict_scenes.Add(scene_name,baseScene);
       }

       //加载新场景先关闭当前场景
       if(dict_scenes.ContainsKey(SceneManager.GetActiveScene().name)){
           dict_scenes[SceneManager.GetActiveScene().name].ExitScene();
       }

       #region load

    
       SceneManager.LoadScene(scene_name);
       dict_scenes[scene_name].EnterScene();


       #endregion



        baseScene.EnterScene();

    }
}
