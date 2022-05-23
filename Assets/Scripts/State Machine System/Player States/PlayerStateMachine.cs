using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    //玩家状态对象
    // public PlayerState_Idle idleState;
    // public PlayerState_Run runState;

    //玩家状态数组,编辑器拖拽赋值
    [SerializeField] PlayerState[] states;
    Animator animator;
    PlayerInput input;
    PlayerController player;

    void Awake() {
        animator = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInput>();
        player = GetComponent<PlayerController>();

        //do player statets initialization here.
        //在使用，每个状态都必须初始化
        // idleState.Initialize(animator,this);
        // runState.Initialize(animator, this);
        stateTable = new Dictionary<System.Type, IState>();//字典使用前需new对象
        foreach (PlayerState state in states)
        {
            state.Initialize(animator,input,player,this);
            stateTable.Add(state.GetType(), state);
        }

    }

    void Start(){
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }

    public void InitState(){
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }

    private void OnEnable() {
         animator = GetComponentInChildren<Animator>();
        input = GetComponent<PlayerInput>();
        player = GetComponent<PlayerController>();

        stateTable = new Dictionary<System.Type, IState>();//字典使用前需new对象
        foreach (PlayerState state in states)
        {
            state.Initialize(animator,input,player,this);
            stateTable.Add(state.GetType(), state);
        }

         SwitchOn(stateTable[typeof(PlayerState_Idle)]);

    }

    public void Init(){
        // animator = GetComponentInChildren<Animator>();
        // input = GetComponent<PlayerInput>();
        // player = GetComponent<PlayerController>();
      // player = GameRoot.Instance.player;

        //do player statets initialization here.
        //在使用，每个状态都必须初始化
        // idleState.Initialize(animator,this);
        // runState.Initialize(animator, this);

        stateTable = new Dictionary<System.Type, IState>();//字典使用前需new对象
        foreach (PlayerState state in states)
        {
            state.Initialize(animator,input,player,this);
            stateTable.Add(state.GetType(), state);
        }

         SwitchOn(stateTable[typeof(PlayerState_Idle)]);

    }

}
