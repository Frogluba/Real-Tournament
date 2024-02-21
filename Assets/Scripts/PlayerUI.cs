using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text healthText;
    public Healt health;
    public TMP_Text ammoText;
    public Weapon weapon;

    void Start()
    {
        
    }

    
    void Update()
    {
        healthText.text = health.health.ToString();
        ammoText.text = weapon.ammo.ToString();
    }
}
