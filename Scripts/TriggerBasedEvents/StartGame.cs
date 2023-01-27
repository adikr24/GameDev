using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Material pinkMaterial;
	[SerializeField] private Material greenMaterial;
	[SerializeField] private Material carTailights;
	
	Material m_Material; 
	public GameObject Object;
	public GameObject Player;
	private GameObject Camera_;
	public GameObject car_;
	
	Vector3 newRotation  = new Vector3 (0,0,0);
	Vector3 newPos = new Vector3 (0,0,0);
	
	// Adjust Tailight //
	public GameObject tD1;
	public GameObject tD2;
	// Change color for tailight //
	public GameObject t1;
	public GameObject t2;
	public GameObject t3;
	public GameObject t4;

	// Start the Engine //
	public AudioClip startEngine;
	
	// Display Next Instructions //
	public GameObject FirstuiObject;
	public GameObject SeconduiObject;
//	public GameObject self_;
	
	void Start()
	{
		m_Material = GetComponent<Renderer>().material;
		m_Material = pinkMaterial;
		Object.GetComponent<Renderer>().enabled = true;
		Player = GameObject.Find("Player");
		// Get Engine Sound //
		GetComponent<AudioSource>().playOnAwake = false;
      	//GetComponent<AudioSource>().clip = startEngine;  
		
		SeconduiObject.SetActive(false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{	
			// Upon Collision with pink box -- Do the following , remove pink box and character
			// move camera behind // start car engine and play animation (change material of taillight) //
			GetComponent<Renderer>().material = greenMaterial;
			Object.GetComponent<Renderer>().enabled = false;
			Player.SetActive(false);
			Vector3 newPos = new Vector3(-403, 76, 6); 
			//Vector3 newRotation = new Vector3(1.76f, 80.015f,-5.121f);
			Vector3 newRotation = new Vector3(10,10,10);
			Camera_.transform.position = newPos;
			//Camera_.transform.rotation = newRotation;
			Camera_.transform.rotation = Quaternion.Euler(3.32f, 80.003f,-5.396f);
			// Make Camera Child of the player Car ///
			
			
			
			//Debug.Log("Tailights " + Tailights + Tailights.Length);
			
			/// destroy taillights
			tD1.GetComponent<Renderer>().enabled = false;
			tD2.GetComponent<Renderer>().enabled = false;
			// Wait for 2 seconds for the car to start //
			// StartCoroutine(ExampleCoroutine());
			t1.GetComponent<Renderer>().material = carTailights;
			t2.GetComponent<Renderer>().material = carTailights;
			t3.GetComponent<Renderer>().material = carTailights;
			t4.GetComponent<Renderer>().material = carTailights;
			// Play Audio for the car start //
			//startEngine.Play();
			// rotate to -- > 1.76, 80.015,-5.121;
			AudioSource startAudio = GetComponent<AudioSource>();
			GetComponent<AudioSource>().Play();
			// Activate the car //
			// Display.displays[3].Activate();
			car_.GetComponent<CarStabilizer>().enabled = true;
			car_.GetComponent<PlayerController>().enabled = true;
			Camera_.transform.parent = car_.transform;
			// Give Directions to the player -- Next steps //
			FirstuiObject.SetActive(false);
			SeconduiObject.SetActive(true);
			// StartCoroutine("WaitForSec");
		}	

//		Player[0].SetActive(false);
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
		{
			GetComponent<Renderer>().material = pinkMaterial;
		}
		
		
    }
	
	IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(10);

        //After we have waited 5 seconds print the time again.
       // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
	
	
	void Awake()
	{
		Camera_ = GameObject.Find("MainCamera");
		
	}
	
	
}
