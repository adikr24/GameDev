using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MoveMaleCharacter : MonoBehaviour
{

 [SerializeField] float _speed = 5f;
 [SerializeField] LayerMask _animLayerMask;
 
 Animator _animator;
 // public float gravity = -5;
 
 void Awake() => _animator = GetComponent<Animator>();
 
 void Upadate()
 {
	AimTowardMouse();
	float horizontal = Input.GetAxis("Horizontal");
	float vertical = Input.GetAxis("Vertical");
	
	Vector3 movement = new Vector3(horizontal, 0f, vertical);
	
	// Moving
	if (movement.magnitude > 0)
	{
		movement.Normalize();
		movement *= _speed * Time.deltaTime;
		transform.Translate(movement, Space.World);
	}
	
	//Animating
	float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
	float velocityX = Vector3.Dot(movement.normalized, transform.right);
	
	_animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
	_animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
 }
 
 void AimTowardMouse()
 {
	 Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	 if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _animLayerMask))
	 {
		 var _direction = hitInfo.point  - transform.position;
		 _direction.y = 0f;
		 _direction.Normalize();
		 transform.forward = _direction;
		 
	 }
 }

}
 