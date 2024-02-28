using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Healt health;
    public Weapon weapon;
    public LayerMask weaponLayer;
    public GameObject equipText;

    private void Start()
    {
        health = GetComponent<Healt>();

    }

    private void Update()
    {
        var cam = Camera.main.transform;
        var collided = Physics.Raycast(cam.position, cam.forward, out var hit,2f,weaponLayer);
        equipText.SetActive(collided);

        if (collided && Input.GetKeyDown(KeyCode.E))
        {
            weapon = hit.transform.GetComponent<Weapon>();
        }


        if (weapon == null) return;
        if (!weapon.isAutoFire && Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }
        if (weapon.isAutoFire && Input.GetKey(KeyCode.Mouse0))
        {
            weapon.Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && weapon.ammo < weapon.maxAmmo)
        {
            weapon.Reload();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            weapon.onRightClick.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);
        }
       
    }
}
