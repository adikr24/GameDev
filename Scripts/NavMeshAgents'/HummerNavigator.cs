using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class HummerNavigator : MonoBehaviour
{
	public GameObject player;        //Public variable to store a reference to the player game object
    public GameObject self_;
	private Vector3 offset;
	UnityEngine.AI.NavMeshAgent agent;
	public bool col_;
	float distfromPlayer;
	Vector3 pos = new Vector3(0,0,0);
	public int FarthestPoint;
	
	// Patroling Cube location //
	private GameObject patrolcube;
	private Transform[] TransWaypoints;
	private GameObject closestWaypoint;
	private bool finishfuncI;
	float currDistance;
	// private Rigidbody rb;
    // Start is called before the first frame update
	private GameObject childObj;
	enum AIState
	{
		stayStatic,
		patrol,
		chasePlayer,
		chaseDiversion	
	}
	
	AIState currentState;
	
    void Start()
    {
		// Debug.Log("Started the Code");
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		pos = player.transform.position;
		AIState currentState = AIState.stayStatic;
	}
	
	void Update()
    {	
// 		Debug.Log("UPDATED THE CODE");
		switch(currentState)
		{
		
			case AIState.stayStatic:
			checkDistance();
			findNextWayPoint();
			//Debug.Log("stayStatic");
			break;
			
			case AIState.patrol:
				checkDistance();
				//checkWayPointDistance();
				//Debug.Log("PatrolState");
				if (agent.hasPath)
				{
					checkDistance();
				}
				else {	moveAround(findNextWayPoint()); }
				break;
				
			case AIState.chasePlayer:
				pos = player.transform.position;
				//childObj.gameObject.SetActive(true);
				// checkDistance();
				playerCatch(pos);
				break;
			case AIState.chaseDiversion:
				chaseDiversion_();
				if (agent.hasPath)
				{ 				} else
				{ checkDistance();	}
				break;			
			}
	}
	
	public UnityEngine.AI.NavMeshAgent playerCatch(Vector3 pos)
	{
		//Debug.Log("ENTERING FUNCTION PLAYERCATCH");
		agent.SetDestination(pos);
		if (agent.hasPath)
		{	
			Debug.Log("PathSet I");
			checkDistance();
		}
		else
		{
//			Debug.Log("PathSet");
//			agent.SetDestination(pos);
		}
		return agent;
	}
	
	public UnityEngine.AI.NavMeshAgent moveAround(GameObject refPoint)
	{
		if (agent.hasPath)
		{
			checkWayPointDistance();	
		}
		else 
		{
			agent.SetDestination(refPoint.transform.position);	
		}
		return agent;
	}
	
	public GameObject findNextWayPoint()
	{
		//GameObject refPoint = getClosestWaypoint();
		GameObject refPoint = getRandomWaypoint();
		float currDist = Vector3.Distance(self_.transform.position, refPoint.transform.position);
		//agent.SetDestination(refPoint.transform.position);
		if (currDist > 4.0f)
		{
			currentState = AIState.patrol;
			// Debug.Log("CHANGING STATE");
			return refPoint;
		}
		// Debug.Log("RETURNIG NULL" + refPoint);
		return null;
	}

//	public  closestPatrolPoint()
	public GameObject getRandomWaypoint()
	{
		
		finishfuncI = false;
		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("PatrolingWaypoint");
		
		TransWaypoints = new Transform[waypoints.Length];
		// float min_dist = 999999.99f;
		int num = Random.Range(0,6);
		float objdist = Vector3.Distance(self_.transform.position, waypoints[num].transform.position);
		if (objdist < 5.0f)
		{
			int numII = Random.Range(0,6);
			closestWaypoint = waypoints[numII];
		}
		else
		{
			closestWaypoint = waypoints[num];
		}
		
		return closestWaypoint;
	}


	public GameObject getClosestWaypoint()
	{
//		Debug.Log("AWAKE FUNCTION");
		finishfuncI = false;
		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("PatrolingWaypoint");
		
		//Debug.Log("Waypoints"  + waypoints.Length);
		TransWaypoints = new Transform[waypoints.Length];
		float min_dist = 99999.99f;
		for (int i = 0; i < waypoints.Length; i++)
		{
			TransWaypoints[i] = waypoints[i].transform;
			// objdist = waypoints[i].transform.position
			float objdist = Vector3.Distance(self_.transform.position, waypoints[i].transform.position);
		//	Debug.Log("WAYPOINT DISTANCE ---> " + objdist + min_dist);
			if (objdist < min_dist)
			{
				if (objdist  > 5.0f)
				{
					min_dist = objdist;
					closestWaypoint = waypoints[i];
			//		Debug.Log("2nd Closest Waypoint  -----> " + closestWaypoint);
				}
			}
		}
//		Debug.Log("Closest Waypoint  -----> " + closestWaypoint);
		finishfuncI = true;
		return closestWaypoint;
	}
	

	
	public void checkWayPointDistance()
	{
//		GameObject refPoint = getClosestWaypoint();
		GameObject refPoint = getRandomWaypoint();
		float distance = Vector3.Distance(self_.transform.position, refPoint.transform.position);
	//	Debug.Log("Print Distance => " + distance);
		if (distance < 4.0f)
		{
	//		Debug.Log("SWITCHED TO STATIC");
			currentState = AIState.stayStatic;
		}
	}




	void OnCollisionEnter(Collision col)
	{
		// Debug.Log("Cops hit");
		if(col.gameObject.tag == "Player")
		{
	//		Debug.Log("Hit the Player");
			currentState = AIState.chaseDiversion;
		}
	}


////////////////////////////////////////////////


	public UnityEngine.AI.NavMeshAgent chaseDiversion_()
	{
		Vector3 copPos = new Vector3 (0,0,0);
		copPos = player.transform.position;
		copPos.y = 0f;
		copPos.x += 10;
		copPos.z += 10;
		agent.SetDestination(copPos);
		col_ = false;
		return agent;
	}
	

	public float checkDistance()
	{
		float distance = Vector3.Distance(self_.transform.position, player.transform.position);
		//Debug.Log("Print Distance => " + distance);
		if (distance > FarthestPoint)
		{
			currentState = AIState.stayStatic;
		}
		if (distance <= FarthestPoint)
		{
			currentState = AIState.chasePlayer;
		}
		return distance;
	}

}