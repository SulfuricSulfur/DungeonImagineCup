using UnityEngine;
using System.Collections;

public class ProximityTransform : MonoBehaviour {

    public GameObject player;
    public int proximity;
    public Material idle;
    public Material active;
    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = player.transform.position;
        if (Vector3.Distance(playerPos, transform.position) < proximity)
        {
            rend.material = active;
        }
        else
        {
            rend.material = idle;
        }
    }
}
