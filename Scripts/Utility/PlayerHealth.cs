using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{

	public Slider slider;
	
	
	public void SetHealth(float health)
	{
		slider.value = health;
		if (health == 0) 
		{
			GameObject.Find("Player")
				.GetComponent<EquipmentManager>()
				.Reset();
			
			GameEnder.SetGameEnd(GameEndType.BUSTED);
			SceneManager.LoadScene("GameOver");
		}
	}
	
	
	public void SetMaxHealth(float health)
	{
		slider.maxValue = health;
		slider.value = health;
	}	
	
	public void HealthPickUp()
	{
		if (slider.value > 80.0f)
		{
			slider.value = 100.0f;
		}
		else
		{
			slider.value += 20.0f;
		}
	}
	
  
}
