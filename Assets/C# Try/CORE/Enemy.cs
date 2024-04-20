using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float shotCounter = 0;
    [SerializeField] float minTime = 0.2f;
    [SerializeField] float maxTime = 3f;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float projectileSpeed = -12;

    [Header("Audio")]
    [SerializeField] AudioClip enemyLaserSoundEffect;
    [SerializeField] AudioClip enemyDeathSoundEffect;
    [SerializeField][Range(0, 1)] public float enemyLaserSFX = 0.25f;
    [SerializeField][Range(0, 1)] public float enemyExplosionSFX = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        CountdownandShoot();
    }

    private void CountdownandShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter >= 0)
        {
            Fire();
            shotCounter = Random.Range(minTime, maxTime);
        }
    }

    private void Fire()
    {
        Quaternion new_rotation = new Quaternion(transform.rotation.x, 45f, transform.rotation.y, 1);
        GameObject enemylaser = Instantiate(enemyLaser, transform.position, new_rotation);
        enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(enemyLaserSoundEffect, Camera.main.transform.position, enemyLaserSFX);
    }
}
