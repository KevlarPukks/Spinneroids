using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour {

    public float lifetime = 2f;
    public float speed = 5f;
    public int damage = 1;


    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyScript>())
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.enemyHitSound);
            GameManager.instance.MissileHit(transform.position);

            Destroy(gameObject);
           
        }
        if (collision.gameObject.GetComponent<RockHealth>())
        {
            collision.gameObject.GetComponent<RockHealth>().TakeDamage(1);
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.enemyHitSound);
            GameManager.instance.MissileHit(transform.position);
            Destroy(gameObject);
        }
    }
}
