using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{


public TrapScript trapScript;

public TimerScript timerScript;


public LevelWonScene levelWonScene;

   public void MainMenu(){

    SceneManager.LoadScene(0);
     trapScript.gameOver.gameObject.SetActive(false);
     timerScript.gameObject.SetActive(false);
     levelWonScene.gameObject.SetActive(false);
    
   }

    public void Play(){

        SceneManager.LoadScene(1);
    }
    public void Quit(){

        Application.Quit();
    }

    public void Level1(){

        SceneManager.LoadScene("Level1");
    }
    public void Restart(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        trapScript.gameOver.gameObject.SetActive(false);
            
        }
    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        levelWonScene.gameObject.SetActive(false);
        

    }    
        
    }

