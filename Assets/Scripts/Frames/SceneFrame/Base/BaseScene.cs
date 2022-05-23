using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class BaseScene
{
    public BaseScene _ActiveScene;
  //  protected string scene_name;
    public abstract void EnterScene();
     // SetActiveScene();

    public abstract void ExitScene();

    public  void SetActiveScene(BaseScene scene){
            _ActiveScene = scene;
    }
}
