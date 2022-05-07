using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01_Scene : BaseScene
{
  public readonly string scene_name = "Level01_Scene";

    public override void EnterScene()
    {
       // throw new System.NotImplementedException();
      GameObject.Find("Player").GetComponent<PlayerController>().DisableCursor();
     // GameManager.Instance.player.DisableCursor();
      GameRoot.Instance.EnablePlayerController(true);
      GameRoot.Instance.playerScore_obj.SetActive(true);
      GameRoot.Instance.player.AddScore(0);

    //  GameManager.Instance.playerScore_txt = GameObject.
    }

    public override void ExitScene()
    {
       // throw new System.NotImplementedException();
    }
}
