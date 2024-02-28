using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Healt health;
    public Weapon weapon;
    public LayerMask weaponLayer;
    public GameObject equipText;
    public Transform hand;

    private void Start()
    {
        health = GetComponent<Healt>();

    }

    private void Update()
    {
        var cam = Camera.main.transform;
        var collided = Physics.Raycast(cam.position, cam.forward, out var hit,2f,weaponLayer);
        equipText.SetActive(collided && !weapon);

        

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(weapon==null)
            {
                weapon = hit.transform.GetComponent<Weapon>();
                Equip(weapon);
            }
            else
            {
                Drop();
            }
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

    void Equip(Weapon newweapon)
    {
        weapon = newweapon;
        weapon.GetComponent<Rigidbody>().isKinematic = true;
        weapon.transform.position = hand.position;
        weapon.transform.rotation = hand.rotation;
        weapon.transform.parent = hand;
    }

    void Drop()
    {
        if (weapon == null) return;
        weapon.GetComponent<Rigidbody>().isKinematic = false;
        weapon.GetComponent<Rigidbody>().velocity = transform.forward * 5f;
        weapon.transform.parent = null;
        weapon = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health.Damage(10);
        }
       
    }
}
