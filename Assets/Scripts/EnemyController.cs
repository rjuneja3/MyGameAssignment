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

    public float verticalSpeed;
    public float horizontalSpeed;

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
        verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);
        horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);

        float randomYPosition = Random.Range(boundary.Top, boundary.Bottom);

        transform.position = new Vector2(Random.Range(boundary.Right, boundary.Right + ThiefOffset), randomYPosition);

    }
    void CheckBounds()
    {
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
}
