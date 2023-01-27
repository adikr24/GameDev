using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBullet : MonoBehaviour
{
      //Drag in the Bullet Emitter from the Component Inspector.
	
	public Transform spawnPoint;
	public GameObject bullet;
	public float speed;
	public GameObject target;
	
	//public GameObject player;
	public GameObject self_;
	
	private int numBullet;
	private float currDistance;
	//private int initBullet;
	
	int initBullet =  100;
	float time;
	float timeDelay = 2f;
	// Make Shooting Bullet a StateMachine too
	
	enum BullState
	{
		Chase,
		Shoot,
		Reload	
	}
	
	BullState gunState;
	
	// Use this for initialization
    void Start ()
    {
		//Debug.Log("CODE STARTED --- > Shooting Bullets ");
		numBullet = initBullet;
		BullState gunState = BullState.Chase;
		time = 0f;
		timeDelay = 0.75f;
	}
    
	
    // Update is called once per frame
    void Update ()
    {
        switch(gunState)
		{
			case BullState.Chase:
			currDistance = ChaseDistance();
			
			if (currDistance < 35.0f )
			{
				gunState = BullState.Shoot;
			}
			break;
			
			case BullState.Shoot:
				//ShootBulletWithAmmo(numBullet);
				//
				//Debug.Log("Number of remaining Bullets" + numBullet + "CURR DISTANCE " + currDistance);
				if (numBullet < 0)
					{
						gunState = BullState.Reload;
					}
				else
					{
						time = time + 1 * Time.deltaTime;
						if (time >= timeDelay)
						{
							time = 0f;
							ShootBullet();
							numBullet -= 1;
						}
//						StartCoroutine(SprayBullet());
					}
			break;
			
			case BullState.Reload:
			currDistance = ChaseDistance();
			
			if (currDistance < 3.0f )
			{
				numBullet = initBullet;
				gunState = BullState.Shoot;
				//Debug.Log("Number of remaining Bullets" + numBullet + "CURR DISTANCE " + currDistance);
			}
			if (currDistance > 35.0f )
			{
				gunState = BullState.Chase;
			}
			break;
		}
    }
	
	
	
	
	private float ChaseDistance() // Cops to chase and not shoot if they're above 45 m in dist
	{
		float distance = Vector3.Distance(self_.transform.position, target.transform.position);
		return distance;
	}
	
	
	private void ShootBulletWithAmmo(int numBullet)
	{
		
		if (numBullet < 0)
		{
			gunState = BullState.Reload;
		}
		else
		{
			ShootBullet();
			numBullet -= 1;
		}
	}
	
	private void ShootBullet()
	{
		
		GameObject cB = Instantiate(bullet, spawnPoint.position, spawnPoint.transform.rotation);
		Rigidbody rb = cB.GetComponent<Rigidbody>();
		cB.transform.LookAt(target.transform);
		
		Vector3 relativePos = target.transform.position - spawnPoint.transform.position;
		Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
		
		rb.AddForce(cB.transform.forward * speed, ForceMode.Impulse);
		Destroy(cB, 0.75f);
		
		// addDelay();
		
	}
	
	IEnumerator SprayBullet()
	{
		while (true)
		{
			yield return new WaitForSeconds(2);
			ShootBullet();
		}		
	}
 
}
