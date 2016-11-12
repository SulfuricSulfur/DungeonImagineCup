using UnityEngine;
using System.Collections;

public class ProximityCharge : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 7;
        agent.acceleration = 30;
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = player.transform.position;
        if (Vector3.Distance(playerPos, transform.position) < 20)
        {
            agent.SetDestination(playerPos);
        }
    }
}
