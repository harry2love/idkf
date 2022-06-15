using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Movement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex;
    private float minDistance = 0.5f;
    private float speed = 10;
    float rotationspeed = 100;
    private float lastWaypointIndex;



    void Start()
    {
        targetWaypoint = waypoints[targetWaypointIndex];
        lastWaypointIndex = waypoints.Count - 1;
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypont();
        }
    }

    void UpdateTargetWaypont()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }
}
