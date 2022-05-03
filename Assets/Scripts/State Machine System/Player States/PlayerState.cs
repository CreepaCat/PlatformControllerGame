using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    [SerializeField] string stateName;
    [SerializeField,Range(0,1f)]  float transitionDuration = 0.1f;

    //protected int JumpCount = 2;

     

   // LayerMask layerMask
    int stateHashName;

    float stateStartTime;


    protected Animator animator;

    protected PlayerInput input;

    protected PlayerController player;

    protected PlayerStateMachine stateMachine;

    protected float currentSpeedX;

    //判断当前动画是否播放完
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    protected float StateDuration => Time.time - stateStartTime;
    //土狼时间
    //  protected bool IsWolfTiming => FallDuration < WolfTime;
    //  protected float FallDuration => Time.time - fallingStartTime;

    //  protected float fallingStartTime;

    protected bool IsGroundOut;

    protected void GroundOut(bool IsGroundOut){
        this.IsGroundOut = IsGroundOut;

    }

    //初始化animator,input,stateMachine
    public void Initialize(Animator animator, PlayerInput input,PlayerController player, PlayerStateMachine stateMachine){
        this.animator = animator;
        this.input = input;
        this.player = player;
        this.stateMachine = stateMachine;

    }

    private void OnEnable() {
        stateHashName = Animator.StringToHash(stateName);

    }




    //接口的此种实现最常见
    public virtual void Enter()
    {
        //动画交叉淡化
        animator.CrossFade(stateHashName,transitionDuration);
        stateStartTime = Time.time;
        

    }

    public virtual void Exit()
    {
        
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
