using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Healt : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public bool shouldDestroy;
    public UnityEvent onDie;
    public UnityEvent onDamage;
    public GameObject damageEffect;
    public GameObject deathEffect;
    

    private void Start()
    {
        if (health == 0)
        {
            health = maxHealth;
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        onDamage.Invoke();
        if (health <= 0)
        {
            Die();
        }
        if (health < 0) health = 0;
        if (damageEffect != null) Instantiate(damageEffect, transform.position, Quaternion.identity);
    }

    public void Die()
    {
        if(shouldDestroy)Destroy(gameObject);
        onDie.Invoke();
        if (deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);
    }
}
