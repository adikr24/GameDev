using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToNYCScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
	
    private void OnTriggerEnter(Collider other)
    {	
		Debug.Log("Player Entered");
		Debug.Log("Collision Detected");
		SceneManager.LoadScene("AlphaScene");
        Time.timeScale = 1f;;
        if (other.CompareTag("PlayerCar"))
		{	
			Debug.Log("Player entered the scene");
			SceneManager.LoadScene("AlphaScene");
        	Time.timeScale = 1f;;
		}
    }
	
	
}
