using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Run", fileName ="PlayerState_Run")]
public class PlayerState_Run : PlayerState
{

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float acceleration = 10f;


    //土狼时间
      [SerializeField] public float WolfTime = 0.2f;
      bool IsWolfTiming => FallDuration < WolfTime;
      float FallDuration => Time.time - fallingStartTime;
      protected float fallingStartTime;
      bool startWolfTime;
      float tick;


    //状态进入
    public override void Enter()
    {
       // animator.Play("Run");
       base.Enter();
        //进入状态时记录当前水平速度
        //currentSpeed = player.rigidBody.velocity.x;
        currentSpeedX = player.MoveSpeed;
        startWolfTime = false;
    }

    //状态改变
    public override void LogicUpdate()
    {
         base.LogicUpdate();
        //取反
        // if(!(Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed)){
        //     stateMachine.SwitchState(typeof(PlayerState_Idle));
        // }
        if(!input.Move){
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
         if(input.Jump ){
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }



        //不操墙时坠落
        if(!player.IsGrounded && player.IsFalling ){
           // startWolfTime =true;

            //Debug.Log("开始掉落 : "+ base.fallingStartTime);
            stateMachine.SwitchState(typeof(PlayerState_Fall));
        }
         //DoWolfTime();
        //加速
        currentSpeedX = Mathf.MoveTowards(currentSpeedX,runSpeed, acceleration * Time.deltaTime);
       // player.SetVelocityX()




    }
    public override void PhysicUpdate()
    {
        //player.SetVelocityX(currentSpeed);
        player.Move(currentSpeedX);
    }


    // void DoWolfTime(){
    //      if(startWolfTime){
    //          tick = Time.time;
    //              fallingStartTime = Time.time;
    //              if(!IsWolfTiming){
    //                  // if(!input.Move)
    //                   stateMachine.SwitchState(typeof(PlayerState_Fall));
    //                   startWolfTime = false;

    //              }

    //         }

    // }


}
