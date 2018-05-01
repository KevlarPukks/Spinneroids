using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaScript : RockBehaviour {

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHealth>() || collision.gameObject.GetComponent<ShieldHealth>())
        {
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.novaPickupSound);
            animator.SetTrigger("NovaExplode");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<RockHealth>() || collision.gameObject.GetComponent<EnemyHealth>())
        {
            if (collision.gameObject.GetComponent<Renderer>().isVisible)
            {
                SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.explosionSound, 0.5f);
            }
            Destroy(collision.gameObject);
            GameManager.instance.Explosion(collision.gameObject.transform.position);
        }
    }
    void DestroyNova()
    {
        Destroy(gameObject);
    }
}
