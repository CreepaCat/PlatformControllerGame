using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraManager
{


        private GameObject _ActiveCamera;
        private Animator _animator;
        private Animation _animation;
        private CinemachineVirtualCamera _camera;
        //Cinemachine.LensSettingsPropertyAttribute
        private static CameraManager _instance;
        public static CameraManager Instance{
            get{
                 if(_instance == null)
                     Debug.Log("CameraManager单例获取失败");

                     return _instance;

            }
        }

        public CameraManager(){
           // _camera = camera;
           _instance = this;

        }
        /// <summary>
        /// 设置相机
        ///</summary>
        /// <param name="camera_Obj">虚拟相机物体</param>
        /// <param name="start_fov">fov参数</param>
        ///
        public void SetCamera(GameObject camera_Obj,int start_fov,GameObject follow){

             _ActiveCamera = camera_Obj;


             _camera = _ActiveCamera.GetComponent<CinemachineVirtualCamera>();

            if(!_ActiveCamera.GetComponent<Animator>()){

                  Debug.Log("相机动画播放器获取失败！ ");
                  return;

            }
              _animator = _ActiveCamera.GetComponent<Animator>();
              _animator.enabled = false;

              _camera.m_Lens.FieldOfView = start_fov;
              _camera.m_Follow = follow.transform;



        }

        // private void ResetAnimate(){

        // }

        public void SetCamera(GameObject camera_Obj,int start_fov){

              _ActiveCamera = camera_Obj;
              _camera = _ActiveCamera.GetComponent<CinemachineVirtualCamera>();
             _camera.m_Lens.FieldOfView = start_fov;

               _animator = _ActiveCamera.GetComponent<Animator>();
              _animator.enabled = false;
        }


        public void EnterGameAnima(){
            //_camera.m_Lens = star

           if(_animator){
               _animator.enabled = true;
               _animator.Play("CameraAway",0,0f);
               //_animator.Update(1);
           }


        }

}
