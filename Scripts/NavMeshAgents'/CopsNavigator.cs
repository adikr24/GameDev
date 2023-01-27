using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class CopsNavigator : MonoBehaviour
{
	public GameObject player;        //Public variable to store a reference to the player game object
    public GameObject self_;
	private Vector3 offset;
	UnityEngine.AI.NavMeshAgent agent;
	public bool col_;
	float distfromPlayer;
	Vector3 pos = new Vector3(0,0,0);
	public int FarthestPoint;
	private int wayPointNumber;
	
	// Patroling Cube location //
	private GameObject patrolcube;
	private Transform[] TransWaypoints;
	private GameObject[] waypoints;
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
		//Debug.Log("STARTED THE CODE");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		pos = player.transform.position;
		// agent.SetDestination(pos);
		col_ = false;
		AIState currentState = AIState.stayStatic;
		childObj = self_.transform.Find("MachineGun").gameObject;
		childObj.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {	
		//Debug.Log("UPDATED THE CODE");
		switch(currentState)
		{
		
			case AIState.stayStatic:
				checkDistance();
				findNextWayPoint();
				childObj.gameObject.SetActive(false);
				break;
			
			case AIState.patrol:
				checkDistance();
				if (agent.hasPath)
				{
					checkDistance();
				}
				else {	moveAround(findNextWayPoint()); }
				break;
				
			case AIState.chasePlayer:
				pos = player.transform.position;
				agent.SetDestination(pos);
				childObj.gameObject.SetActive(true);
				checkDistance();
				break;
			case AIState.chaseDiversion:
				chaseDiversion_();
				if (agent.hasPath)
				{
				//	Debug.Log("Chasing Diversion");
				}
				else
				{
					//Debug.Log("Reached Diversion - Switch state" + currentState);
					checkDistance();
					// currentState= AIState.chasePlayer;
				}
				break;			
			}
	}
		

	public UnityEngine.AI.NavMeshAgent chaseDiversion_()
	{
//		Debug.Log("Switched State chasing Diversion Now");
		Vector3 copPos = new Vector3 (0,0,0);
		copPos = player.transform.position;
		copPos.y = 0f;
		copPos.x += 10;
		copPos.z += 10;
		agent.SetDestination(copPos);
		col_ = false;
		return agent;
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
	
	public float checkDistance()
	{
		float distance = Vector3.Distance(self_.transform.position, player.transform.position);
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
	


//// Hummer Nav Functions ////

public UnityEngine.AI.NavMeshAgent playerCatch(Vector3 pos)
	{
		agent.SetDestination(pos);
		if (agent.hasPath)
		{	
			checkDistance();
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
		GameObject refPoint;
		getRandomWaypoint(out refPoint, out wayPointNumber);
		float currDist = Vector3.Distance(self_.transform.position, refPoint.transform.position);
		if (currDist > 4.0f)
		{
			currentState = AIState.patrol;
			// Debug.Log("CHANGING STATE");
			return refPoint;
		}
		// Debug.Log("RETURNIG NULL" + refPoint);
		return null;
	}
	
public void getRandomWaypoint(out GameObject return1, out int return2 )
	{
		
		finishfuncI = false;
		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("PatrolingWaypoint");
		
		TransWaypoints = new Transform[waypoints.Length];
		// float min_dist = 999999.99f;
		int num = Random.Range(0,waypoints.Length);
		float objdist = Vector3.Distance(self_.transform.position, waypoints[num].transform.position);
		closestWaypoint = waypoints[num];
		return1 = closestWaypoint;
		return2 = num;
		//return closestWaypoint;
	}
	
public void checkWayPointDistance()
	{
		GameObject refPoint = waypoints[wayPointNumber];
		float distance = Vector3.Distance(self_.transform.position, refPoint.transform.position);
		if (distance < 5.0f)
		{
			currentState = AIState.stayStatic;
		}
	}
	
}