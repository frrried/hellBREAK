using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI armour;
    public TextMeshProUGUI ammo;

    public Image healthIndicator;

    public Sprite health1;
    public Sprite health2;
    public Sprite health3;
    public Sprite health4;

    private static CanvasManager _instance;
    public static CanvasManager Instance 
    {
        get 
        {
            return _instance;
        } 
    }

    private void Awake()
    {
        if (_instance != null && _instance != this) 
        {
            Destroy(this.gameObject);
        }

        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateHealth(int hpValue)
    {
        health.text = hpValue.ToString() + "%";
        UpdateHealthIndicator(hpValue);
    }

    public void UpdateArmour(int armourValue)
    {
        armour.text = armourValue.ToString() + "%";
    }

    public void UpdateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }

    public void UpdateHealthIndicator(int healthValue)
    {
        if (healthValue > 67 && healthValue <= 100)
        {
            healthIndicator.sprite = health1;
        }

        if (healthValue > 34 && healthValue <= 66)
        {
            healthIndicator.sprite = health2;
        }

        if (healthValue > 0 && healthValue <= 33)
        {
            healthIndicator.sprite = health3;
        }

        if (healthValue <= 0)
        {
            healthIndicator.sprite = health4;
        }
    }
}
