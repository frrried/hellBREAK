using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float gunShotRadius = 20f;

    public BoxCollider gunTrigger;

    public enemyManager enemyManager;

    public float fireRate = 1f;
    private float firedTime;
    public int maxAmmo = 50;
    private int ammo = 10;

    public float damage = 2f;

    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;



    void Start()
    {
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);

        CanvasManager.Instance.UpdateAmmo(ammo);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > firedTime && ammo > 0)
        {
            Fire();
        }
    }
    public void Fire()
    {

        Collider[] enemyColliders;

        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<enemyAwareness>().isAggro = true;
        }

        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    float distance = Vector3.Distance(enemy.transform.position, transform.position);

                    if (distance < range * 0.6f)
                    {
                        enemy.TakeDamage(damage);
                    }

                    else
                    {
                        enemy.TakeDamage(damage * 0.5f);
                    }
                }
            }
        }
        ammo--;

        CanvasManager.Instance.UpdateAmmo(ammo);

    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);

        }
    }

    public void GiveAmmo(int amount, GameObject pickUp)
    {
        if (ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickUp);
        }

        if(ammo >= maxAmmo)
        {
            ammo = maxAmmo;
        }
        CanvasManager.Instance.UpdateAmmo(ammo);
    }
}
