using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/JumpUp", fileName = "PlayerState_JumpUp")]
public class PlayerState_JumpUp : PlayerState
{

    [SerializeField] float jumpForce = 10f;

    [SerializeField] float airSpeed = 7f;
    [SerializeField] float airDeceleration = 5f;

    [SerializeField] float LowJump = 150f;
    [SerializeField] float HightJump = 1.5f;

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(jumpForce);
        //播放音效
        GameRoot.Instance.player.PlayAudio(0);
        player.JumpCount --;
    }

    public override void LogicUpdate()
    {
         base.LogicUpdate();
         if(player.IsFalling){
             stateMachine.SwitchState(typeof(PlayerState_Fall));
         }
         //卡墙坠落
        //  if(input.Move && (currentSpeedX == 0)){
        //      stateMachine.SwitchState(typeof(PlayerState_Fall));

        //  }
        if(player.IsWalled && !player.IsGrounded){
            // stateMachine.SwitchState(typeof(PlayerState_Fall));
            // player.YAxisSpeed(10 * HightJump , Time.deltaTime);
            //if(player.YSpeed < 0.5f)

        }



         //跳跃撞墙调整
         if(player.IsGrounded && (player.YSpeed == 0) && player.IsWalled)
          //if(player.IsGrounded )
             stateMachine.SwitchState(typeof(PlayerState_Land));

        if(player.IsAirJump){
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));

        }


         //滞空调整
         if(input.Move ){
            // if(currentSpeedX == 0f ){
            //      stateMachine.SwitchState(typeof(PlayerState_Fall));

            // }
            // Debug.Log("是否触地："+ player.IsGrounded);
             currentSpeedX = Mathf.MoveTowards(airSpeed, 0, airDeceleration * Time.deltaTime );
            //currentSpeed = player.YSpeed * 2f;
         }

        /// <summary>
        /// 长按大跳
        /// </summary>
         if(input.JumpHold ){

             player.YAxisSpeed(HightJump,Time.deltaTime);

         }
         if(input.StopJump ){
              player.YAxisSpeed(LowJump , Time.deltaTime);

         }
        //  if(input.StopJump){
        //      player.YAxisSpeed(1 , Time.deltaTime);
        //  }



    }

    public override void PhysicUpdate(){
        player.Move(currentSpeedX);
        // if(input.Jump)
        // player.YAxisSpeed(JumpSensitive);

    }


}
