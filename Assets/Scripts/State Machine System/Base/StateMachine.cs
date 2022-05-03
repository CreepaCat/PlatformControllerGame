using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
        IState currentState;

        //状态字典表
        protected Dictionary<System.Type, IState> stateTable;

        //状态机的逻辑更新和物理更新分别在不同地方进行
        void Update(){
            currentState.LogicUpdate();
        }

        void FixedUpdate() {
         currentState.PhysicUpdate();
        }
        //状态进入
         protected void SwitchOn(IState newState){
            currentState = newState;
            currentState.Enter();

        }

         public void SwitchState(IState newState){
            currentState.Exit();
            SwitchOn(newState);

        }
        public void SwitchState(System.Type newStateType){
            SwitchState(stateTable[newStateType]);

        }
}
