using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHealth : RockBehaviour {

    public int health;

    public void TakeDamage(int hitPoints)
    {
        health -= hitPoints;
        if (health <= 0)
        {
            if (GetComponent<Renderer>().isVisible)
            {
SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.explosionSound, 0.5f);
            }
            
            if (tag == "bigAsteroid")
            {
                AsteroidSpawner.instance.SpawnMedRocks(transform.position);
                Destroy(gameObject);
            }
            if (tag == "medAsteroid")
            {
                AsteroidSpawner.instance.SpawnSmallRocks(transform.position);
                Destroy(gameObject);
            }
            if (tag == "smallAsteroid")
            {
                GameManager.instance.SmallExplosion(transform.position);
                int chance = Random.Range(1, 100);
                PowerupSpawner.instance.ShieldBoost(transform.position, chance);
               // PowerupSpawner.instance.RapidFireDrop(transform.position, chance);
                Destroy(gameObject);
            
            }


        }
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<RockHealth>() && collision.gameObject.tag == "bigAsteroid")
        {
            collision.gameObject.GetComponent<RockHealth>().TakeDamage(1);
           TakeDamage(1);
        }
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {

            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(1);
            TakeDamage(1);
            
           
           

        }
        if (collision.gameObject.transform.GetComponentInChildren<ShieldHealth>())
        {

            collision.gameObject.transform.GetComponentInChildren<ShieldHealth>().TakeDamage(1);
            TakeDamage(1);
           
        }
    }
}
