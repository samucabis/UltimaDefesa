using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int count;
    public Text killCount;
    public Text totalCoins;
    public Text waveTimer;
    public float waveCountDown;
    public SpawnScript spawnScript;
    public int addCoins = 10;
    public int wave = 0;
    public bool timerStart = false;
    private int timer;
    public Player player;

    void Start() {
        waveCountDown = spawnScript.spawnTime;
        //StartCoroutine(TimerCount());
    }
    
    // Start is called before the first frame update
    void Update()
    {
        if(waveCountDown <= 0){
            waveCountDown = spawnScript.spawnTime;
        }else{

        }

        
    }

    public void Scored(){
        count++;
        killCount.text = count.ToString();
        player.moedas = addCoins;
        totalCoins.text = player.moedas.ToString();
        addCoins += 10;        
        
    }

    public IEnumerator TimerCount()
    {
        timerStart = true;
        while(true){
            for(int i = 0; i < (int) waveCountDown; i++){
                waveCountDown -= 1;
                timer = (int) waveCountDown;
                waveTimer.text = timer.ToString();
                yield return new WaitForSeconds(1);
            }
        }
        
            
    }
}
