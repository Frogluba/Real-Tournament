using UnityEngine;
using UnityAsyncAwaitUtil;
using TMPro;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
	public UnityEvent onRightClick;
	public UnityEvent onShoot;
	public UnityEvent<bool> onReload;

	public GameObject bulletPrefab;
	public int ammo;
	public int maxAmmo = 10;
	public bool isReloading;
	public bool isAutoFire;
	public float fireInterval = 0.5f;
	public float fireCooldown;
	public float recoilAngel;
	public int bulletsPerShot = 1;
	

	void Update()
	{
		
			fireCooldown -= Time.deltaTime;
	}

	public void Shoot()
	{
		if (ammo <= 0) return;
		if (ammo <= 0)
		{
			Reload();
			return;
		}
		if (fireCooldown > 0) return;

		fireCooldown = fireInterval;
		ammo--;
		onShoot.Invoke();

	for (int i = 0; i < bulletsPerShot; i++)
	{ 
		var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
		var offsetX = Random.Range(-recoilAngel, recoilAngel);
		var offsetY = Random.Range(-recoilAngel, recoilAngel);
		bulletPrefab.transform.eulerAngles += new Vector3(offsetX, offsetY, 0);
	}
	}

	public async void Reload()
    {
		if (isReloading) return;
		isReloading = true;
		onReload.Invoke(false);

		await new WaitForSeconds(2f);
		ammo = maxAmmo;
		isReloading = false;
		onReload.Invoke(true);
	}

	
}