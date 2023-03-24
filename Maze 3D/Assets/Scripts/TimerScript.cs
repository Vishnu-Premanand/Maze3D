using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private float currentTime;
    public float startTime=100.00f;

    private bool isTimeStarted=false;

    [SerializeField]private TextMeshProUGUI timerText;
    [SerializeField]private TextMeshProUGUI startText;

    private void Start() {
        currentTime=startTime;
    }
    private void OnTriggerEnter(Collider other) {
        if(!isTimeStarted){

            isTimeStarted=true;
            
        }
    }
    private void Update() {
        if(isTimeStarted){
            currentTime-=1*Time.deltaTime;
            timerText.text=currentTime.ToString("f2");
            startText.enabled=false;
            timerText.enabled=true;
        }
    }
}
