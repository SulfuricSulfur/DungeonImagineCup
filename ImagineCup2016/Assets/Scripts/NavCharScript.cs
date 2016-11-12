using UnityEngine;
using System.Collections;

public class NavCharScript : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    bool triggered;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 7;
        agent.acceleration = 10;
        player = GameObject.Find("Player");
        triggered = false;
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
