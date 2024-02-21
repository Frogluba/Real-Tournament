using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Healt : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    

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
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
