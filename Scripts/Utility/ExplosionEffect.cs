using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    // Start is called before the first frame update
	public ParticleSystem ps;
	
	
	private GameObject gms;
    void Start()
    {
        //explosion = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
//        Debug.Log("Touched the Ground Update");
		Debug.Log(gms);
		//Debug.Log(ps);
		
		
    }
	
	void Awake()
	{
		gms = GameObject.Find("ExplodingBomb");
		//ParticleSystem ps = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
	}
	
	
	void OnCollisionEnter(Collision col)
	{
		Debug.Log("Touched the Ground !!");
		ps.Play();
		
	}



}

