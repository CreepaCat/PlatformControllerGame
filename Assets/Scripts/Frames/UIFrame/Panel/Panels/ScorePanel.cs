using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : BasePanel
{
     static string ui_name = "ScorePanel";
    static string ui_path = "UI/Panels/ScorePanel";

   public static  UIType uiType = new UIType(ui_name,ui_path);

   public ScorePanel():base(uiType){


   }


    public override void OnStart()
    {
        base.OnStart();
        Text score_txt = UIMethod.Instance.GetOrAddComponentInChildren<Text>(GameRoot.Instance.canvas.gameObject , "Score_Text ");
        GameRoot.Instance.playerScore_txt = score_txt;

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
        base.OnDestroy();
    }
}
