using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour {
    public static PowerupSpawner instance;
    public GameObject shieldBoost;
    public GameObject rapidFire;
    public GameObject novaPickup;
    GameObject powerups;
    void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            //  DontDestroyOnLoad(gameObject);

        }
        powerups = new GameObject("powerups");
    }
  public  void ShieldBoost(Vector2 Position, int chance)
    {
       
        if(chance >= 1 && chance <= 5)
        {
            GameObject ShieldBoost1 = Instantiate(shieldBoost, Position, Quaternion.identity) as GameObject;
            ShieldBoost1.transform.parent = powerups.transform;
        }
        else if(chance >= 6 && chance <= 10)
        {
 GameObject RapidFireDrop = Instantiate(rapidFire, Position, Quaternion.identity) as GameObject;
            RapidFireDrop.transform.parent = powerups.transform;
        }
        else if (chance == 11)
        {
            GameObject novaFireDrop = Instantiate(novaPickup, Position, Quaternion.identity) as GameObject;
            novaFireDrop.transform.parent = powerups.transform;
        }
    }

}
