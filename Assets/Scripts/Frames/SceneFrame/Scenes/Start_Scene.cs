using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Scene : BaseScene
{

    public readonly string scene_name = "Start_Scene";
    public override void EnterScene()
    {
        //throw new System.NotImplementedException();
        //GameRoot.Instance.player.
        GameRoot.Instance.UIManager_Root.Push(new StartPanel());
        Cursor.lockState = CursorLockMode.None;

    }

    public override void ExitScene()
    {
        //throw new System.NotImplementedException();
       //  GameRoot.Instance.EnablePlayerController(true);

    }
}
