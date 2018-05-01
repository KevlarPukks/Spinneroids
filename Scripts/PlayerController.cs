using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float deceleration = 0.9f;
    public float topSpeed = 50f;
    public float playerSpeedX;
    public float playerSpeedY;
    public float acceleration = 300f;
    public float timeBetweenRapidFire = 0.1f;
    public static bool rapidFire = false;
    public GameObject laser;
    public float laserDistance = 0.2f;
    public float timeBetweenFires = 0.3f;
    float timeTillNextFire = 0f;
    public List<KeyCode> shootButton;
    GameObject projectiles;
    public Sprite rapidFireBullet;
    public Sprite bullet;
    public SpriteRenderer bulletSpriteRenderer;
    public float rapidFireTimeLeft;
    public  float rapidFireTime = 3;

    private void Start()
    {
        projectiles = new GameObject("projectiles");
        EnemySpawner.instance.StartCoroutine("SpawnEnemies");
        rapidFireTimeLeft = rapidFireTime;
        //  AsteroidSpawner.instance.StartCoroutine("SpawnAsteroids");
    }
    void rotation()
    {
        Vector3 worldPos = Input.mousePosition;
        worldPos = Camera.main.ScreenToWorldPoint(worldPos);

        float dx = transform.position.x - worldPos.x;
        float dy = transform.position.y - worldPos.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(new Vector3(0, 0, angle+90));
        transform.rotation = rot;
    }
    void Movement()
    {
        Vector3 movement = new Vector3();
         playerSpeedX = GetComponent<Rigidbody2D>().velocity.x;
        playerSpeedY = GetComponent<Rigidbody2D>().velocity.y;
        movement.x += Input.GetAxis("Horizontal");
        movement.y += Input.GetAxis("Vertical");
        movement.Normalize();
        if (movement.magnitude > 0)
        {
            var rb = GetComponent<Rigidbody2D>();
          
            
           // transform.Translate(movement * Time.deltaTime * playerSpeed, Space.World);
           rb.AddForce(movement * Time.deltaTime * acceleration, ForceMode2D.Force);
            if (movement.x == 0)
        {
                rb.velocity = new Vector2(rb.velocity.x * deceleration, rb.velocity.y);
        }
            if(movement.y == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * deceleration);
            }
            if(rb.velocity.x > 0 && movement.x < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x * 0.90f, rb.velocity.y);
            }
            if(rb.velocity.x < 0 && movement.x > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x * 0.90f, rb.velocity.y);
            }
            if (rb.velocity.y > 0 && movement.y < 0)
            {
                rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y * 0.90f);
            }
            if (rb.velocity.y < 0 && movement.y > 0)
            {
                rb.velocity = new Vector2( rb.velocity.x,rb.velocity.y * 0.90f);
            }

            if (rb.velocity.x > topSpeed)
                rb.velocity = new Vector2(topSpeed , rb.velocity.y);
            if(rb.velocity.x < -topSpeed)
                rb.velocity = new Vector2(-topSpeed, rb.velocity.y);
            if(rb.velocity.y >topSpeed)
                rb.velocity = new Vector2(rb.velocity.x, topSpeed );
            if (rb.velocity.y < -topSpeed)
                rb.velocity = new Vector2(rb.velocity.x, -topSpeed);
            
        }
        
        else
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x * deceleration, rb.velocity.y * deceleration);

         
        }
    }
    private void Update()
    {
        if (!PauseMenuScript.isPaused)
        {
            Movement();
            rotation();
            Fire();
        }       
    }
    void Fire()
    {
        if (!rapidFire)
        {
            NormalFire();
        }
        else if (rapidFire)
        {
           
            RapidFire();
        }
    }
    void ShootLaser()
    {
        Vector3 laserPos = transform.position;
        float rotationAngle = transform.localEulerAngles.z - 90;
        laserPos.x += (Mathf.Cos((rotationAngle) * Mathf.Deg2Rad) * -laserDistance);
        laserPos.y += (Mathf.Sin((rotationAngle) * Mathf.Deg2Rad) * -laserDistance);
        SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.playerLaserSound);
     GameObject Laser = Instantiate(laser, laserPos, transform.rotation) as GameObject;
        Laser.transform.parent = projectiles.transform;
    }
    void RapidFire()
    {
   
        rapidFireTimeLeft -= Time.deltaTime;
        if (rapidFireTimeLeft >= 0 && rapidFire)
        {
            if (timeTillNextFire < 0)
            {
                bulletSpriteRenderer.sprite = rapidFireBullet;
                timeTillNextFire = timeBetweenRapidFire;

                ShootLaser();
            }
            timeTillNextFire -= Time.deltaTime;
        }
        else if (rapidFireTimeLeft <= 0)
        {

            rapidFire = false;
            rapidFireTimeLeft = rapidFireTime;
        }
       
    }
    void NormalFire()
    {
  if (Input.GetButton("Fire1") && timeTillNextFire < 0)
            {
                bulletSpriteRenderer.sprite = bullet;
                timeTillNextFire = timeBetweenFires;
                ShootLaser();

            }
            timeTillNextFire -= Time.deltaTime;
    }
    
}
