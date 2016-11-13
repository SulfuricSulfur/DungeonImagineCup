using UnityEngine;
using System.Collections;

public class CollectObj : MonoBehaviour {
    //This script will be attached to the objects that will be collected

    public DoorOpen levelObj;//corresponding to getting to next level
    public Camera MainCamera;
    public float MaxRange = 2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hitRay;
            Transform CameraTransform = MainCamera.transform;

            if (Physics.Raycast(CameraTransform.position, CameraTransform.TransformDirection(Vector3.forward), out hitRay))
            {
                if (hitRay.collider.tag == "Collectible" && hitRay.distance < MaxRange)
                {
                    levelObj.CurrObj++;
                    Destroy(hitRay.transform.gameObject);//get rid of object
                }
            }
        }
    }
}
