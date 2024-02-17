using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using Unity.VisualScripting;

public class EnemyPathing: MonoBehaviour
{
    waveConfig waveConfig;
    List<Transform> waypoint;
    int waypointIndex = 0;



    void Start() 
    
    {
        waypoint = waveConfig.GetWaypoint();
        transform.position = waypoint[waypointIndex].transform.position; 
    
    }

    private void Update()
    {
        move();
        
    }

    private void move()
    {
        if (waypointIndex <= waypoint.Count-1)
        {
            var targetPosition = waypoint[waypointIndex].transform.position;// Used to set the destination for the ship
            var movementThisFrame = waveConfig.GetMoveSpeed()*Time.deltaTime; // Used to make the framework consistent
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);// Move ship from current position to the next position at a certain speed.
            if (transform.position == targetPosition) // Used to add to the Index to put ship on the next destination
            {
                waypointIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setWaveConfig( waveConfig waveConfig)
    {
        this.waveConfig = waveConfig; // Sets wave config outside of this function to the waveConfig parameter. 

    }
}