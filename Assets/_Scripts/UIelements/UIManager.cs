using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float current_ammo = 30;
    public float max_ammo = 120;

    public Text ammo_text;

    public void ammoUpdate(int count)
    {
        ammo_text.text = current_ammo + "/" + max_ammo;

    }
}

