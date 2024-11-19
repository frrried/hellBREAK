using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private bool damagingPlayer;
    private PlayerHealth playerHP;

    public int damageAmount;
    public float timeInBetween = 1.5f;

    private float damageCounter;

    // Start is called before the first frame update
    void Start()
    {
        damageCounter = timeInBetween;
        playerHP = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damagingPlayer) 
        {
            if (damageCounter >= timeInBetween)
            {
                playerHP.DamagePlayer(damageAmount);

                damageCounter = 0f;
            }

            damageCounter += Time.deltaTime;
        }

        else
        {
            damageCounter = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damagingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damagingPlayer = false;
        }
    }
}
