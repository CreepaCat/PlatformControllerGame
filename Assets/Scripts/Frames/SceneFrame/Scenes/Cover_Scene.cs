using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Cover_Scene : BaseScene
{
   public readonly string scene_name = "Cover_Scene";

    public override void EnterScene()
    {
       // throw new System.NotImplementedException();
       Start_Scene scene = new Start_Scene();
       GameRoot.Instance.SceneLoader_Root.LoadScene(scene.scene_name, scene);
    }

    public override void ExitScene()
    {
        ///throw new System.NotImplementedException();
    }

    // public AnimationEvent  StartPanel(){

    // }
}
