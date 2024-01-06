using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveBody : MonoBehaviour
{
    

    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] public float padding = 1f;
    [Header("ProjectileValues")]
    [SerializeField] public GameObject laser;
    [SerializeField] public float ProjectileSpeed = 10.5f;
    [SerializeField] public float ProjectileFiringRate = 10.5f;
    [Header("Audio")]
    [SerializeField][Range(0, 1)] public float LaserSound;
    [SerializeField] public AudioClip PlayerLaser;


    Coroutine FireCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    
    private void Start()
    {
        SetUpMoveBoundaries();
    }



    // Update is called once per frame
    void Update()
    {
        // Taking character's physical space and taking in value to move the character horizontally or vertically.
        Move();
        FireProjectile();
    }

    private void Move()
    {
        float deltaX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed; // another way to get our keybindings
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax); // position is current position + change

        float deltaY = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        // camera boundary constraints 

        transform.position = new Vector2(newXPos, newYPos);
        //Debug.Log(deltaX);
        //Debug.Log(deltaY);
    }
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
        //camera boundary setup
    }
    private void FireProjectile()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            FireCoroutine = StartCoroutine(KeepFiring());
        }
        if (Input.GetButtonUp("Fire3"))
        {
            StopCoroutine(FireCoroutine);
        }
    }

    private IEnumerator KeepFiring()
    {
        while (true)
        {
            GameObject Laser = Instantiate(laser, transform.position, Quaternion.Euler( 0f,0f,90f));
            Laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ProjectileSpeed);
         
            float AudioRange = UnityEngine.Random.Range(0.1f,1);
            AudioSource.PlayClipAtPoint(PlayerLaser, Camera.main.transform.position, AudioRange);
            yield return new WaitForSeconds(ProjectileFiringRate);
            //yield return new means give up contro for a certain amount of time

        }
    }

}

