using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
//using Cinemachine;

public class GameRoot : MonoBehaviour
{

  //  public CinemachineVirtualCamera virtualCamera;

     private static GameRoot _instance;

   //  public GameObject Player_GameObject;
   // public GameObject _ActiveCamera;
     [Header("虚拟相机配置")]
     public GameObject _ActiveVirtualCamera;
    public int cinemacine_fov;
      [Header("玩家物体")]

      public GameObject player_prefab;
       GameObject playerObject;
      public PlayerController player;
      PlayerStateMachine playerStateMachine;

      PlayerInput playerInput;

    public GameObject playerScore_obj;

    public Text playerScore_txt;

    [Header("关卡结束界面")]
    public GameObject DefeatScreen;

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

    private CameraManager CameraManager;
    public CameraManager CameraManager_Root => CameraManager;



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
        CameraManager = new CameraManager();

         //plyerObject = GameObject.Instantiate<GameObject>(player_prefab,transform);
        playerObject  = GameObject.FindGameObjectWithTag("Player");
        // Debug.Log("实例化玩家prefab");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        // player = plyerObject.GetComponent<PlayerController>();

        playerStateMachine =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();


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
        _ActiveVirtualCamera = UIMethod.Instance.FindGameObject("Virtual Camera Player Follow","VirtualCamera");

        GameRoot.Instance.CameraManager_Root.SetCamera(_ActiveVirtualCamera,cinemacine_fov,playerObject);

        GameRoot.Instance.UIManager_Root.Push(new StartPanel());



        //第一个场景手动加入字典
        Cover_Scene startScene = new Cover_Scene();
        GameRoot.Instance.SceneLoader.dict_scenes.Add(startScene.scene_name,startScene);

        playerScore_obj.SetActive(false);
        // player.AddScore(0);

    }



     public void EnablePlayerController(bool flag){

         player.EnableCursor();

         playerStateMachine.enabled = flag;
         player.enabled = flag;
         player.GetComponentInChildren<PlayerGroundDetector>().enabled = flag;

     }

     public void InitPlayer(Vector3 position){

       //  Destroy(this.plyerObject);

       //  Debug.Log("销毁玩家Clone");

        //player.IsInit = true;
        player.Init();
        playerStateMachine.InitState();

        playerObject.transform.localPosition = Vector3.zero;
        playerObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
        playerObject.transform.localScale = Vector3.one;

      //  plyerObject = GameObject.Instantiate<GameObject>(player_prefab,transform);
      //  Debug.Log("实例化玩家prefab");

       // player = plyerObject.GetComponent<PlayerController>();
      //  playerStateMachine =  plyerObject.GetComponent<PlayerStateMachine>();

     //   playerScore_txt = UIMethod.Instance.GetOrAddComponent<Text>(playerScore_obj);

        playerInput = new PlayerInput();
        //playerInput.playerInputActions = new PlayerInputActions();
       // playerInput.DisableGameplayInputs();

        EnablePlayerController(false);

        UIManager_Root._canvas = UIMethod.Instance.FindCanvas(canvas.name);

       // _ActiveVirtualCamera = UIMethod.Instance.FindGameObject("Virtual Camera Player Follow","VirtualCamera");

        GameRoot.Instance.CameraManager_Root.SetCamera(_ActiveVirtualCamera,cinemacine_fov);

        //InitS时第一个场景已经加入字典
        //Start_Scene startScene = new Start_Scene();
        //GameRoot.Instance.SceneLoader.dict_scenes.Add(startScene.scene_name,startScene);

        playerScore_obj.SetActive(false);


     }



}
