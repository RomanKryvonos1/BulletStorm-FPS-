using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public float damage = 25f;
    public float range = 100f;
    public float fireRate = 1f;
    public float impactForce = 60f;
    public float impactTime = 1f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    //public GameObject impactEffect;
    public AudioSource shotSound;
    public AudioSource reloadSound;

    private float nextTimeToFire = 0f;

    public Animator animator;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

       if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
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

    IEnumerator Reload()
    {
        isReloading = true;
        reloadSound.Play();
        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false; 
    }

    void Shoot()
    {

        currentAmmo--;


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
