using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isPaused;
    public int bulletCount;
    public PlayerShootCount playerShootCount;
    public bool isRecharging;
     // Update is called once per frame
    void Start(){
        isPaused = false;
        bulletCount = 0;
        isRecharging = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !isPaused){
            Shoot();
        }
        
    }


    void Shoot(){
        
        if(bulletCount < 5 && !isRecharging){
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            playerShootCount.BulletShooted(bulletCount);
            bulletCount++;
        }else{
            playerShootCount.BulletShooted(bulletCount);
            bulletCount = 0;   
        }
        
    }
}
