using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health;
    public int invTime;
    int timer;
    bool isDamaged;

	// Use this for initialization
	void Start () {
        isDamaged = false;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if(timer >= invTime && isDamaged)
        {
            health--;
            timer = 0;
            isDamaged = false;
        }
        timer++;
	}

    public void takeDamage()
    {
        isDamaged = true;
    }
}
