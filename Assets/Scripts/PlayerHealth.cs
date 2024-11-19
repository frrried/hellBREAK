using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    private int health;

    public int maxArmour = 50;
    private int armour;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmour(armour);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            DamagePlayer(30);
            Debug.Log("Player Has Been Damaged");
        }
    }

    public void DamagePlayer(int damage)
    {
        if(damage <= armour)
        {
            armour -= damage;
        }

        else if(damage > armour)
        {
            int remainingDamage = damage - armour;

            health -= remainingDamage;

            armour = 0;
        }

        if (health <= 0 )
        {

            Debug.Log("Player Died");
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);

        }
        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmour(armour);
    }

    public void GiveHealth (int amount, GameObject PickUp)
    {
        
        if (health < maxHealth)
        {
            health += amount;
            Destroy(PickUp);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        CanvasManager.Instance.UpdateHealth(health);

    }

    public void GiveArmour (int amount, GameObject PickUp)
    {
        

        if (armour < maxArmour)
        {
            armour += amount;
            Destroy(PickUp);
        }

        if(armour > maxArmour)
        {
            armour = maxArmour;
        }

        CanvasManager.Instance.UpdateArmour(armour);

    }
}
