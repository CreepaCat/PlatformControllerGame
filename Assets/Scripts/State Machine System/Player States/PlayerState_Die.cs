using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Die", fileName ="PlayerState_Die")]
public class PlayerState_Die : PlayerState
{

     [SerializeField] float deceleration = 20f;
    public override void Enter()
    {
        base.Enter();

        currentSpeedX = player.MoveSpeed;
      //  stateMachine.SwitchState(typeof(PlayerState_Die));
      //TODO:禁用输入

    }

    public override void LogicUpdate()
    {
        //刹车
        currentSpeedX = Mathf.MoveTowards(currentSpeedX, 0 ,deceleration * Time.time);


       // base.LogicUpdate();
       if(IsAnimationFinished){
          //  stateMachine.SwitchState(typeof(PlayerState_Idle));
           //TODO:调用游戏结束方法
       }

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        player.SetVelocityX(currentSpeedX);
    }
}
