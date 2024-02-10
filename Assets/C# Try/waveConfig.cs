using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWaveConfig")]
public class waveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyShip;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float spawnWait = 0.5f;
    [SerializeField] float randomSpawn = 0.3f;
    [SerializeField] int numSpawn = 8;
    [SerializeField] float moveSpeed = 2f;
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
    public float GetSpawnWait()
    {
        return spawnWait;
    }
    public float GetRandomSpawn()
    {
        return randomSpawn;
    }
    public int GetNumSpawn()
    {
        return numSpawn;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    // Start is called before the first frame update
}
