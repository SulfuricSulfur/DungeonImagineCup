using UnityEngine;
using System.Collections;

public class CollectObj : MonoBehaviour {
    //This script will be attached to the objects that will be collected

    public DoorOpen levelObj;//corresponding to getting to next level

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider plyColl)
    {
        if(plyColl.tag=="Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
             levelObj.CurrObj += 1;
             Destroy(this.gameObject);//get rid of object
            }
        }
    }
}
