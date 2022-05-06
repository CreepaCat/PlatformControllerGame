using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallDetector : MonoBehaviour
{
    [SerializeField] Collider playerCollider;
    [SerializeField]  float detectionRadius = 0.1f;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] GameObject[] Sensors;
    [SerializeField] private bool _isWalled;

    Collider[] detectResultColliders = new Collider[1];

    
    public bool IsWalled => WallDetect();
   


    public bool WallDetect(){
        _isWalled = false;
        for (int i = 0; i < Sensors.Length; i++)
        {
            if(Physics.OverlapSphereNonAlloc(Sensors[i].transform.position, detectionRadius, detectResultColliders, wallLayer)!=0){
                _isWalled = true;
            }
        }

        return _isWalled;



    }

    void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        for (int i = 0; i < Sensors.Length; i++){
            Gizmos.DrawWireSphere(Sensors[i].transform.position,detectionRadius);
        }

    }

}
