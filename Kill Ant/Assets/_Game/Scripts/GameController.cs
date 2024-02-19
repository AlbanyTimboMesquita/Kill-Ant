using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;
    [HideInInspector] public int totalScore;
    [HideInInspector] public int enemyCount;
    private UiController uiController;
    public Transform allEnemiesParent;
    [HideInInspector] public int highScore;
    
    private Spawner spawner;

    private void Awake() {
        uiController = FindObjectOfType<UiController>();
        spawner = FindObjectOfType<Spawner>();
        GetScore();
    }
    void Start()
    {
        
        totalScore=0;
        enemyCount=0;
        uiController = FindObjectOfType<UiController>();
        spawner = FindObjectOfType<Spawner>();
        spawner.gameObject.GetComponent<Spawner>().enabled=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart(){
         totalScore=0;
         enemyCount=0;
         uiController.txtScore.text=totalScore.ToString();
         foreach (Transform child in allEnemiesParent.transform)
         {
            Destroy(child.gameObject);
         }

    }
    public void StartGame(){
        
        totalScore=0;
        enemyCount=0;
        uiController.txtScore.text=totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled=true;
    }
    public void SaveScore(){
        if(totalScore> highScore){
        PlayerPrefs.SetInt("highscore",totalScore);
        uiController.txtHighScore.text = "Maior Pontuação: "+totalScore.ToString();

        }
    }
    public int GetScore(){
        highScore = PlayerPrefs.GetInt("highscore");
        
        return highScore;
    }

}
