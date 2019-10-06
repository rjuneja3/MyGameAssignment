using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    //public variables
    public Speed speed;
    public Boundary boundary;

    //game controller
    public GameController gameController;

    //laser 
    public GameObject laser;
    // laser spawn transformatione empty object
    public Transform laserSpawn;
    //rate of firing
    public float fireRate = 0.5f;
    // laser sound
    private AudioSource _laserSound ;
    private float counter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        Move();
        CheckBounds();
        // Code to accept input from user to spawn lasers using left control button
        counter += Time.deltaTime;
        if (Input.GetButton("Fire1") && counter > fireRate)
        {
            //Debug.Log("Fire 1 working");
            // Laser sound Play
            _laserSound = gameController.audioSources[(int)SoundClip.LASER];
            _laserSound.Play();
            // Create my laser object
            Instantiate(laser, laserSpawn.position, laser.transform.rotation);
            counter = 0.0f;
        }
    }

    public void Move()
    { 
        //Gets Horizontal and Vertical axis and make the player move.
        Vector2 currentPosition = transform.position;

        if (Input.GetAxis("Horizontal") > 0)
        {
            currentPosition += new Vector2(speed.max, 0.0f);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            currentPosition -= new Vector2(speed.min, 0.0f);
        }
        
        if (Input.GetAxisRaw("Vertical") > 0.0f)
        {
            currentPosition += new Vector2(0.0f, speed.max);
        }
        if (Input.GetAxisRaw("Vertical") < 0.0f)
        {
            currentPosition -= new Vector2(0.0f, speed.min);
        }
        
        transform.position = currentPosition;
    }

    public void CheckBounds()
    {
        //Restricts the player in boundaries
        if (transform.position.x > boundary.Right)
        {
            transform.position = new Vector2(boundary.Right, transform.position.y);
        }

        if (transform.position.x < boundary.Left)
        {
            transform.position = new Vector2(boundary.Left, transform.position.y);
        }
        if (transform.position.y > boundary.Top)
        {
            transform.position = new Vector2(transform.position.x, boundary.Top);
        }
        if (transform.position.y < boundary.Bottom)
        {
            transform.position = new Vector2(transform.position.x, boundary.Bottom);
        }
    }
}
