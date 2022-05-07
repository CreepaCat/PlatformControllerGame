using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRoot : MonoBehaviour
{
     private static GameRoot _instance;

   //  public GameObject Player_GameObject;
      public PlayerController player;
      PlayerStateMachine playerStateMachine;

      PlayerInput playerInput;

    public GameObject playerScore_obj;

    public Text playerScore_txt;

     public static GameRoot Instance{
         get{
             if(_instance == null){
                  Debug.Log("GameRoot 单例化失败");
                  return _instance;

             }
             return _instance;
         }
     }

    public Canvas canvas;

    private UIManager UIManager;

    public UIManager UIManager_Root => UIManager;

    private SceneLoader SceneLoader;

    public SceneLoader SceneLoader_Root => SceneLoader;

    

    void Awake() {

        if(_instance == null){

            _instance = this;

        }
        else{
            Destroy(this.gameObject);

        }
      

      //  canvas = UIMethod.Instance.FindCanvas(canvas.name);
        UIManager = new UIManager();
        SceneLoader = new SceneLoader();

        player = GameObject.Find("Player").GetComponent<PlayerController>();
        playerStateMachine =  GameObject.Find("Player").GetComponent<PlayerStateMachine>();

        playerScore_txt = UIMethod.Instance.GetOrAddComponent<Text>(playerScore_obj);
       


        playerInput = new PlayerInput();
       
        
    }

    private void Start() {

        DontDestroyOnLoad(this.gameObject);
        // if(playerStateMachine){
        //     playerStateMachine.enabled = false;
        // }
        //  if(playerController){
        //      playerController.EnableCursor();
        //     playerController.enabled = false;
        // }

        EnablePlayerController(false);

        UIManager_Root._canvas = UIMethod.Instance.FindCanvas(canvas.name);

     
        GameRoot.Instance.UIManager_Root.Push(new StartPanel());

        //第一个场景手动加入字典
        StartScene startScene = new StartScene();
        GameRoot.Instance.SceneLoader.dict_scenes.Add(startScene.scene_name,startScene);

        playerScore_obj.SetActive(false);
        // player.AddScore(0);
      
    }

     public void EnablePlayerController(bool flag){
         if(!flag){
             player.EnableCursor();
         }
         playerStateMachine.enabled = flag;
         player.enabled = flag;

     }


}
