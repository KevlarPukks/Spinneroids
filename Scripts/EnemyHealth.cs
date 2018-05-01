using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int health = 2;

   public void TakeDamage(int hitPoints)
    {
        health -= hitPoints;
        if(health <= 0)
        {
            GameManager.instance.SmallExplosion(transform.position);
            Destroy(gameObject);
            if (GetComponent<Renderer>().isVisible)
            {
                SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.explosionSound,0.5f);
            }
            int chance = Random.Range(1, 50);
            PowerupSpawner.instance.ShieldBoost(transform.position, chance);
            UIManagerScript.instance.AddScore(10);
        }
    }

}
