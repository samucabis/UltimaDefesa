using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{   
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public Weapon weapon;
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Return)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume (){
        pauseMenuUI.SetActive(false);
        weapon.isPaused = false;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause (){
        pauseMenuUI.SetActive(true);
        weapon.isPaused = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }
    public void QuitGame(){
        Application.Quit();
    }

    public void HighScore(){
        SceneManager.LoadScene("HighScore");
    }

}
