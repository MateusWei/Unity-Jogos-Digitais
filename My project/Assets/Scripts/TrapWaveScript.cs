using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapWaveScript : MonoBehaviour
{
    public float moveSpeed = 0.01f;
    public float deadZone = -3.8f;

    // Update is called once per frame
    void Update()
    {
        if (!IsGamePaused()){
            transform.position = transform.position + (Vector3.left * moveSpeed);
            
            if(transform.position.x < deadZone){
                Destroy(gameObject);
            }
        }
    }

    bool IsGamePaused(){
        return Time.timeScale == 0f;
    }
}
