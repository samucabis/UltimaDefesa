using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerShootCount : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite bulletOff;
    public Sprite bulletOn;
    public GameObject[] bullets;
    public Weapon weapon;
    public float timeRecharge;
    private int n;

    void Start()
    {
       timeRecharge = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BulletShooted(int number){
        /*if(number < 5){
            if(number == 0){
                bullet.GetComponent<Image>().sprite = bulletOff;
            }
            if(number == 1){
                bullet1.GetComponent<Image>().sprite = bulletOff;
            }
            if(number == 2){
                bullet2.GetComponent<Image>().sprite = bulletOff;
            }
            if(number == 3){
                bullet3.GetComponent<Image>().sprite = bulletOff;
            }
            if(number == 4){
                bullet4.GetComponent<Image>().sprite = bulletOff;
            }
        }else{

        }*/
        n = number;
        if(number < 5){
            bullets[number].GetComponent<Image>().sprite = bulletOff;
        }else{
            Debug.Log("Balas "+ number);
            Recarregar();
            
        }
        
    }

    public void Recarregar(){
        weapon.isRecharging = true;
        StartCoroutine(RechargeTimeDelay());
    }

    IEnumerator RechargeTimeDelay()
    {   
        int nBullets = 4;
        if(n < 5)
            nBullets = n;
        
        while(nBullets >= 0){
            Debug.Log("Balas Nbullets"+ nBullets);
            bullets[nBullets].GetComponent<Image>().sprite = bulletOn;
            nBullets--;
            yield return new WaitForSeconds(timeRecharge);
              
        }
        weapon.isRecharging = false;
            
    }
}
