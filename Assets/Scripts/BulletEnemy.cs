using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float speed = 0.02f;
    public int damage = 10;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        
        rb.velocity = transform.right * speed;

    }
   
   void OnTriggerEnter2D(Collider2D other) {
        //Enemy enemy = other.GetComponent<Enemy>();
        //if(enemy != null){
            //enemy.takeDamage(damage);
       //}
       Player player = other.GetComponent<Player>();
        if(player != null)
            player.takeDamage(damage);

     if(other.gameObject.layer != 9 && other.gameObject.layer != 11){
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }  
        
    }


}
