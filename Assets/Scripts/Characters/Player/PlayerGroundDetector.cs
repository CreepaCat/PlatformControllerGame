using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;
    Collider[] colliders = new Collider[1];
    // public bool IsGrounded{
    //     get{
    //         return Physics.OverlapSphereNonAlloc(transform.position,detectionRadius,colliders,groundLayer) !=0 && ;
    //     }

    // }
    //地面检测
    public bool IsGrounded => Physics.OverlapSphereNonAlloc(transform.position,detectionRadius,colliders,groundLayer) != 0;

     void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,detectionRadius);
    }
}
