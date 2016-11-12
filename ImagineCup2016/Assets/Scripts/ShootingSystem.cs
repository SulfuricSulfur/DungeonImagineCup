using UnityEngine;
using System.Collections;

public class ShootingSystem : MonoBehaviour {

    public Camera MainCamera;
    public ParticleSystem bloodParticle;
    public AudioSource shootSound;
    public AudioSource hitSound;

    public float MaxRange = 15;
    float Range;
    public int Damage = 60;

    private bool canAttack;

    void Start() {
        canAttack = false;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire1")) {
            //GetComponent<Animation>().Play();
            ShootWeapon();
        }
    }

    void ShootWeapon() {
        if (Input.GetMouseButtonDown(0) && canAttack == false)
            canAttack = true;

        if (canAttack)
        {
            RaycastHit hitRay;
            Transform CameraTransform = MainCamera.transform;

            //Instantiate(shootSound, gameObject.transform.position, gameObject.transform.rotation);

            if (Physics.Raycast(CameraTransform.position, CameraTransform.TransformDirection(Vector3.forward), out hitRay))
            {
                Debug.Log("did the raycast");
                Range = hitRay.distance;
                if (hitRay.collider.tag == "Enemy" && hitRay.distance < MaxRange)
                {
                    Debug.Log("hit an enemy");
                    hitRay.collider.gameObject.GetComponent<Health>().takeDamage(Damage);

                    Quaternion prefabRot = Quaternion.FromToRotation(Vector3.up, hitRay.normal);
                    //Instantiate(bloodParticle, hitRay.point, prefabRot);
                }
            }
            canAttack = false;
        }
    }
}
