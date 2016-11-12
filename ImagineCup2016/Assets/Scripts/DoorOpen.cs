using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour {

    public int numObj;//number of objects in the scene
    private int currObj;//current num obj the player has
	// Use this for initialization

    public int CurrObj
    {
        get { return currObj; }
        set { currObj = value; }
    }

    public int NumObj
    {
        get { return numObj; }
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnTriggerEnter(Collider ply)
    {
        if(ply.tag=="Player")
        {
            if (currObj == numObj)
            {
                //Application.SceneManager("level_2");
                SceneManager.LoadScene("level_2");
            }
        }
    }
}
