using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private float minDistance,maxDistance,spawnTime;
    private float minX,maxX,nextSpawn;

    [SerializeField] private GameObject[] enemies;
    void Start()
    {
        nextSpawn = Time.time;
        SetMinAndMaxX();
    }

    // Update is called once per frame
    void Update()
    {
       Spawn(); 
    }
    private void SetMinAndMaxX(){
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width,0f,0f));
        minX = - bounds.x + minDistance;
        maxX = bounds.x + maxDistance;
    }
    private void Spawn(){
        if(Time.time > nextSpawn){
            Vector2 position = new Vector2(Random.Range(minX,maxX),transform.position.y);
            Instantiate(enemies[Random.Range(0,enemies.Length)],new Vector2(position.x,position.y),Quaternion.Euler(0f,0f,0f));
            nextSpawn =Time.time+spawnTime;

        }

    }
}