
using UnityEngine;


public class TrapScript : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer meshRenderer;
    [SerializeField]
    private Collider col;

    public GameOverScreen gameOver;
    public TimerScript timerScript;
    
     

     private void Start() {
      
     }

    private void OnTriggerEnter(Collider other) {
      if(other.gameObject.tag=="Player"){
        meshRenderer.enabled=false;
        col.isTrigger=true;
        
      }
    }
    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag=="Player"){
          
          meshRenderer.enabled=true; 
          col.isTrigger=false;
          gameOver.GameOver();
          timerScript.gameObject.SetActive(false);
          

        }
        
    }
}
