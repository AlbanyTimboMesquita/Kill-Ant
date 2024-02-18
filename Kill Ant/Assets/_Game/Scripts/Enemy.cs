using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();        
    }
    private void Movement(){
        transform.Translate(Vector2.down*(speed*Time.deltaTime));

    }
}
