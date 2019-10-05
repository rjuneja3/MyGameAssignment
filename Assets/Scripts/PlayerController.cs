using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;

    public GameController gameController;

    public GameObject laser;
    public float fireRate = 0.5f;

    private float counter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Move();
        CheckBounds();
        counter += Time.deltaTime;
        if (Input.GetButton("Fire1") && counter > fireRate)
        {
            // Create my laser object
            Instantiate(laser);
            counter = 0.0f;
        }
    }

    public void Move()
    {
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
