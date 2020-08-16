using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Timer gameClock;
    Timer spawnTimer;
    int cardinalDir;
    float startSpawnTime = 2f;
    int numberOfSpawns = 0;
    float spawnTimerDuration;

    [SerializeField] Transform[] southSpawns;
    [SerializeField] Transform[] westSpawns;

    [SerializeField] GameObject[] faceUp;
    [SerializeField] GameObject[] faceRight;

    void Start()
    {
        gameClock = gameObject.AddComponent<Timer>();
        gameClock.Duration = 60;
        gameClock.Run();

        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.Duration = startSpawnTime;
        spawnTimer.Run();
    }

    void Update()
    {
        CheckAndResetSpawnTimer();

        //Check if game clock done
        if (gameClock.Finished)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void CheckAndResetSpawnTimer(){
        spawnTimerDuration = spawnTimer.totalSeconds;

        if(spawnTimer.Finished){
            Spawn();
            numberOfSpawns++;
            if(spawnTimerDuration > 0.5f){
                spawnTimer.Duration = startSpawnTime - (0.1f * numberOfSpawns);
            }
            spawnTimer.Run();
        }
    }

    void Spawn(){
        //Pick a side
        cardinalDir = Random.Range(1, 3);

        //Check what side
        // 1 = S
        // 2 = W
        if(cardinalDir == 1){
            int whichSpawn = Random.Range(0, 3);
            int whichCar = Random.Range(0, 3);
            GameObject.Instantiate(faceUp[whichCar], southSpawns[whichSpawn].position, Quaternion.identity);
        }

        else if(cardinalDir == 2){
            int whichSpawn = Random.Range(0, 3);
            int whichCar = Random.Range(0, 5);
            GameObject.Instantiate(faceRight[whichCar], westSpawns[whichSpawn].position, Quaternion.identity);
        }
    }
}
