using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menumanager : MonoBehaviour
{
    public static Menumanager Instance;

    [SerializeField] Menu[] menus;

    private void Awake()
    {
        Instance = this;
    }

    public void Openmenu(string menuName)
    {
        for(int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                Openmenu(menus[i]);
            }
            else if (menus[i].open)
            {
                Closemenu(menus[i]);
            }
        }
        
    }

    public void Openmenu(Menu menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                Closemenu(menus[i]);
            }
        }
        menu.Open();
    }
    public void Closemenu(Menu menu)
    {
        menu.Close();
    }
}
