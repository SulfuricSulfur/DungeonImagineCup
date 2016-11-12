using UnityEngine;
using System.Collections;

public class ProximityLeap : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    bool triggered;
    int leapTimer;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 20;
        agent.acceleration = 20;
        player = GameObject.Find("Player");
        leapTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = player.transform.position;
        float dist = Vector3.Distance(playerPos, transform.position);
        if (dist < 20)
            triggered = true;

        if (leapTimer >= 240 && triggered)
        {
            triggered = false;
            leapTimer = 0;
            //do the jump
        }
        leapTimer++;
    }
}
