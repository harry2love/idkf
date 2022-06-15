using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Transform player;
    [SerializeField] private Vector3 offset;

    [SerializeField] private float lerp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position =  Vector3.Lerp(gameObject.transform.position, player.position + offset, lerp);
    }
}
