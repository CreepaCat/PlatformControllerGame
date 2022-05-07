using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsCube : MonoBehaviour
{

    public GameObject TipsPanel;
  //  Animator animator;

   void OnTriggerEnter(Collider other){
       if(other.gameObject.CompareTag("Player")){
           TipsPanel.SetActive(true);
           TipsPanel.GetComponent<Animator>().enabled = true;

       }

   }

   void OnTriggerExit(Collider other){
       if(other.gameObject.CompareTag("Player")){
           TipsPanel.SetActive(false);
           //TipsPanel.GetComponent<Animator>().enabled = true;

       }

   }
}
