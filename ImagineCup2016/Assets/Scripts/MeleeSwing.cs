using UnityEngine;
using System.Collections;

public class MeleeSwing : MonoBehaviour {

    // Use this for initialization
    private bool attack;//tells if the user can attack again

    public float swingTime=0.5f;//how long the melee weapon will swing for
    public float swingSpd=0.30f;//the speed of the weapon
    public float timer=0f;//the timer of the swing

    public float maxUp=-40.0f;//max angle up;
    public float maxDown=40.0f;//the min angle swinging down;

    private bool center;//tells if melee should return to center;
    private bool start;//tells if the swining has started
    private bool swingDown;//tell if the weapon should go down

    private Vector3 swingRot;//rotation of the swing

	void Start () {
        attack = false;
        swingRot = transform.eulerAngles;
        center = false;
        start = false;
	}
	
    public bool Attack
    {
        get { return attack; }
    }

	// Update is called once per frame
	void Update () {
        swingRot = transform.eulerAngles;
        if (Input.GetMouseButtonDown(0) && attack==false)
        {
            attack = true;
            start = true;
        }


        if(attack==true)
        {
            timer += Time.deltaTime;
            if(start==true && swingRot.x >maxUp)
            {
                
            }
            /*
            else if()
            {
                transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, swingRot, swingSpd);
            }
            */
            else if(timer >swingTime)
            {
                timer = 0f;
                attack = false;
            }
        }
   
	}
}
