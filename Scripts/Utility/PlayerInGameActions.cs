using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInGameActions : MonoBehaviour
{
    // Start is called before the first frame update
	
	public float maxHealth = 100.0f;
	public float currentHealth;
	
	public PlayerHealth healthBar;
	
    void Start()
    {
        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
	
	void OnCollisionEnter(Collision col)
	{
		// Debug.Log("Cops hit");
		if(col.gameObject.tag == "Cops")
		{
			TakeDamage(3.0f);
		}
		
		if(col.gameObject.tag == "Bullet")
		{
			TakeDamage(0.5f);
		}
		
		if(col.gameObject.tag == "Humvee")
		{
			TakeDamage(5.0f);
		}
		if(col.gameObject.tag == "HeliCopter")
		{
			TakeDamage(3.0f);
		}
		if(col.gameObject.tag == "Pedestrians")
		{
			TakeDamage(25.0f);
		}
		
		
	}
	
	
	void TakeDamage(float damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
	}
	
	
	
}
