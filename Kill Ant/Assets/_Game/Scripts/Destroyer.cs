using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameController gameController;
    private UiController uiController;
 private void Start() {
    gameController = FindObjectOfType<GameController>();    
    uiController= FindObjectOfType<UiController>();
 }
   private void OnTriggerEnter2D(Collider2D target) {
    if(target.gameObject.CompareTag("Enemy")){
        gameController.enemyCount++;
        if(gameController.enemyCount<5){
            uiController.imageLifes[gameController.enemyCount - 1].gameObject.SetActive(false);
        }else{
            uiController.imageLifes[gameController.enemyCount - 1].gameObject.SetActive(false);
            gameController.SaveScore();
            Debug.Log("GaMe OvEr");
            }
        
        Destroy(target.gameObject);
    }
   }
}
