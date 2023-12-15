using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 10.0f;
    public float rotationSpeed = 10.0f;
    int currentWaypoint = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentWaypoint].transform.position) < 3)
        {
            currentWaypoint++;
        }
        if(currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
        Quaternion lookAtWaypoint = Quaternion.LookRotation(waypoints[currentWaypoint].transform.position - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWaypoint, rotationSpeed * Time.deltaTime);
        this.transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
