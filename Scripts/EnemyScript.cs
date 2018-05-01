using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
  
    private Transform player;
    public float speed = 2.0f;
   public int wave;
    public float waveSpeedincrease = 3f;
    private void OnEnable()
    {
        player = GameObject.Find("playerShip").transform;
    }

    private void Update()
    {
        if (!LoseScript.isGameover)
            EnemyMove();
    }
    void EnemyMove()
    {
  wave = EnemySpawner.instance.wave;
        
        if(wave >= 10 && wave <= 15)
        {
            speed = waveSpeedincrease;
        }
        if(wave > 15){
            speed = 4;
        }
        Vector3 delta = player.position - transform.position;
        delta.Normalize();
        float moveSpeed = speed * Time.deltaTime;
        transform.position = transform.position + (delta * moveSpeed);
    }

}
