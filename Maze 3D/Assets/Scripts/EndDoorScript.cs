using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorScript : MonoBehaviour
{
    private Collider col;
    private Animator anim;
    [SerializeField]public LevelWonScene levelWonScene;
    public AudioSource inGameAudio;
    private void Start() {
        {
            col=GetComponent<Collider>();
            anim=GetComponent<Animator>();
            

        }
    }
    private void OnTriggerEnter(Collider other) {
       if(other.gameObject.tag=="Player"){
         
         anim.SetBool("hasReachedEnd",true);
         levelWonScene.LevelWon();
         inGameAudio.enabled=false;

       }
       

    }
  
}
