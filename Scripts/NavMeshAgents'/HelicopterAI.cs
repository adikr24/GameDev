using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class HelicopterAI : MonoBehaviour
{

	UnityEngine.AI.NavMeshAgent agent;
    
	Vector3 pos = new Vector3(0,0,0);
	
	
	private int ammo;
	private int maxammo = 15;
	private float bombingRange;
	private float distance;
	
	public float speed;
	public GameObject self_;
	public GameObject target_;
	public GameObject reloadStation_;
	public GameObject Bomb;
	public int secondsToWait = 1;
	float time;
	float timeDelay = 2f;
	//private Vector3 posCal;
	
	
	public Transform spawnPoint;
	
	
	enum AIState
	{
		chasePlayer,
		reload
	}
	
	AIState currentState;
	
	
	// Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		pos = target_.transform.position;
		AIState currentState = AIState.chasePlayer;
		pos.y = 8.5f;
		agent.SetDestination(pos);
		//maxammo = 20;
		bombingRange = 35.0f;
		ammo = maxammo;
		time = 0f;
		timeDelay = 0.50f;
    }

    // Update is called once per frame
    void Update()
    {
     	//agent.SetDestination(pos);
		switch (currentState)
		{
			case AIState.chasePlayer:
		//	dropBombs();
			distance = Vector3.Distance(self_.transform.position, target_.transform.position);
			pos = target_.transform.position;
			pos.y = 8.5f;
			agent.SetDestination(pos);
			//agent.SetDestination(pos);
			
			distance = Vector3.Distance(self_.transform.position, target_.transform.position);
			
			if (distance < bombingRange)
			{
				
				if (ammo == 0){
				currentState = AIState.reload;
				
				}
				else{
				time = time + 1 * Time.deltaTime;
				if (time >= timeDelay)
				{
					time = 0f;
					dropBombs();
					ammo -= 1;
				}
				}				
			}
			
			break;
			
			case AIState.reload:
			agent.SetDestination(reloadStation_.transform.position);
			distance = Vector3.Distance(self_.transform.position, reloadStation_.transform.position); 
			if (distance < 30.0f)
			{
					ammo = maxammo;
					currentState = AIState.chasePlayer;
					//Debug.Log("MAX AMMO STATE CHANGE :"  + ammo );
			}
			break;
		}
    }
	
	
	private IEnumerator SpawnAfterDelay()
	{
		//Wait for specified time
		yield return new WaitForSecondsRealtime(secondsToWait);
		//Spawn the object
		dropBombs();
	}
	
	
	
	private void dropBombs()
	{
		if (ammo <= 0)
		{
			currentState = AIState.reload;
		}
		else
		{
			GameObject cb = Instantiate (Bomb, spawnPoint.position, spawnPoint.transform.rotation) ;
			Rigidbody rb = cb.GetComponent<Rigidbody>();
			cb.transform.LookAt(target_.transform);
			
			rb.AddForce(cb.transform.forward * speed, ForceMode.Impulse);
			Destroy(cb, 0.75f);
			ammo -=1;
		}	
	}
}
