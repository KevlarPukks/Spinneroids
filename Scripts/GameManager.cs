using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject explosion;
    public GameObject smallExplosion;
    public GameObject missileHit;
    GameObject explosions;
    public GameObject MissileHit1;
    private void Awake()
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
        explosions = new GameObject("explosions");
    }
    public void Explosion(Vector3 explosionPosition)
    {
        GameObject Explosion1 = Instantiate(explosion,explosionPosition, Quaternion.identity)as GameObject;
        Explosion1.transform.parent = explosions.transform;
 
        Destroy(Explosion1, 4);
    }
    public void SmallExplosion(Vector3 explosionPosition)
    {
        GameObject Explosion1 = Instantiate(smallExplosion, explosionPosition, Quaternion.identity) as GameObject;
        Explosion1.transform.parent = explosions.transform;
        
       
        Destroy(Explosion1, 4);
    }
    public void MissileHit(Vector3 explosionPosition)
    {
         MissileHit1 = Instantiate(missileHit, explosionPosition, Quaternion.identity) as GameObject;
       
        MissileHit1.transform.parent = explosions.transform;
        Destroy(MissileHit1, 1);
    }
}
