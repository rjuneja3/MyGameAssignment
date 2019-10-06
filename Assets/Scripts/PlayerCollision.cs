using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
public class PlayerCollision : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionPlayer;
 
   
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with enemies, then player gets killed.
        if (collision.tag == "Player")
        {
            // instantiates explosion
            GameObject temp = Instantiate(explosionPlayer, collision.transform.position, collision.transform.rotation);
            Destroy(temp, 2.0f);
            //destroys player
            Destroy(collision.gameObject);
           
        }    

    }
   

}
