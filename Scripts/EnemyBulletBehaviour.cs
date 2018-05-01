using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour {

    private Vector3 player;
    public float speed = 2.0f;
  
    private void OnEnable()
    {
     
       
    }
    private void Start()
    {
        Destroy(gameObject, 2.5f);
        if(!LoseScript.isGameover)
         player = GameObject.Find("playerShip").transform.position;
    }
    private void Update()
    {
        Vector3 delta = player - transform.position;
        delta.Normalize();
         float moveSpeed = speed * Time.deltaTime;
         transform.position = transform.position + (delta * moveSpeed);
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            GameManager.instance.MissileHit(transform.position);
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<ShieldHealth>())
        {
            collision.gameObject.GetComponent<ShieldHealth>().TakeDamage(1);
            GameManager.instance.MissileHit(transform.position);
            Destroy(gameObject);
        }
    }

}
