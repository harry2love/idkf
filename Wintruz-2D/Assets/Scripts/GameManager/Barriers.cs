using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barriers : MonoBehaviour
{

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "projectTileEnemy" || collision.gameObject.tag == "projectTilePlayer")
        {
            Destroy(collision.gameObject);
        }
    }
}
