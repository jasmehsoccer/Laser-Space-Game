using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float shotCounter = 2;
    [SerializeField] float minTime = 0.2f;
    [SerializeField] float maxTime = 3f;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] float projectileSpeed = -12;
    [SerializeField] Transform laserSpawnPoint;

    [Header("Audio")]
    [SerializeField] AudioClip enemyLaserSoundEffect;
    [SerializeField] AudioClip enemyDeathSoundEffect;
    [SerializeField][Range(0, 1)] public float enemyLaserSFX = 0.25f;
    [SerializeField][Range(0, 1)] public float enemyExplosionSFX = 0.75f;
    float glitch_timer = 0f;
    [SerializeField] Material glitch_material;
    [SerializeField] Material original_material;
    private void Awake()
    {
        

        if (TryGetComponent<SpriteRenderer>(out SpriteRenderer component))
        {
            original_material = component.material; 

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTime, maxTime); // I added the UnityEngine. to clarify we are using Unitys Random
        // class from the Unity library but I think it was implicitly implied so it doesn't really make a difference. 
        gameSession.OnTriggerBoss += GameSession_OnTriggerBoss;
    }

    private void GameSession_OnTriggerBoss(object sender, System.EventArgs e)
    {
        if (glitch_material != null)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = glitch_material;
            glitch_timer = 5f;
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CountdownandShoot();
        if (glitch_timer > 0){

            glitch_timer -= Time.deltaTime;
            Debug.Log(glitch_timer);

        }
        if (glitch_timer <= 0)
        {

            Destroy(gameObject);
        }
    }

    private void CountdownandShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0) // Your if statement was always true, before you said shotCounter >- 0 our counter range is 
            // 0.2 - 3 which is always larger than 0 so the shotCounter -= Time.deltaTime was irrelevant. Now we properly count down.
            // was just an operator error, no biggie. 
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTime, maxTime);
        }
    }

    private void Fire()
    {
        // I was making this over complimcated, an easier solution is just using a vector, I didn't want to use it because
        // you haven't used those in math but its not a big deal, Vector3. and a direction will allow you to manipulate the x, y, z 
        // Vector3.left or Vector3.right = -1 and 1 for x giving a vector (-1, 0, 0) or (1, 0, 0)
        // Vector3. up/down = y so you get a vector of (0, 1, 0) or (0, -1, 0)
        // Vector3. forward/backward = z giving (0, 0, 1) or (0, 0, -1).
        // Once you have your vector simply multiply  by the amount you want, since its facing the wrong way
        // Vector3.up * -90f will fix it to face the right way, the value can be trial an error if you don't know it exactly. 
        // this solution helps your code stay cleaner and easier to read, if you want to change the value it rotates without having
        // to come into your code over and over again, simply remove the magic value and replace it with a serialized float
        // so you multiply your vector by a variable you can change in the inspector. 
        GameObject enemylaser = Instantiate(enemyLaser, laserSpawnPoint.position, Quaternion.identity);
        enemylaser.transform.Rotate(Vector3.forward * -90f); 
        enemylaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(enemyLaserSoundEffect, Camera.main.transform.position, enemyLaserSFX);
    }
}
