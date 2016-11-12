using UnityEngine;
using System.Collections;

public class WanderScript : MonoBehaviour {

    // Use this for initialization
    public float radius=10.0f;//the radius of how far it will travel
    private Transform wanderTarget;//where ai will wander to
    private NavMeshAgent wandAgent;

    private float currTime;//the current time
    public float timeLength = 10.0f;//the max time to go to

	void Start () {
        wandAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
	 
	}

    public void UpdateWander()
    {
        currTime += Time.deltaTime;
        if (currTime >= timeLength)
        {
            Vector3 randPos = RandomLocNav(transform.position, radius, -1);
            wandAgent.SetDestination(randPos);
            currTime = 0;
        }
    }

    public Vector3 RandomLocNav(Vector3 currLoc, float dist, int layer)
    {
        Vector3 randDir = Random.insideUnitSphere * dist;

        randDir += currLoc;

        NavMeshHit hitting;

        NavMesh.SamplePosition(randDir, out hitting, dist, layer);

        return hitting.position;
    }


}
