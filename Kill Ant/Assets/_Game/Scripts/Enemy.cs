using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Animator myAnimator;
    [SerializeField]private GameObject[] sprites;
    private GameController gameController;
    private UiController uiController;

    [SerializeField] private int score;
    void Start()
    {
        myAnimator=GetComponent<Animator>();
        gameController = FindObjectOfType<GameController>();
        uiController=FindObjectOfType<UiController>();
        sprites[0]= this.transform.GetChild(0).gameObject;
        sprites[1]= this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AnimationSpeed();
        AtualizarVelocidadeInimigos();        
    }

    private void AtualizarVelocidadeInimigos()
    {
        
        //speed=1f+((float)Time.timeAsDouble/100) ;
        
    }

    private void Movement(){
        transform.Translate(Vector2.down*(speed*Time.deltaTime));

    }
    private void AnimationSpeed(){
        myAnimator.SetFloat("Speed",speed);
    }

    public void Dead(){
        speed = 0f;
        gameController.totalScore+=score;
        uiController.UpdateScore(gameController.totalScore);
        sprites[0].gameObject.SetActive(false);
        sprites[1].gameObject.SetActive(true);
        Destroy(this.gameObject, Random.Range(2.5f,5f));
    }
    public void PlayAudio(bool isDead){
        if(isDead){
            AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
            audioSource.clip = gameController.audioEnemies[Random.Range(0,gameController.audioEnemies.Length)];
            audioSource.Play();
        }
    }
    
}
