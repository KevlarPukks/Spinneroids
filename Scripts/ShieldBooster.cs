using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBooster :RockBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
   
        if (collision.gameObject.GetComponent<PlayerHealth>() || collision.gameObject.GetComponent<ShieldHealth>())
        {
            Destroy(gameObject);
            GameObject.FindObjectOfType<ShieldHealth>().AddHealth(3);
          
        }
    }
}
