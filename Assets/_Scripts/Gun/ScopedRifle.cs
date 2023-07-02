using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ScopedRifle : MonoBehaviourPunCallbacks
{

    public Animator animator;

    private bool isScoped = false;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                isScoped = !isScoped;
                animator.SetBool("Scoped", isScoped);
            }
            else
            {
                animator.SetBool("Scoped", isScoped);

            }
        }

    }
}
