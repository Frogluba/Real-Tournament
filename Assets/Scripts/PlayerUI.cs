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
        UpdateUi();
        health.onDamage.AddListener(UpdateUi);
        weapon.onShoot.AddListener(UpdateUi);
        weapon.onReload.AddListener((ended) => UpdateUi());
    }

    
    void UpdateUi()
    {
        healthText.text = health.health.ToString();
        ammoText.text = weapon.ammo.ToString();
        print("i");
    }
}
