using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;
    Collider[] colliders = new Collider[1];

    [SerializeField] Transform[] Sensors;

    [SerializeField] private bool _isGrounded;

    public bool IsGrounded => GroundDetect();


    void OnEnable(){
        Init();
    }
    void Init(){
       Sensors =  gameObject.GetComponentsInChildren<Transform>();

    }
   public bool GroundDetect(){
       _isGrounded = false;
       for (int i = 1; i < Sensors.Length; i++)
       {
          // OnDrawGizmos(Sensors[i].transform.position);

           if(Physics.OverlapSphereNonAlloc(Sensors[i].position,detectionRadius,colliders,groundLayer) != 0){
               _isGrounded = true;

           }
       }
       return _isGrounded;
   }
   // public bool IsGrounded => Physics.OverlapSphereNonAlloc(transform.position,detectionRadius,colliders,groundLayer) != 0;

      void OnDrawGizmos() {
            Gizmos.color = Color.green;
            for (int i = 0; i < Sensors.Length; i++){

               Gizmos.DrawWireSphere(Sensors[i].transform.position,detectionRadius);

            }

     }
}
