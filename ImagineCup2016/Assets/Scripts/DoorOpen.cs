using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorOpen : MonoBehaviour {

    private int numObj = 3;//number of objects in the scene
    private static int currObj;//current num obj the player has
    public string sceneName;
	// Use this for initialization

    public static int CurrObj
    {
        get { return currObj; }
        set { currObj = value; }
    }

    public int NumObj
    {
        get { return numObj; }
    }

	void Start () {
        currObj = 0;
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void OnTriggerEnter(Collider ply)
    {
        if(ply.tag=="Player")
        {
            Debug.Log("collided player"+currObj + " " + numObj);
            if (currObj >= numObj)
            {
                Debug.Log("collected everything");
                //Application.SceneManager("level_2");
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
