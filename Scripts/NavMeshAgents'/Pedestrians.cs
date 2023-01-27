using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class Pedestrians : MonoBehaviour
{
	NavMeshAgent agent;
	public GameObject player_;
	
	public GameObject waypoint1;
	public GameObject waypoint2;
	public GameObject waypoint3;
	public GameObject waypoint4;
	
	//public float expForce, radius;
    // Start is called before the first frame update
	enum AIState
	{
		wp1,
		wp2,
		wp3,
		wp4
	}
	
	AIState currentState;
	void Start()
    {
        agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(waypoint1.transform.position);
    }
	

    // Update is called once per frame
    void Update()
    {
		
		
		float distObject = Vector3.Distance(player_.transform.position , waypoint1.transform.position );
		//Debug.Log("ORIGINS PATH IS :"  + origin_.transform.position);
		if ((Mathf.Abs(distObject) < 3.5f ))
		{
			//player_.transform.position = origin_.transform.position;
			agent.SetDestination(waypoint2.transform.position);
		}
    	
		float distObjectII = Vector3.Distance(player_.transform.position , waypoint2.transform.position );
		//Debug.Log("ORIGINS PATH IS :"  + origin_.transform.position);
		if ((Mathf.Abs(distObjectII) < 3.5f ))
		{
			//player_.transform.position = origin_.transform.position;
			agent.SetDestination(waypoint3.transform.position);
		}
		
		float distObjectIII = Vector3.Distance(player_.transform.position , waypoint3.transform.position );
		//Debug.Log("ORIGINS PATH IS :"  + origin_.transform.position);
		if ((Mathf.Abs(distObjectIII) < 3.5f ))
		{
			//player_.transform.position = origin_.transform.position;
			agent.SetDestination(waypoint4.transform.position);
		}

		float distObjectIV = Vector3.Distance(player_.transform.position , waypoint4.transform.position );
		//Debug.Log("ORIGINS PATH IS :"  + origin_.transform.position);
		if ((Mathf.Abs(distObjectIV) < 3.5f ))
		{
			//player_.transform.position = origin_.transform.position;
			agent.SetDestination(waypoint1.transform.position);
		}
	}
	
	private void OnCollisionEnter(Collision other)
	{
		Debug.Log("Collision Detected");
		if (other.gameObject.tag == "Player")
		{
		Destroy(gameObject);
		}
	}
	
	
		
	
}
