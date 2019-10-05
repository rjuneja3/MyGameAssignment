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
        
        if (collision.tag == "Player")
        {
            GameObject temp = Instantiate(explosionPlayer, collision.transform.position, collision.transform.rotation);
            Destroy(temp, 2.0f);
            Destroy(collision.gameObject);
           
        }
        if (collision.tag == "Laser")
        {
            
        }
      
       

    }
   

}
