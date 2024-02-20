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
        gameController.DestroyEnemy(target);
    }
   }
}
