using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public bool isHealth;
    public bool isArmour;
    public bool isAmmo;

    public int amount = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isHealth)
            {
                other.GetComponent<PlayerHealth>().GiveHealth(amount, this.gameObject);
            }

            if (isArmour)
            {
                other.GetComponent<PlayerHealth>().GiveArmour(amount, this.gameObject);
            }

            if (isAmmo)
            {
                other.GetComponentInChildren<gunScript>().GiveAmmo(amount, this.gameObject);
            }
        }
    }
}
