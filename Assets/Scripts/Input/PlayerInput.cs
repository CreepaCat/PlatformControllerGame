using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    //按键状态赋值
    public Vector2 axes => playerInputActions.GamePlay.Axes.ReadValue<Vector2>();

    public bool Jump => playerInputActions.GamePlay.Jump.WasPressedThisFrame();
    public  bool StopJump => playerInputActions.GamePlay.Jump.WasReleasedThisFrame();

    public bool JumpHold => playerInputActions.GamePlay.Jump.IsPressed();

    public  float AxisX => axes.x;

    public  bool Move => AxisX != 0f;

    void Awake(){
       
        playerInputActions = new PlayerInputActions();
    }

  //输入系统初始化
   public void EnableGameplayInputs(){
       //启用输入系统
       playerInputActions.GamePlay.Enable();
       //由于此项目不用鼠标左键，所以先锁定
       Cursor.lockState = CursorLockMode.Locked;
   }
}
