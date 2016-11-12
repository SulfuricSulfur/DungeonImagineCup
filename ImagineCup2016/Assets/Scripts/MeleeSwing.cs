using UnityEngine;
using System.Collections;

public class MeleeSwing : MonoBehaviour {

    // Use this for initialization
    private bool attack;//tells if the user can attack again

    public float swingTime=0.5f;//how long the melee weapon will swing for
    public float swingSpd=0.30f;//the speed of the weapon
    public float timer=0f;//the timer of the swing

    public float maxUp=320.0f;//max angle up;
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
        swingDown = false;
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
            if(start==true && swingRot.x < maxUp && swingRot.x >=360)
            { 
                transform.Rotate(-Vector3.right * Time.deltaTime * swingSpd);
                
            }
            /*
            else if((start==false && swingDown==true && center ==false)&& swingRot.x < maxDown && swingRot.x < maxDown)
            {
                //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, swingRot, swingSpd);
                transform.Rotate(Vector3.right * Time.deltaTime * swingSpd);
            }
            else if(center==true && swingRot.x > 0)
            {
                transform.Rotate(-Vector3.right * Time.deltaTime * swingSpd);
            }
            */
            if(swingRot.x <= maxUp)
            {
                swingDown = true;
                start = false;
            }
            if(swingRot.x >= maxDown)
            {
                swingDown = false;
                center = true;
            }
            if(swingRot.x <=0 && center==true)
            {
                center = false;
                attack = false;
            }

            Debug.Log(swingRot.x);
        }
   
	}
}
