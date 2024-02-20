using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;
    [HideInInspector] public int totalScore,enemyCount,highScore;
    private UiController uiController;
    public Transform allEnemiesParent;
    private Spawner spawner;
    private Destroyer destroyer;
    [SerializeField] private AudioSource music;
    

    private void Awake() {
        uiController = FindObjectOfType<UiController>();
        spawner = FindObjectOfType<Spawner>();
        destroyer = FindObjectOfType<Destroyer>();
        GetScore();
    }
    void Start()
    {
        
        totalScore=0;
        enemyCount=0;
        uiController = FindObjectOfType<UiController>();
        spawner = FindObjectOfType<Spawner>();
        spawner.gameObject.GetComponent<Spawner>().enabled=false;
        music.volume=0.4f;
        
    }
    public void GameOver(){
        spawner.gameObject.GetComponent<Spawner>().enabled=false;
        destroyer.gameObject.GetComponent<BoxCollider2D>().enabled=false;
        DestruirInimigosRestantes();
        uiController.txtPontuacaoAtual.text = "Pontuação Atual: "+totalScore.ToString();
    }

    public void DestroyEnemy(Collider2D target){

        enemyCount++;
        if(enemyCount<5){
            uiController.imageLifes[enemyCount - 1].gameObject.SetActive(false);
        }else{
            uiController.panelGameOver.gameObject.SetActive(true);
            GameOver();
            SaveScore();         
            }
        Destroy(target.gameObject);
    }
    public void Restart(){
         totalScore=0;
         enemyCount=0;
         uiController.txtScore.text=totalScore.ToString();
         spawner.gameObject.GetComponent<Spawner>().enabled=true;
         destroyer.gameObject.GetComponent<BoxCollider2D>().enabled=true;
         DestruirInimigosRestantes();
    }
    public void StartGame(){
        
        totalScore=0;
        enemyCount=0;
        uiController.txtScore.text=totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled=true;
        music.volume=0.1f;

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

    public void StopGame(){
        
        totalScore=0;
        enemyCount=0;
        uiController.txtScore.text=totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled=false;
        DestruirInimigosRestantes();
    }
    public void BackToMainMenu(){
        music.volume=0.4f;
    }

    public void DestruirInimigosRestantes(){
        foreach (Transform child in allEnemiesParent.transform)
         {
            Destroy(child.gameObject);
         }

    }
}
