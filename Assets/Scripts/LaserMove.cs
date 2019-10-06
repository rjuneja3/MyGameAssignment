using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
public class LaserMove : MonoBehaviour
{
    public float speed = 20.0f;
    public GameObject explosion;
    private Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = Vector2.right * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Instantiates explosion animation
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        //destroys laser
        Destroy(gameObject);
    }

}
