using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]private PlayerMovement playerMovement;
    public void GameOver(){

        gameObject.SetActive(true);
        playerMovement.enabled=false;

    }
   
}
