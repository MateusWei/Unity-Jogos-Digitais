using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerScript : MonoBehaviour
{
    public GameObject wave;
    public float spawnRate = 7;
    private float timer = 0;
    public float heightOffset = 0.5f;
    private LogicScript logicScript;
    private bool spawnRateDecreased = false;
    void Start()
    {
        spawnWave();
        logicScript = LogicScript.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate){
            timer = timer + Time.deltaTime;
        }else{
            spawnWave();
            timer = 0;
        }

        if (logicScript.playerScore % 5 == 0 && !spawnRateDecreased && spawnRate > 2){
            spawnRate -= 1f;
            spawnRateDecreased = true;
        }

        if (logicScript.playerScore % 5 != 0){
            spawnRateDecreased = false;
        }
    }

    void spawnWave(){
        float lowestPoint = transform.position.y - heightOffset;
        float heighestPoint = transform.position.y + heightOffset;
        Instantiate(wave, new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint), 0), transform.rotation);
    }
}
