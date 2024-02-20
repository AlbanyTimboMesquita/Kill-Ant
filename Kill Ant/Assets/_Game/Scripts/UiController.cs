using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public TMP_Text txtScore,txtHighScore,txtPontuacaoAtual;
    public Image[] imageLifes;
    [SerializeField] private  GameObject panelGame, panelPause, allLifes, panelMainMenu;
    public GameObject panelGameOver;
    private GameController gameController;
    void Start()
    {
      Initialize();  
    }
    private void Initialize(){
        panelMainMenu.gameObject.SetActive(true);
        panelGameOver.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        gameController=FindObjectOfType<GameController>();
        txtHighScore.text = "Maior Pontuação: " + gameController.highScore.ToString();

    }
    public void UpdateScore(int score){
        txtScore.text = score.ToString();
    }
    public void ButtonPause(){
        Time.timeScale = 0f;
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
    }
    public void ButtonResume(){
        Time.timeScale = 1f;
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
    }
    public void ButtonBackMainMenu(){
        Time.timeScale = 1f;
        gameController.StopGame();
        Initialize();
        gameController.BackToMainMenu();
    }

    public void ButtonRestart(){
        Time.timeScale = 1f;
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        panelGameOver.gameObject.SetActive(false);
        gameController.Restart();
        foreach (Transform child in allLifes.transform)
         {
            child.gameObject.SetActive(true);
         }
    }
    public void ButtonStartGame(){

        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.StartGame();
    }

}
