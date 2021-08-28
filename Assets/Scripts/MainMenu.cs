using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuAnimation;
    public Text nomePlayer;
    void Start()
    {
            PlayerPrefs.SetString("playerNome", "Sem Nome");
            PlayerPrefs.SetInt("playerScore", -1);
            PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        
        if(nomePlayer.text == ""){
            PlayerPrefs.SetString("playerNome", "Sem Nome");
            PlayerPrefs.SetInt("playerScore", 0);
        }else{
            PlayerPrefs.SetString("playerNome", nomePlayer.text);
        }
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("playerNome"));
        SceneManager.LoadScene("Game");

    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Ranking(){
        SceneManager.LoadScene("HighScore");
    }
    
    
}
