using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision col)
	{
		// Debug.Log("Cops hit");
		if(col.gameObject.tag == "Cops")
		{
//			Debug.Log("Now I am hit");
		}
		
	}
}
