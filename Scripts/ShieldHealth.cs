using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour {

    public int health = 10;
    public CircleCollider2D playerCollider;
    public CircleCollider2D shieldCollider;
    public SpriteRenderer shieldRenderer;
    private void Start()
    {
        UIManagerScript.instance.ShieldSlider(health);
    }
    public void TakeDamage(int hitPoints)
    {
        health -= hitPoints;
        SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.shieldHitSound);
        UIManagerScript.instance.ShieldSlider(health);

        if (health <= 0)
        {
           if(shieldCollider.enabled)
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.shieldDownSound,0.4f);
            health = 0;
            UIManagerScript.instance.ShieldSlider(health);
            playerCollider.enabled = true;
            shieldCollider.enabled = false;
            shieldRenderer.enabled = false;
            
        }
    }
    public void AddHealth(int healthToAdd)
    {
       
        if(health <= 0)
        {
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.shieldPickupSound,0.5f);
            health += healthToAdd;
            UIManagerScript.instance.ShieldSlider(health);
            playerCollider.enabled = false;
            shieldCollider.enabled = true;
            shieldRenderer.enabled = true;
        }else if(health >= 1 && health<= 14)
        {
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.shieldPickupSound,0.5f);
            health += healthToAdd;
            if (health > 15)
                health = 15;
            UIManagerScript.instance.ShieldSlider(health);
        }
        else if(health >= 15)
        {
            health = 15;
            UIManagerScript.instance.ShieldSlider(health);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            if (shieldCollider.enabled)
            {
                
                TakeDamage(1);
               
                int chance = Random.Range(1, 50);
                 
                PowerupSpawner.instance.ShieldBoost(collision.gameObject.transform.position, chance);
                GameManager.instance.SmallExplosion(collision.gameObject.transform.position);
                SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.explosionSound, 0.5f);
                Destroy(collision.gameObject);
            }
        }
    }
}
