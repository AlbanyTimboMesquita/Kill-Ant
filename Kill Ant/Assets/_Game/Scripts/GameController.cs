using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;
    [HideInInspector]public int totalScore;

    void Start()
    {
        totalScore=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
