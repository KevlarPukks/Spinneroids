using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireScript :RockBehaviour {
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() || collision.gameObject.GetComponent<ShieldHealth>())
        {
            PlayerController.rapidFire = true;
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.rapidFirePickupSound,0.3f);
            FindObjectOfType<PlayerController>().rapidFireTimeLeft = FindObjectOfType<PlayerController>().rapidFireTime;
            Destroy(gameObject);

          
        }
    }

}
