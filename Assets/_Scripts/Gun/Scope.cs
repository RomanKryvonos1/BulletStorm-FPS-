using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Scope : MonoBehaviourPunCallbacks
{
    public Animator animator;
    public Camera scopeCamera;

    public float scopedFOV = 15f;
    private float normalFOV;

    private bool isScoped = false;

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                animator.SetBool("Scoped", true);
                isScoped = !isScoped;

                if (isScoped)
                    StartCoroutine(OnScoped());
                else
                    OnUnScoped();
            }
        }

    }

    void OnUnScoped()
    {
        if (photonView.IsMine)
        {
            animator.SetBool("Scoped", isScoped);
            normalFOV = 60;
        }
    }

    IEnumerator OnScoped()
    {
        if (photonView.IsMine)
        {
            yield return new WaitForSeconds(0.15f);
            normalFOV = scopeCamera.fieldOfView;
            scopeCamera.fieldOfView = scopedFOV;
        }
    }
}
