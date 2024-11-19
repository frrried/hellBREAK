using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleToPlayer : MonoBehaviour
{

    private Transform player;
    private Vector3 targetPos;
    private Vector3 targetDir;

    private SpriteRenderer spriteRenderer;

    private float angle;
    public int lastIndex;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<controller>().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3 (player.position.x, transform.position.y, player.position.z);
        targetDir = targetPos - transform.position;

        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

        lastIndex = GetIndex(angle);
    }

    private int GetIndex(float angle)
    {
        if (angle < 22.5f && angle >= -22.5f)
        {
            return 0;
        }

        if (angle < -22.5f && angle >= -67.5f)
        {
            return 1;
        }

        if (angle < -67.5f && angle >= -112.5f)
        {
            return 2;
        }

        if (angle < -112.5f && angle >= -157.5f)
        {
            return 3;
        }

        if (angle < -157f || angle >= 157f)
        {
            return 4;
        }

        if (angle < 157.5f && angle >= 112.5f)
        {
            return 5;
        }

        if (angle < 112.5f && angle >= 67.5f)
        {
            return 6;
        }

        if (angle < 67.5f && angle >= -22.5f)
        {
            return 7;
        }

        return lastIndex;
    }
}
