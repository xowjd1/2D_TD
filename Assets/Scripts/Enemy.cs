using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Waypoint waypoint;

    private int currentWaypointIndex;

   // public Vector3 CurrentWaypointPosition => waypoint.GetWaypointPosition(currentWaypointIndex); //º¸·ù


    private void Start()
    {
        currentWaypointIndex = 0;
    }

    private void Update()
    {
        Move();
    }


    void Move()
    {
        //transform.position = Vector3.MoveTowards(transform.position, CurrentWaypointPosition,Time.deltaTime);
    }
}
