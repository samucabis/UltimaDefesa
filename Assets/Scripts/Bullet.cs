using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public LayerMask playerLayer;
    public float speed = 0.02f;
    public int damage;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        damage = player.dano;
        rb.velocity = transform.right * speed;
        //Debug.Log("DAno da bala " + damage);

    }
   
   void OnTriggerEnter2D(Collider2D other) {
        Enemy enemy = other.GetComponent<Enemy>();
        if(enemy != null){
            enemy.takeDamage(damage);
        }
        if(other.gameObject.layer != 8 && other.gameObject.layer != 11){
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }  
    }



}
