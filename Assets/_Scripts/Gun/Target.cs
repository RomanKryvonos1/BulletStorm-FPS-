using UnityEngine;

public class Target : MonoBehaviour
{

    public float healt = 100f;

    public void TakeDamage (float amount)
    {
        healt -= amount;
        if (healt <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }


}
