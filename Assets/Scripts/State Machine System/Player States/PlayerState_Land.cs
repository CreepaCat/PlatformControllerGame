using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerState
{
    [SerializeField] float deceleration = 20f;
    public override void Enter()
    {
        base.Enter();
        player.ResetJumpCount();
    }

    public override void LogicUpdate()
    {
        if(input.Jump ){
             stateMachine.SwitchState(typeof(PlayerState_JumpUp));

        }else if(IsAnimationFinished){
            stateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        //着陆刹车
        currentSpeedX = Mathf.MoveTowards(currentSpeedX, 0 , deceleration * Time.deltaTime);
    }
}
