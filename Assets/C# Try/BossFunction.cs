using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossFunction : MonoBehaviour
{

    [SerializeField] GameObject enemyShip;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float moveSpeed = 2f;
    // Start is called before the first frame update


    void Start()
    {
        gameObject.SetActive(false);
        gameSession.OnTriggerBoss += bossEnter;
        waypoint = waveConfig.GetWaypoint();
        transform.position = waypoint[waypointIndex].transform.position;



    }

    public GameObject GetEnemyPrefab()
    {
        return enemyShip;
    }
    public List<Transform> GetWaypoint()
    {
        List<Transform> Waypoints = new List<Transform>();//Declaring list to store transforms.

        //var testWaypoint = new List<Transform>();

        foreach (Transform position in pathPrefab.transform)
        {
            Waypoints.Add(position);


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

        
    }
    BossFunction bossFunction;
    List<Transform> waypoint;
    int waypointIndex = 0;




    private void move()
    {
        TravelToNextPoint();
    }

    private void TravelToNextPoint()
    {
        if (waypointIndex <= waypoint.Count - 1)
        {
            var targetPosition = waypoint[waypointIndex].transform.position;// Used to set the destination for the ship
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime; // Used to make the framework consistent
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);// Move ship from current position to the next position at a certain speed.
            if (transform.position == targetPosition) // Used to add to the Index to put ship on the next destination
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

    public void setWaveConfig(waveConfig waveConfig)
    {
        this.waveConfig = waveConfig; // Sets wave config outside of this function to the waveConfig parameter. 

    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }


}
