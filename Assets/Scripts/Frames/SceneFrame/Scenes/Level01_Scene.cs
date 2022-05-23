using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01_Scene : BaseScene
{
  public readonly string scene_name = "Level01_Scene";

    public override void EnterScene()
    {
       // throw new System.NotImplementedException();
      GameRoot.Instance.player.DisableCursor();
     // GameManager.Instance.player.DisableCursor();
      GameRoot.Instance.EnablePlayerController(true);//启用玩家输入
      GameRoot.Instance.playerScore_obj.SetActive(true);
      GameRoot.Instance.player.AddScore(0);//初始化玩家分数

      GameRoot.Instance.CameraManager_Root.EnterGameAnima();//相机动画
    //  GameManager.Instance.playerScore_txt = GameObject.
    }

    public override void ExitScene()
    {
       // throw new System.NotImplementedException();
    }
}
