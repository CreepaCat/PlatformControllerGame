using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerState
{

    // [SerializeField] float airSpeed = 2f;
    // [SerializeField] float airAcceleration = 5f;
      [SerializeField] public float WolfTime = 0.2f;
      bool IsWolfTiming => FallDuration < WolfTime;
      float FallDuration => Time.time - fallingStartTime; 

    [SerializeField] float airSpeed = 7f;
    [SerializeField] float airDeceleration = 5f;

     protected float fallingStartTime;
    public override void Enter()
    {
        base.Enter();
        fallingStartTime = Time.time;
       
    }

    public override void LogicUpdate()
    {
        if(player.IsGrounded){
            stateMachine.SwitchState(typeof(PlayerState_Land));
        }

        if(player.IsAirJump){
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));

        }
         Debug.Log("土狼时间：" + IsWolfTiming + ", FallDuration" + FallDuration + ",base.IsGroundOut：" + base.IsGroundOut);
         //Debug.Log("base.IsGroundOut：" + base.IsGroundOut);
         //FallDuration = Time.time - fallingStartTime;
        if(IsWolfTiming){
            //base.GroundOut(false);
            
            if(input.Move){
                 currentSpeedX = Mathf.MoveTowards(airSpeed, 0, airDeceleration * Time.deltaTime);

            }
            if(input.Jump && (player.JumpCount == player.JumpTimes)){
                stateMachine.SwitchState(typeof(PlayerState_JumpUp));

            }
        }
          
    }

    public override void PhysicUpdate()
    {
        if(IsWolfTiming)
         player.Move(currentSpeedX);
    }
}
