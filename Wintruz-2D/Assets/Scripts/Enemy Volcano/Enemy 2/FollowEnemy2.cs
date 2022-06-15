using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy2 : MonoBehaviour
{
    public GameObject enemy;
    Vector3 offset;
    void Start()
    {

    }

    void Update()
    {
        if (enemy != null)
        {
            offset = new Vector3(0, 1.85f, 0);
            transform.position = enemy.transform.position + offset;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
