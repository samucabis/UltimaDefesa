using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnScript : MonoBehaviour
{

    public float spawnTime;
    public float spawnTimeDelay;
    public GameObject enemy;
    public int wave;
    public int oldWave;
    public float waveCountDown;
    public Transform myTransform;
    public GameObject particleSystem;
    public Text waveCount;
    public Score score;
    Coroutine lastRoutine = null;

    void Awake()
    {
        myTransform = transform;
 
    }
 
    void Start()
    {  
        wave = 1;
        StartCoroutine(SpawnTimeDelay());

        
    }


    IEnumerator SpawnTimeDelay()
    {
        
        while(true){
            if(lastRoutine != null){
                StopCoroutine(lastRoutine);
                Debug.Log("entrou e suipostamente parou");
            }
            for(int i = 0; i < wave; i++){
                if(score)
                    score.waveTimer.text = "Invocando";
                Instantiate(enemy, transform.position, Quaternion.identity);
                Instantiate(particleSystem, transform.position, Quaternion.identity);
                if(waveCount)
                    waveCount.text = wave.ToString();
                yield return new WaitForSeconds(1);
            }

            if(score)                
                lastRoutine = StartCoroutine(score.TimerCount());            
                
            wave++;               
            yield return new WaitForSeconds(spawnTime);
                 
        }
        
            
    }
    

}
