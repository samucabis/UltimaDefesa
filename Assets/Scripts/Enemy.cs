using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public Score kills_score;

    void Start() {
        kills_score = GameObject.FindWithTag("GameManager").GetComponent<Score>();
    }

    public void takeDamage (int damage){
        health -= damage;

        if(health <= 0){
            kills_score.Scored();
            Die();
        }

    }

    public void Die(){
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);  
    }

}
