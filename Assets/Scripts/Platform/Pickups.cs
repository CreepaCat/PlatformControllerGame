using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Pickups : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] public AudioClip audioClip;
    [SerializeField] int points = 1;

    public int Points => points;

    static void PlayClipAtPoint(){

    }

    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(){

        if(audioSource == null){
             Debug.Log("找不到声音播放器！");
             return;
        }
          Debug.Log("通过PlayClipAtPoint播放！");
        //audioSource.PlayOneShot(audioClip);
        AudioSource.PlayClipAtPoint(audioClip,transform.position);
    }

    public void Destroy(){
        Destroy(this.gameObject);
    }

    // Coroutine MyDestroy(){
    //     this.gameObject.SetActive(false);

    //     //audioSource.clip.loadState


    // }

    // private void OnTriggerEnter(Collider other) {
    //     if(other.CompareTag("Player")){
    //         GameRoot.Instance.player.AddScore(points);
    //         audioSource.Play();
    //         Destroy(this.gameObject);

    //     }
    // }
}
