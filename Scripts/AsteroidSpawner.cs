using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public static AsteroidSpawner instance;
    public GameObject asteroid;
    public GameObject medAsteroid;
    public GameObject smallAsteroid;
    [Header("Wave Properties")]
    public float timeBeforeSpawning = 1.5f;
    public float timeBetweenEnemies = 0.25f;
    public float timeBeforeWaves = 2f;
    public int asteroidsPerWave = 15;
    int currentNumberOfAsteroids;
    GameObject asteroids;
    RockHealth[] rocks;
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
        asteroids = new GameObject("asteroids");
    }
    private void Update()
    {
        StartCoroutine("SpawnAsteroids");
    }
    public IEnumerator SpawnAsteroids()
    {
        yield return new WaitForSeconds(timeBeforeSpawning);
        rocks = FindObjectsOfType<RockHealth>();
        currentNumberOfAsteroids = rocks.Length;

            while(currentNumberOfAsteroids < asteroidsPerWave && !LoseScript.isGameover )
            {
               
                
                    float randDistance = Random.Range(10, 27);
                    Vector2 randDirection = Random.insideUnitCircle;
                    Vector3 enemyPos = transform.position;
                    enemyPos.x += randDirection.x * randDistance;
                    enemyPos.y += randDirection.y * randDistance;
                    GameObject Asteroid = Instantiate(asteroid, enemyPos, transform.rotation) as GameObject;
                    Asteroid.transform.parent = asteroids.transform;
                    
                    yield return new WaitForSeconds(timeBetweenEnemies);
                

            }
          
        
    }
   
   public void SpawnMedRocks(Vector2 Position)
    {
       
        GameObject medRock = Instantiate(medAsteroid,
        Position, Quaternion.identity) as GameObject;
        GameManager.instance.Explosion(Position);
        GameObject medRock2 = Instantiate(medAsteroid,
          Position, Quaternion.identity) as GameObject;
        currentNumberOfAsteroids += 2;
        medRock.transform.parent = asteroids.transform;
        medRock2.transform.parent = asteroids.transform;
    }
    public void SpawnSmallRocks(Vector2 Position)
    {
        GameManager.instance.SmallExplosion(Position);
        GameObject medRock = Instantiate(smallAsteroid,
        Position, Quaternion.identity) as GameObject;
       
        GameObject medRock2 = Instantiate(smallAsteroid,
          Position, Quaternion.identity) as GameObject;
       
        medRock.transform.parent = asteroids.transform;
        medRock2.transform.parent = asteroids.transform;
    }
}
