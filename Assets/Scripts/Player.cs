using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int health = 100;
    public GameObject deathEffect;
    public int dano = 10;
    public int moedas = 0;
    public GameObject gameOverUI;
    public AudioSource audioData;
    public Text count;
    public HealthBar healthbar;
    public Weapon weapon;


    void Start() {
        health = maxHealth;   
        healthbar.SetMaxHealth(maxHealth);
    }

    public void takeDamage (int damage){
        
        health -= damage;
        healthbar.SetHealth(health);
        if(health <= 0){
            Die();            
        }             

    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.layer);
        if(other.gameObject.layer == 7){                       
            Die();
        }  
    }

    public void Die(){     
        audioData.Play();   
        Instantiate(deathEffect, transform.position, Quaternion.identity);                   
        gameObject.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        weapon.isPaused = true;
        PlayerPrefs.SetInt("palyerScore", int.Parse(count.text));
        audioData.Stop(); 
    }

}
