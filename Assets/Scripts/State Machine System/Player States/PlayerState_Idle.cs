using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    [SerializeField] float deceleration = 20f;

    
    //状态进入
    public override void Enter()
    {
       // animator.Play("Idle");
        base.Enter();
        //currentSpeed = player.rigidBody.velocity.x;
        currentSpeedX = player.MoveSpeed;
      
        
    }

    //状态改变

    public override void LogicUpdate()
    {
        // if(Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed){
        //       stateMachine.SwitchState(typeof(PlayerState_Run));
        // }
        if(input.Move){
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }
        if(input.Jump ){
            stateMachine.SwitchState(typeof(PlayerState_JumpUp));
        }
        currentSpeedX = Mathf.MoveTowards(currentSpeedX, 0 , deceleration * Time.deltaTime);
      
    }
    public override void PhysicUpdate()
    {
        //减速时玩家没有按方向键，不能简单地用Move方法来停止
         player.SetVelocityX(currentSpeedX * player.transform.localScale.x);
    }

}
