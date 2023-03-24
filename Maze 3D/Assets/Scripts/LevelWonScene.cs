using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWonScene : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    public TimerScript timerScript;

    

   public void LevelWon(){

    gameObject.SetActive(true);
    playerMovement.enabled=false;
    timerScript.gameObject.SetActive(false);
    
   }
}
