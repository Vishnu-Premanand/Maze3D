using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController cc;
   private PlayerController PC;
   [SerializeField]private float speed=10f;
   [SerializeField]private float rotationSpeed=.25f;

   public Transform camTransform;

   private void OnEnable() {
    PC.Enable();
   }
   private void OnDisable() {
    PC.Disable();
   }
   private void Awake() {
    PC= new PlayerController();
    cc=GetComponent<CharacterController>();
    camTransform=Camera.main.transform;
   }

   private void Update() {
    
    Vector2 moveMent= PC.Player.Movement.ReadValue<Vector2>();
    Vector3 move= new Vector3(moveMent.x,0f,moveMent.y);
    move=camTransform.forward*move.z+camTransform.right*move.x;
    move.y=0f;
    cc.Move(move*speed*Time.deltaTime);
    if(moveMent!=Vector2.zero){
        float targetAngle= Mathf.Atan2(moveMent.x,moveMent.y)*Mathf.Rad2Deg+camTransform.eulerAngles.y;
        Quaternion rotation= Quaternion.Euler(0f,targetAngle,0f);
        transform.rotation=Quaternion.Slerp(transform.rotation,rotation,rotationSpeed);
    }

     
   }
}
