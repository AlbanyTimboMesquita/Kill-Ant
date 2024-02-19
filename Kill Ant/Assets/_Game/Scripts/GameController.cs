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

    void Start()
    {
        totalScore=0;
        enemyCount=0;
        uiController = FindObjectOfType<UiController>();
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
}
