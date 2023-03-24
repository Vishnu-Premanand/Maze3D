using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
   [SerializeField] Slider volumeSlider;

private void Start() {
    if(!PlayerPrefs.HasKey("menuVolume")){
        PlayerPrefs.SetFloat("menuVolume",4);
        Load();

    }
    else{
        Load();
    }

}
   public void ChangeVolume(){

    AudioListener.volume=volumeSlider.value;
    Save();
   }
   void Save(){
    
    PlayerPrefs.SetFloat("menuVolume",volumeSlider.value);

   }

   void Load(){
     PlayerPrefs.GetFloat("menuVolume");
   }
}
