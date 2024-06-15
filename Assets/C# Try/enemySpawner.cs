using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public event EventHandler OnTriggerBoss;

    [SerializeField] List<waveConfig> waveConfig;
    [SerializeField] int startWave = 0;
    [SerializeField] bool looping = false;
    [SerializeField] float nextWaveCountdown = 5f;
    [SerializeField] float trigger_enter = 120f;
    // Start is called before the first frame update
    // Make a blank C# class and create Character creator class: Write a message, "Please fill out form". Make a class called Character Creator. Make many private variables. Create getters and setters. Make a consructor. 
    IEnumerator Start()
    {
        do
        {

            yield return StartCoroutine(SpawnAllWaves());

        }
        while (looping);
    }


    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = 0; waveIndex < waveConfig.Count; waveIndex++)
        {
            var currentWave = waveConfig[waveIndex];

            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));


        }
    }

    private void Update()
    {
        if (gameSession.Instance.GetMainGameTimer() < trigger_enter) 
        {
            return;
        
        }

        else
        {
            looping = !looping;
            OnTriggerBoss?.Invoke(this, EventArgs.Empty);
            
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(waveConfig currentWave)
    {
        for (int enemyCounter = 0; enemyCounter < currentWave.GetNumSpawn(); enemyCounter++)
        {
            
            var newEnemy = Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetWaypoint()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(currentWave);

            // moved this if check because order of operations was a bit wrong, we were never properly spawning the last enemy.
            if (enemyCounter == currentWave.GetNumSpawn() - 1) // I just changed this to stop the extra enemy from 
                                                               // spawning. the previous code where counter <= currentWave.GetNumSpawn() and this if statement before 
                                                               // works fine. 
            {
                Debug.Log("Starting Next Wave Timer");
                Debug.Log(nextWaveCountdown);
                yield return new WaitForSeconds(nextWaveCountdown);
            }

            yield return new WaitForSeconds(currentWave.GetSpawnWait());
        }
    }



    // Update is called once per frame

}

