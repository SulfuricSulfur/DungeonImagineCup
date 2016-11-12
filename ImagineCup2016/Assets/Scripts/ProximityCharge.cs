using UnityEngine;
using System.Collections;

public class ProximityCharge : MonoBehaviour {

    NavMeshAgent agent;
    public GameObject player;
    public int speed;
    public int acceleration;
    public int proximity;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.acceleration = acceleration;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = player.transform.position;
        if (Vector3.Distance(playerPos, transform.position) < proximity)
        {
            agent.SetDestination(playerPos);
        }
    }
}
