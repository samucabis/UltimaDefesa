using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{

    private Transform entryContainer;
    private Transform entryTemplate;
    private Highscores highscores;
    private List<HighScoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);
       
       highscoreEntryList = new List<HighScoreEntry>(){
           new HighScoreEntry{score = 0, name = "Nenhum"},
           new HighScoreEntry{score = 0, name = "Nenhum"},
           new HighScoreEntry{score = 0, name = "Nenhum"},
           new HighScoreEntry{score = 0, name = "Nenhum"},
           new HighScoreEntry{score = 0, name = "Nenhum"},
           new HighScoreEntry{score = 0, name = "Nenhum"},
           new HighScoreEntry{score = 0, name = "Nenhum"},
           new HighScoreEntry{score = 0, name = "Nenhum"},
           new HighScoreEntry{score = 0, name = "Nenhum"},
           new HighScoreEntry{score = 0, name = "Nenhum"}
       };

        if(PlayerPrefs.GetString("palyerNome") == "Sem Nome"){
        }else{
            string nome = PlayerPrefs.GetString("playerNome");
            int score = PlayerPrefs.GetInt("palyerScore");
            AddHighScoreEntry(score, nome );
        }
        
        

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        for (int i = 0; i < highscoreEntryList.Count; i++){
            for(int j = i + 1; j < highscoreEntryList.Count; j++){
                if(highscoreEntryList[j].score > highscoreEntryList[i].score){
                    HighScoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }                    
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highscoreEntry in highscoreEntryList){
            CreatHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }


        

    }

    private void CreatHighscoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList){
        float templateHeight = 35f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break; 
        }
        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);



    }

    private void AddHighScoreEntry(int score, string name){
        HighScoreEntry highscoreEntry = new HighScoreEntry {score = score, name = name};
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscoreEntryList.Add(highscoreEntry);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);        
        PlayerPrefs.Save();

    }


    private class Highscores{
        public List<HighScoreEntry> highscoreEntryList ;
    }

    [System.Serializable]
    private class HighScoreEntry {
        public int score;
        public string name;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }

    void Update()
    {
        
    }
}
