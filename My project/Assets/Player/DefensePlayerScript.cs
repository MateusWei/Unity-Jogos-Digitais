using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefensePlayerScript : MonoBehaviour
{
    bool isCooldown = false;
    public KeyCode ability;
    Renderer renderer;
    Color c;

    void Start(){
        renderer = GetComponent<Renderer>();
        c = renderer.material.color;
    }

    void Update()
    {
        if (Input.GetKey(ability) && isCooldown == false)
        {
            isCooldown = true;
            StartCoroutine("GetInvulnerable");
        }
    }

    IEnumerator GetInvulnerable(){
        gameObject.tag = "PlayerDefense";
        c.a = 0.5f;
        renderer.material.color = c;
        yield return new WaitForSeconds(5f);
        gameObject.tag = "Player";
        c.a = 1f;
        renderer.material.color = c;
        yield return new WaitForSeconds(15f);
        isCooldown = false;
    }
}
