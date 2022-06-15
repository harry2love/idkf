using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthFollowPlayer : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector3(0f, 1f, 0f);
        transform.position = player.transform.position + offset;
    }
}
