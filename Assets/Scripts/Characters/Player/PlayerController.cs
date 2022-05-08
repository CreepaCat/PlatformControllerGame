using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//常规状态机写法
//缺点：当状态增加时，状态切换逻辑越来越复杂，不便于维护
public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    Rigidbody rigidBody;
    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClips;

    int playerScore;
    public int PlayerScore => playerScore;

    [SerializeField] private bool _isDead;
    public bool IsDead => _isDead;

    PlayerGroundDetector groundDetector;

    PlayerWallDetector wallDetector;

    public float MoveSpeed => Mathf.Abs(rigidBody.velocity.x);

    public float YSpeed => Mathf.Abs(rigidBody.velocity.y);

    [SerializeField] public int JumpTimes = 2;
    public int JumpCount;





    [SerializeField] public bool IsGrounded => groundDetector.IsGrounded;
    [SerializeField] public bool IsWalled => wallDetector.IsWalled;

    //Y轴速度小于0并且未着地说明在掉落
    public bool IsFalling => rigidBody.velocity.y < 0f;

    //public bool IsFalling => rigidBody.velocity.y <= 0f;

    public bool IsAirJump => input.Jump && JumpCount >= 1;

    //public bool IsWolfTiming =>

    //public bool IsJump => rigidBody.velocity.y > 0f;

   private void Awake() {
       input = GetComponent<PlayerInput>();
       rigidBody = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();

       groundDetector = GetComponentInChildren<PlayerGroundDetector>();
       wallDetector = GetComponentInChildren<PlayerWallDetector>();


       JumpCount = JumpTimes;
       playerScore = 0;
       _isDead = false;
   }

   private void Start() {
       //启用输入系统
       input.EnableGameplayInputs();

   }

  public void EnableCursor(){
     // input.EnableGameplayInputs();
     Cursor.lockState = CursorLockMode.Confined;
  }

   public void DisableCursor(){
    //input.DisableGameplayInputs();
    Cursor.lockState = CursorLockMode.Locked;
  }
   public void Move(float speed){
       //对于2D游戏，镜面翻转比旋转更自然
       if(input.Move){//input.Move为真时已经排除了 input.AxisX为0的情况
           transform.localScale = new Vector3(input.AxisX, 1f, 1f);
       }

       //以localScale区分左右前进方向
       SetVelocityX(speed * input.AxisX);

   }

   public void YAxisSpeed(float sensitive, float deltaTime){
       //Unity重力为-9.81

   // rigidBody.velocity += (Vector3.up + new Vector3(rigidBody.velocity.x, 0, 0) )* Physics.gravity.y * (sensitive -1) * deltaTime;
     rigidBody.velocity += ( Vector3.up  )* Physics.gravity.y * (sensitive -1) * deltaTime;

   }


   public void ResetJumpCount(){
       JumpCount = JumpTimes;
   }

   public void Jump(float jumpForce){

       SetVelocityY(jumpForce);

   }

   public void PlayAudio(int index){

       if(index < audioClips.Length){
           audioSource.PlayOneShot(audioClips[index]);
       }else{
           Debug.Log($"声音{index}播放错误");
       }

   }



   public void SetVelocity(Vector3 velocity){
       rigidBody.velocity = velocity;

   }

   public void SetVelocityX(float velocityX){
       rigidBody.velocity = new Vector3(velocityX ,rigidBody.velocity.y);

   }

   public void SetVelocityY(float velocityY){
       rigidBody.velocity = new Vector3(rigidBody.velocity.x,velocityY);

   }

  void OnTriggerEnter(Collider other){

       if(other.gameObject.CompareTag("Pickups")){
             Pickups item = other.gameObject.GetComponent<Pickups>();
             item.PlayAudio();
           // audioSource.PlayOneShot(item.audioClip);

             item.Destroy();
             AddScore(item.Points);

       }else  if(other.gameObject.CompareTag("Spike")){
            PlayAudio(1);
            //TODO:角色死亡，游戏结束
            _isDead = true;



       }



   }

   #region 计分



   public void AddScore(int sum){

       playerScore += sum;
      // Debug.Log("当前得分"+playerScore);

       if(playerScore < 10){
           GameRoot.Instance.playerScore_txt.text = "0" + playerScore.ToString();
       }else{
            GameRoot.Instance.playerScore_txt.text = playerScore.ToString();

       }
   }
   #endregion




}
