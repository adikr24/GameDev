using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called before the first frame update
	
	public PlayerHealth healthBar;
	public GameObject self_;
	public AudioSource audioSource;
	//public int currentHealth;
	
	void OnTriggerEnter(Collider col)
	{
		// Debug.Log("Collision Detected !!");
		// Debug.Log (col.gameObject.tag);
		if(col.CompareTag("Player"))
		{
			// Debug.Log("player Entered");
			healthBar.HealthPickUp();
			audioSource.Play();
			Destroy(self_, 0.35f);
			//self_.SetActive(false);
		}
		
	}
	

	
	
	
}
