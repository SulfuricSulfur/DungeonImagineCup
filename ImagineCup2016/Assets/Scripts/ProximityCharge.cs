using UnityEngine;
using System.Collections;

public class ProximityCharge : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    public int speed;
    public int acceleration;
    public int proximity;

    public bool canWander;//tells if this AI can wander
    private bool seesPlayer;//tells if the AI sees the player and thus should no longer wander
    public WanderScript ws;

    public bool SeesPlayer
    {
        get { return seesPlayer; }
    }

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.acceleration = acceleration;
        ws = this.GetComponent<WanderScript>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if(canWander==true)
        {
            Vector3 playerPos = player.transform.position;
            if (Vector3.Distance(playerPos, transform.position) < proximity)
            {
                seesPlayer = true;//player in range
            }
            else//player not in range
            {
                seesPlayer = false;
            }

            if (seesPlayer==true)
            {
                 agent.SetDestination(playerPos);              
            }
            else if(seesPlayer==false)
            {
                ws.UpdateWander();
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
