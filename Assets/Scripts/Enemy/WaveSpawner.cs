using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    //A class with variables that can be reused
    [System.Serializable]
	public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float health;
    }

    [SerializeField]
    public enum SpawnState { Spawning, Counting, Waiting };

    //making an array of copies of the wave class
    public List<Wave> waves = new List<Wave>();
    public int nextWave = 0;

    public Transform[] spawnPoints;

    public float relaxTime = 2f;
    public float waveCountdown;

    private float enemyCheckCountdown = 1f;

    //set a variable of type SpawnState to counting
    public SpawnState state = SpawnState.Counting;

    [Header("Multipliers")]
    public float maxPower = 500f;
    public int enemiesAddedPerRound = 1;
    public float healthMultiplier = 1.05f;


    void Start()
    {
        //set the countdown
        waveCountdown = relaxTime;
    }

    void Update()
    {
               
        if(state == SpawnState.Waiting)
        {
            //Check if there arent any enemies alive
            if (!EnemyIsAlive())
            {
                //Begin a new round
                WaveCompleted();
                return;
            }
            else
            {
                
                //if there are still enemies alive, dont do the rest of the code and return;
                return;
            }
        }

        //if the countdown has reached zero
        if (waveCountdown <= 0)
        {
            //and we are not spawning yet
            if (state != SpawnState.Spawning)
            {
                //start a coroutine with the variables of the next wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            //if the countdown has not reached 0 yet, subtract the time passed since the last frame from the countdown
            waveCountdown -= Time.deltaTime;
        }
    }

    //method for checking if there are any enemies left
    bool EnemyIsAlive()
    { 
        enemyCheckCountdown -= Time.deltaTime;

        //if the countdown has reached 0 (this countdown is here because if we did this every frame it would be very taxing)
        if (enemyCheckCountdown <= 0f)
        {
            enemyCheckCountdown = 1f;
            //check if there are gameobjects in the scene with the enemy tag
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                //return false to the boolean because there are no enemies alive
                return false;
            } 
        }
        //return true because the are still enemies
        return true;
    }

    //Spawning the wave
    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("Spawning Wave: " + _wave.name);
        //Now we are spawning so state should be spawning
        state = SpawnState.Spawning;

       // Looping through each enemy of the wave
        for(int i = 0; i < _wave.count; i++)
        {
            //calling the SpawnEnemy method with the enemy of the current wave
            SpawnEnemy(_wave.enemy);
        }

        state = SpawnState.Waiting;

        // no error thing 
        yield break;
    }

    //Enemy spawning method
    void SpawnEnemy(Transform _enemy)
    {
        if(spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced");
        }
        //Spawn enemy
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, sp.position, sp.rotation);
        //Debug.Log("Spawning Enemy " + _enemy.name);
    }
    void WaveCompleted()
    {
        //Debug.Log("Wave Completed");

        state = SpawnState.Counting;
        waveCountdown = relaxTime;

        if (nextWave + 1 > waves.Count - 1)
        {
            AddWave(waves[nextWave]);
        }
        nextWave++;
    }

    //Add a new class Wave variable to the waves list 
    void AddWave(Wave previousWave)
    {
        waves.Add(new Wave {
            name = "Wave " + (nextWave + 2),
            enemy = previousWave.enemy,
            count = previousWave.count + enemiesAddedPerRound,
            health = previousWave.health * healthMultiplier
            });
    }
}




