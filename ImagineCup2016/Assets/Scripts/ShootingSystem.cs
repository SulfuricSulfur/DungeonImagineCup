using UnityEngine;
using System.Collections;

public class ShootingSystem : MonoBehaviour {

    public Camera MainCamera;
    public ParticleSystem bloodParticle;
    public AudioSource shootSound;
    public AudioSource hitSound;
    public Material idleGun;
    public Material fireGun;

    public float MaxRange = 15;
    public float minDamage = 1f;
    public float maxDamage = 3f;
    public int maxAmmo = 6;
    int currentAmmo;
    int Damage;
    bool reloading;
    float reloadTimer;
    Renderer rend;

    void Start() {
        Damage = (int)Random.Range(minDamage, maxDamage);
        reloadTimer = 0;
        reloading = false;
        currentAmmo = maxAmmo;
        rend = GameObject.FindGameObjectWithTag("weapon").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0) && currentAmmo > 0) {
            //GetComponent<Animation>().Play();
            ShootWeapon();
            currentAmmo--;
            Debug.Log(currentAmmo);
            rend.material = fireGun;
        }
        else
        {
            rend.material = idleGun;
        }

        if (Input.GetKeyDown(KeyCode.R))
            reloading = true;

        if (reloading)
        {
            reloadTimer += Time.deltaTime;
            rend.enabled = false;
        }
        else
            rend.enabled = true;

        if(reloadTimer >= 2)
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
                Debug.Log("hit");
                hitRay.collider.gameObject.GetComponent<Health>().takeDamage(Damage);

                //Quaternion prefabRot = Quaternion.FromToRotation(Vector3.up, hitRay.normal);
                //Instantiate(bloodParticle, hitRay.point, prefabRot);
            }
        }
    }
}
