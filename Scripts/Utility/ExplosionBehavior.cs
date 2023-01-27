using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    
	public GameObject exp;
	public float expForce, radius;
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag != "HeliCopter")
		{
		//Debug.Log(other.gameObject.tag);
		//Debug.Log(other.gameObject.name);
		GameObject _exp = Instantiate(exp, transform.position, transform.rotation);
		Destroy(_exp, 3);
		knockBack();
		Destroy(gameObject);
		}
	}
	
	void knockBack()
	{
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		
		foreach(Collider nearby in colliders)
		{
			Rigidbody rig = nearby.GetComponent<Rigidbody>();
			if(rig != null)
			{
				//Debug.Log("FORCE ADDED");
				rig.AddExplosionForce(expForce, transform.position, radius);
			}
		}	
	}
	
	
	
}
