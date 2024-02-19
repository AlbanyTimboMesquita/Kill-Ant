using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetection : MonoBehaviour
{
   private bool tapControl;
   private Enemy enemy;
    void Start()
    {
        enemy= GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectTap();        
    }
    private void DetectTap(){
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            RaycastHit2D hit =Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if(hit.collider != null){
                
                TapObject(hit);
                enemy.Dead();
                tapControl=false;
            }

        }
    }
    private void TapObject(RaycastHit2D hit){
        if(hit.collider.gameObject.CompareTag("Enemy")&& !tapControl){
            tapControl=true;
            hit.collider.gameObject.GetComponent<Enemy>().Dead();
            Debug.Log(hit.transform.name);
        }
    }
}
