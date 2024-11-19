using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAwareness : MonoBehaviour
{
    public Material aggroMat;

    public bool isAggro;

    private Transform playerTransform;

    public float awarenessDist = 8f;
    void Start()
    {
        playerTransform = FindObjectOfType<controller>().transform;
    }

    void Update()
    {

        var dist = Vector3.Distance(transform.position, playerTransform.position);

        if (dist < awarenessDist)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            GetComponent<MeshRenderer>().material = aggroMat;
        }
    }
}
