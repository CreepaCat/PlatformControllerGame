using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{

    [SerializeField] float jumpForce = 10f;

    [SerializeField] float airSpeed = 7f;
    [SerializeField] float airDeceleration = 5f;

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(jumpForce);
        player.JumpCount --;
    }

    public override void LogicUpdate()
    {
         if(player.IsFalling){
             stateMachine.SwitchState(typeof(PlayerState_Fall));
         }
         //跳跃撞墙调整
         if(input.StopJump && player.IsGrounded){
             stateMachine.SwitchState(typeof(PlayerState_Idle));
         }
        if(player.IsAirJump){
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));

        }
         //滞空调整
         if(input.Move){
             //airSpeed = player.YSpeed;
             currentSpeedX = Mathf.MoveTowards(airSpeed, 0, airDeceleration * Time.deltaTime);
            //currentSpeed = player.YSpeed * 2f;
         }
         
        
    }

    public override void PhysicUpdate(){
        player.Move(currentSpeedX);

    }

  
}
