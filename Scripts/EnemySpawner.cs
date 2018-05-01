using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public static EnemySpawner instance;
    public GameObject enemy;
    public GameObject shooter;
    [Header("Wave Properties")]
    public float timeBeforeSpawning = 1.5f ;
    public float timeBetweenEnemies = 0.25f;
    public float timeBeforeWaves = 2f;
    public int enemiesPerWave = 10;
    public Animator waveWarning;
    GameObject enemies;
    public  int wave = 0;
    EnemyHealth[] enemyHolder;
  
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
        enemies = new GameObject("enemies");
        enemyHolder = FindObjectsOfType<EnemyHealth>();

    }
    

   public IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(timeBeforeSpawning);

        while (true)
        {
            enemyHolder = FindObjectsOfType<EnemyHealth>();
            
          
            if (enemyHolder.Length <= 0 && !LoseScript.isGameover)
            {
                wave++;
                waveWarning.SetTrigger("NewWave");
                SoundManager.instance.sfx.PlayOneShot(SoundManager.instance.newWaveSound,0.4f);
                UIManagerScript.instance.WaveNumber(wave);
                EnemiesPerWave();
                for (int i = 0; i < enemiesPerWave; i++)
                {
                    float randDistance = Random.Range(10, 30);
                    Vector2 randDirection = Random.insideUnitCircle;
                    Vector3 enemyPos = transform.position;
                    enemyPos.x += randDirection.x * randDistance;
                    enemyPos.y += randDirection.y * randDistance;
                    GameObject Enemy = Instantiate(enemy, enemyPos, transform.rotation) as GameObject;
                    Enemy.transform.parent = enemies.transform;
                    
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }
                for (int i = 0; i < enemiesPerWave / 2; i++)
                {
                    float randDistance = Random.Range(10, 30);
                    Vector2 randDirection = Random.insideUnitCircle;
                    Vector3 enemyPos = transform.position;
                    enemyPos.x += randDirection.x * randDistance;
                    enemyPos.y += randDirection.y * randDistance;
                    GameObject Shooter = Instantiate(shooter, enemyPos, transform.rotation) as GameObject;
                    Shooter.transform.parent = enemies.transform;

                
               
                    yield return new WaitForSeconds(timeBetweenEnemies);
                }

               
            }
         
            yield return new WaitForSeconds(timeBeforeWaves);
        }
    }
  

    void EnemiesPerWave()
    {
 switch (wave)
                {
                    case 1:
                        enemiesPerWave = 2;
                        break;
                    case 2:
                        enemiesPerWave = 6;
                        break;
                    case 3:
                        enemiesPerWave = 10;
                        break;
                    case 4:
                        enemiesPerWave = 14;
                        break;
                    case 5:
                        enemiesPerWave = 16;
                        break;
                    case 6:
                        enemiesPerWave = 20;
                        break;

           case 7:
                enemiesPerWave = 22;
                break;
            case 8:
                enemiesPerWave = 26;
                break;
            case 9:
                enemiesPerWave = 28;
                break;
            case 10:
                enemiesPerWave = 32;
                break;
            case 11:
                enemiesPerWave = 32;
                break;
            case 12:
                enemiesPerWave = 36;
                break;
            case 13:
                enemiesPerWave = 40;
                break;
            case 14:
                enemiesPerWave = 44;
                break;
            case 15:
                enemiesPerWave = 50;
                break;
                }
    }
}
