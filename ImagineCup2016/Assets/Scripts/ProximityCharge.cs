﻿using UnityEngine;
using System.Collections;

public class ProximityCharge : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    public int speed;
    public int wanderSpd;
    public int acceleration;
    public int proximity;

    public bool canWander;//tells if this AI can wander
    public WanderScript ws;


	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.acceleration = acceleration;
        ws = this.GetComponent<WanderScript>();
<<<<<<< HEAD

        player = GameObject.FindGameObjectWithTag("Player");

=======
        player = GameObject.FindGameObjectWithTag("Player");
>>>>>>> 0054a2462ffc1331e887528a4b69bae300bcb9ad
    }
	
	// Update is called once per frame
	void Update () {
        if(canWander==true)
        {
            Vector3 playerPos = player.transform.position;
            if (Vector3.Distance(playerPos, transform.position) < proximity)
            {
                agent.SetDestination(playerPos);
                agent.speed = speed;
            }
            else//player not in range
            {
                ws.UpdateWander();
                agent.speed = wanderSpd;
            }


        }
        if(canWander==false)
        {
            Vector3 playerPos = player.transform.position;
            if (Vector3.Distance(playerPos, transform.position) < proximity)
            {
                agent.SetDestination(playerPos);
            }
        }
    }
}
