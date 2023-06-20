using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverloy;
    public Camera scopeCamera;

    public float scopedFOV = 15f;
    private float normalFOV;

    private bool isScoped = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            if(isScoped)
                StartCoroutine(OnScoped());
            else
                OnUnScoped();
        }else
        {
            animator.SetBool("Scoped", isScoped);
        }

    }

    void OnUnScoped()
    {
        scopeCamera.fieldOfView = normalFOV;
        
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.15f);
        normalFOV = scopeCamera.fieldOfView;
        scopeCamera.fieldOfView = scopedFOV;
    }

}
