using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Photon.Pun;

public class Reloading : MonoBehaviourPunCallbacks
{

	public int maxAmmo = 50;
	int currentMaxAmmo;
	public int ammoCapacity = 10;
	[HideInInspector]
	public int currentAmmo;

	public float reloadSpeed = 1f;

	public Text ammoText;

	[HideInInspector]
	public bool needReload;

	Animator anim;


	// Use this for initialization
	void Start()
	{
		currentAmmo = ammoCapacity;
		currentMaxAmmo = maxAmmo;
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (photonView.IsMine)
		{
			if (currentAmmo <= 0)
				needReload = true;

			if (currentMaxAmmo > 0 && currentAmmo < ammoCapacity)
			{
				if (Input.GetKeyDown(KeyCode.R))
					StartCoroutine(Reload());
			}

			ammoText.text = currentAmmo + "/" + currentMaxAmmo;
		}
	}
	IEnumerator Reload()
	{
		if (photonView.IsMine)
		{
			Debug.Log("Reloading ...");
			anim.SetBool("Reloading", true);
			yield return new WaitForSeconds(reloadSpeed);
			needReload = false;

			if ((ammoCapacity - currentAmmo) <= currentMaxAmmo)
			{
				currentMaxAmmo -= (ammoCapacity - currentAmmo);
				currentAmmo += (ammoCapacity - currentAmmo);
			}
			else
			{
				currentAmmo += currentMaxAmmo;
				currentMaxAmmo = 0;
			}

			anim.SetBool("Reloading", false);
		}
	}

	public void DecreaseAmmo()
	{
		if (photonView.IsMine)
		{
			if (photonView.IsMine)
			{
				currentAmmo--;
			}
		}
	}
}

