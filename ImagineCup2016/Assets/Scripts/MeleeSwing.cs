using UnityEngine;
using System.Collections;

public class MeleeSwing : MonoBehaviour {

    // Use this for initialization
    private bool attack;//tells if the user can attack again

    public float swingTime=0.5f;//how long the melee weapon will swing for
    public float swingSpd=0.30f;//the speed of the weapon
    public float timer=0f;//the timer of the swing
    
    public float maxDown=40.0f;//the min angle swinging down;

    private Quaternion swingRot;//rotation of the swing

	void Start () {
        attack = false;
        swingRot = transform.localRotation;
	}
	
    public bool Attack
    {
        get { return attack; }
    }

	// Update is called once per frame
	void Update () {
        swingRot = transform.localRotation;
        
        if (Input.GetMouseButtonDown(0) && attack==false)
        {
            attack = true;
        }


        if(attack==true)
        {
            timer += Time.deltaTime;
            transform.Rotate(transform.right, maxDown);
            if(timer > swingTime)
            {
                timer = 0f;
                attack = false;
            }
        }
        else
        {
            
        }
   
	}
}
