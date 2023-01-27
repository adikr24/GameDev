using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NineoneoneWhatsYourEmergency : MonoBehaviour
{
    // Start is called before the first frame update
	
	public AudioClip saw;
	
    void Start()
    {
       	 GetComponent<AudioSource>().playOnAwake = false;
         GetComponent<AudioSource>().clip = saw; 
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
			
     		GetComponent<AudioSource>().Play();
			//self_.SetActive(false);
		}
	}
	
}