using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float HP = 2f;

    private enemyManager enemyManager;
    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;
    void Start()
    {
        spriteAnim = GetComponentInChildren<Animator>();

        angleToPlayer = GetComponent<AngleToPlayer>();
        enemyManager = FindObjectOfType<enemyManager>();
    }

    void Update()
    {
        spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);

        if(HP <= 0f)
        {
            Destroy(gameObject);

            enemyManager.RemoveEnemy(this);

        }
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
    }
}
