using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy1 : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] Vector3 offset;
    void Start()
    {
        if(offset == Vector3.zero)
        {
            offset = new Vector3(0, 0.5f, 0);
        }
    }

    void Update()
    {
        if (enemy != null)
        {
            
            transform.position = enemy.transform.position + offset;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
