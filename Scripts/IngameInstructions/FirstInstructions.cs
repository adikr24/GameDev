using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstInstructions : MonoBehaviour
{
    // Start is called before the first frame update
	
	// public AudioClip saw;
	public GameObject uiObject;
	public float slowdownfactor;
	public float slowdownlength;
	public GameObject self_;
	
    void Start()
    {
       	// GetComponent<AudioSource>().playOnAwake = false;
        // GetComponent<AudioSource>().clip = saw; 
		 uiObject.SetActive(false);
		 //slowdownfactor = 0.2f;
		 //slowdownlength = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Someone entered the arena ee");
    }
	
	void OnTriggerEnter(Collider other)
 	{
		//Debug.Log("Someone entered the arena");
		if (other.CompareTag("Player"))
		{
			
     		// GetComponent<AudioSource>().Play();
			uiObject.SetActive(true);
			StartCoroutine("WaitForSec");
			//StartCoroutine(WaitThenRestoreTime());
			//self_.SetActive(false);
		}
	}
	
	IEnumerator WaitForSec()
	{
		yield return new WaitForSeconds(3);
		Destroy(uiObject);
		//Destroy(gameObject);
	}
	
	private IEnumerator WaitThenRestoreTime()
	{
		Time.timeScale = slowdownfactor;
		yield return new WaitForSecondsRealtime(slowdownlength);
		Time.timeScale = 1f;
		//self_.SetActive(false);
	}
	


}