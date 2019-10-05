using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
public class PlayerCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;
    public GameController gameController;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            GameObject temp = Instantiate(explosionPlayer, collision.transform.position, collision.transform.rotation);
            Destroy(temp, 2.0f);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Thief")
        {
            return;
        }
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);   // Asteroid

    }
}
