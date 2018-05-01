using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : EnemyScript {
    public GameObject laser;
    GameObject enemyprojectiles;
    public float laserDistance = 0.2f;
    public float shooterIncrease = 2;
    public float laserIncrease = 1;
    public float laserTime = 2;
    private void Start()
    {
        if (GameObject.Find("enemyProjectiles") == null)
        {
            enemyprojectiles = new GameObject("enemyProjectiles");
        }
        else
        {
            enemyprojectiles = GameObject.Find("enemyProjectiles");
        }
        InvokeRepeating("ShootLaser", 0.1f, laserTime);
    }
    private void FixedUpdate()
    {

        if (wave >= 10 && wave <= 15)
        {
            speed = shooterIncrease;
            
        }
        if (wave > 15)
        {
            speed = 3;
            laserTime = laserIncrease;
        }
    }
    void ShootLaser()
    {
        Vector3 laserPos = transform.position;
        float rotationAngle = transform.localEulerAngles.z - 90;
        laserPos.x += (Mathf.Cos((rotationAngle) * Mathf.Deg2Rad) * -laserDistance);
        laserPos.y += (Mathf.Sin((rotationAngle) * Mathf.Deg2Rad) * -laserDistance);
        if (GetComponent<Renderer>().isVisible)
        {
            SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.enemyLaserSound);
        }
        GameObject enemyLaser = Instantiate(laser, laserPos, transform.rotation) as GameObject;
        enemyLaser.transform.parent = enemyprojectiles.transform;
    }
}
