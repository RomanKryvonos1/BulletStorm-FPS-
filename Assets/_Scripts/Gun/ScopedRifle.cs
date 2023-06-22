using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopedRifle : MonoBehaviour
{

    public Animator animator;

    private bool isScoped = false;

    // Update is called once per frame
    void Update()
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