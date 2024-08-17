using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossFunction : MonoBehaviour
{
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float moveSpeed = 2f;

    BossFunction bossFunction;
    List<Transform> waypoint;
    int waypointIndex = 0;
    // Start is called before the first frame update


    void Start()
    {
        gameObject.SetActive(true);
        gameSession.OnTriggerBoss += bossEnter;
        transform.position = pathPrefab.transform.GetChild(0).position; 



    }
    public List<Transform> GetWaypoint()
    {
        List<Transform> Waypoints = new List<Transform>();//Declaring list to store transforms.

        //var testWaypoint = new List<Transform>();

        foreach (Transform transform in pathPrefab.transform)
        {
            Waypoints.Add(transform);


        }

        return Waypoints;
    }

    private void OnEnable()
    {
        
    }

    private void bossEnter(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        Debug.Log("Boss Fight");
    }

    private void OnDisable()
    {
        gameSession.OnTriggerBoss -= bossEnter;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }
   




    private void move()
    {
        TravelToNextPoint();
    }

    private void TravelToNextPoint()
    {
        if (waypointIndex <= pathPrefab.transform.childCount - 1)
        {
            var targetPosition = GetWaypoint();// Used to set the destination for the ship
            var movementThisFrame = moveSpeed * Time.deltaTime; // Used to make the framework consistent
            transform.position = Vector3.MoveTowards(transform.position, targetPosition[waypointIndex].position, movementThisFrame);// Move ship from current position to the next position at a certain speed.
            if (transform.position == targetPosition[waypointIndex].position) // Used to add to the Index to put ship on the next destination
            {
                waypointIndex++; // can make a recursive call here 
            }

        }
        else if (waypointIndex >= waypoint.Count - 1) // Instaead of destroying the ship
                                                      // here we opted to make a recursive call in order to continue the gameplay loop 
        {
            waypointIndex = 0;
            TravelToNextPoint();
        }
        /*{
            Destroy(gameObject);
        }*/
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }


}
