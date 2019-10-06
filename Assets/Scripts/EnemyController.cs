using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public Boundary boundary;

    [SerializeField]
    public Speed verticalSpeedRange;

    [SerializeField]
    public Speed horizontalSpeedRange;

    public float ThiefOffset;

    //Public Speed variables
    public float verticalSpeed;
    public float horizontalSpeed;
    //Game Controller
    public GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }
    void Reset()
    {
        // Vertical and horizontal maximum and minimum speed of player.
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
        // Top and bottom boundaries
        float randomYPosition = Random.Range(boundary.Top, boundary.Bottom);

        transform.position = new Vector2(Random.Range(boundary.Right, boundary.Right + ThiefOffset), randomYPosition);

    }
    void CheckBounds()
    {
        // Checks bounds where enemy can go to maximum and minimum
        if (transform.position.x <= boundary.Left)
        {
            Reset();
        }
    }

    void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(verticalSpeed, horizontalSpeed);
        transform.position = currentPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       // If the enemy hits laser , then the player gets 100 score and the enemy resets to original position
        if (collision.tag == "Laser")
        {
            gameController.Score += 100;
            Reset();
        }
        // if the player hits the enemy, then the player destroys and enemy resets to original position. and there is a life gone.
        if (collision.tag == "Player")
        {
            gameController.Lives += -1;
            Reset();
        }


    }
}
