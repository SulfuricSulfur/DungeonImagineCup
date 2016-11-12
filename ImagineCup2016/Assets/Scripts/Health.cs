using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health;
    public int invTime;
    int timer;
    bool isDamaged;
    int damage;

	// Use this for initialization
	void Start () {
        isDamaged = false;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
            Destroy(this.gameObject);

        if (timer >= invTime && isDamaged)
        {
            health -= damage;
            timer = 0;
            isDamaged = false;
        }
        timer++;
	}

    public void takeDamage(int damage)
    {
        this.damage = damage;
        isDamaged = true;
    }
}
