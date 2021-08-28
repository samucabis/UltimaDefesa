using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Melhorias : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject MelhoriasMenuUI;
    public Weapon weapon;
    public Player player;
    public PlayerShootCount shootCount;
    public Text moedasCount;
    public Text qntVida;
    public Text danoPlayer;
    public Text tRecarga;
    int valor;
    // Update is called once per frame

    void Update()
    {
        moedasCount.text = player.moedas.ToString();   
        qntVida.text = player.maxHealth.ToString();
        danoPlayer.text = player.dano.ToString();
        tRecarga.text = shootCount.timeRecharge.ToString();
        if(Input.GetKeyDown(KeyCode.L)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }

    }

    public void Resume (){
        MelhoriasMenuUI.SetActive(false);
        weapon.isPaused = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause (){
        MelhoriasMenuUI.SetActive(true);
        weapon.isPaused = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void AddVidaMax(){
        if(player.moedas >= 40){
            player.maxHealth += 20;
            player.moedas -= 40;
        }
    }
    public void AddDanoMax(){
        if(player.moedas >= 80){
            if(player.dano >= 100){
                player.dano = 100;
            }else{                
            player.dano += 10;
            player.moedas -= 80;
            }
        }
    }
    public void AddTempoDeRecarga(){
        if(player.moedas >= 70){
            if(shootCount.timeRecharge < 0.1f){
                shootCount.timeRecharge = 0.1f;
            }else{
                shootCount.timeRecharge -= 0.1f;
                player.moedas -= 70;
            }            
        }
    }
    public void RecuperarVida(){
        if(player.moedas >= 30){
            player.health = player.maxHealth;
            player.moedas -= 30;
        }
    }

}
