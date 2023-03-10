using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MaleCharacterController : MonoBehaviour
{
 public float speed = 0.1f;
 // public float gravity = -5;
 
 float velocityY = 0; 
 
 CharacterController controller;
 
 void Start()
 {
     controller = GetComponent<CharacterController>();
 }
 
 void Update()
 {
 
 	float xDirection = Input.GetAxis("Horizontal");
	float zDirection = Input.GetAxis("Vertical");

	Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
	
	transform.position += moveDirection * speed;
 }	
}