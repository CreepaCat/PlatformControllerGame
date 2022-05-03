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

    PlayerGroundDetector groundDetector;

    public float MoveSpeed => Mathf.Abs(rigidBody.velocity.x);

    public float YSpeed => Mathf.Abs(rigidBody.velocity.y);

    [SerializeField] public int JumpTimes = 2;
    public int JumpCount;


   

    [SerializeField] public bool IsGrounded => groundDetector.IsGrounded;
    
    //Y轴速度小于0并且未着地说明在掉落
    public bool IsFalling => rigidBody.velocity.y < 0f && !IsGrounded;

    public bool IsAirJump => input.Jump && JumpCount >= 1;

    //public bool IsWolfTiming => 

    //public bool IsJump => rigidBody.velocity.y > 0f;

   private void Awake() {
       input = GetComponent<PlayerInput>();
       rigidBody = GetComponent<Rigidbody>();
       groundDetector = GetComponentInChildren<PlayerGroundDetector>();

       JumpCount = JumpTimes;
   }

   private void Start() {
       //启用输入系统
       input.EnableGameplayInputs();
   }

   public void Move(float speed){
       //对于2D游戏，镜面翻转比旋转更自然
       if(input.Move){//input.Move为真时已经排除了 input.AxisX为0的情况
           transform.localScale = new Vector3(input.AxisX, 1f, 1f);
       }

       //以localScale区分左右前进方向
       SetVelocityX(speed * input.AxisX);

   }

//    public void Jump(){
//        if(input.Jump && JumpCount >= 1){
//            S
//        }
//    }

   public void ResetJumpCount(){
       JumpCount = JumpTimes;
   }

   public void Jump(float jumpForce){

       SetVelocityY(jumpForce);

   }

   

   public void SetVelocity(Vector3 velocity){
       rigidBody.velocity = velocity;

   }

   public void SetVelocityX(float velocityX){
       rigidBody.velocity = new Vector3(velocityX,rigidBody.velocity.y);

   }

   public void SetVelocityY(float velocityY){
       rigidBody.velocity = new Vector3(rigidBody.velocity.x,velocityY);

   }


}
