using UnityEngine;
using System.Collections;

public class ShootingSystem : MonoBehaviour {

    public Camera MainCamera;
    public ParticleSystem bloodParticle;
    public AudioSource shootSound;
    public AudioSource hitSound;

    public float MaxRange = 15;
    public float minDamage = 1f;
    public float maxDamage = 3f;
    public int maxAmmo = 6;
    int currentAmmo;
    int Damage;
    bool reloading;
    float reloadTimer;

    void Start() {
        Damage = (int)Random.Range(minDamage, maxDamage);
        reloadTimer = 0;
        reloading = false;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0) && currentAmmo > 0) {
            //GetComponent<Animation>().Play();
            ShootWeapon();
            currentAmmo--;
            Debug.Log(currentAmmo);
        }

        if (Input.GetKeyDown(KeyCode.R))
            reloading = true;

        if (reloading)
            reloadTimer += Time.deltaTime; ;

        if(reloadTimer >= 3)
        {
            reloading = false;
            currentAmmo = maxAmmo;
            reloadTimer = 0;
            Debug.Log(currentAmmo);
        }
    }

    void ShootWeapon() {
        RaycastHit hitRay;
        Transform CameraTransform = MainCamera.transform;

        //Instantiate(shootSound, gameObject.transform.position, gameObject.transform.rotation);

        if (Physics.Raycast(CameraTransform.position, CameraTransform.TransformDirection(Vector3.forward), out hitRay))
        {
            if (hitRay.collider.tag == "Enemy" && hitRay.distance < MaxRange)
            {
                hitRay.collider.gameObject.GetComponent<Health>().takeDamage(Damage);

                //Quaternion prefabRot = Quaternion.FromToRotation(Vector3.up, hitRay.normal);
                //Instantiate(bloodParticle, hitRay.point, prefabRot);
            }
        }
    }
}
