using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public CircleCollider2D playerCollider;
    public int health = 10;
    public void TakeDamage(int hitPoints)
    {
        if (playerCollider.enabled)
        {
            health -= hitPoints;
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.playerHitSound);
            UIManagerScript.instance.HealthSlider(health);
            if(health == 3)
            {
                SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.healthLowSound);
            }
            if (health <= 0)
            {
                health = 0;
                UIManagerScript.instance.HealthSlider(health);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            if (playerCollider.enabled)
            {

                TakeDamage(1);
                
                int chance = Random.Range(1, 50);
               
                PowerupSpawner.instance.ShieldBoost(collision.gameObject.transform.position, chance);
                SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.explosionSound, 0.5f);
                GameManager.instance.SmallExplosion(collision.gameObject.transform.position);
                Destroy(collision.gameObject);
            }
        }
    }
}
