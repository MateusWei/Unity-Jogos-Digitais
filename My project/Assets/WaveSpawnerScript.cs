using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawnerScript : MonoBehaviour
{
    public GameObject wave;
    public float spawnRate = 7;
    private float timer = 0;
    public float heightOffset = 0.6f;
    void Start()
    {
        spawnWave();
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
    }

    void spawnWave(){
        float lowestPoint = transform.position.y - heightOffset;
        float heighestPoint = transform.position.y + heightOffset;
        Instantiate(wave, new Vector3(transform.position.x, Random.Range(lowestPoint, heighestPoint), 0), transform.rotation);
    }
}
