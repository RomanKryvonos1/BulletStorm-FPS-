using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{

    public float damage = 25f;
    public float range = 100f;
    public float fireRate = 1f;
    public float impactForce = 60f;
    public float impactTime = 1f;

    public Camera fpsCam;
    public Text ammoText;
    //public GameObject impactEffect;
    public AudioSource shotSound;
    public AudioSource reloadSound;

    private float nextTimeToFire = 0f;

    public Animator animator;
    Reloading reloading;

    void Start()
    {
        reloading = GetComponent<Reloading>();
    }


    void Update()
    {
       if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !reloading.needReload)
        {
            shotSound.Play();
            animator.SetBool("Shooting", true);
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        else
        {
            animator.SetBool("Shooting", false);
        }
    }

    void Shoot()
    {
        reloading.DecreaseAmmo();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit , range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
           // Destroy(impactGO, impactTime);
        }
    }
}
