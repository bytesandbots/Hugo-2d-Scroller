using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float healthMax;
    private float curHealth;
    public Transform RespawnPoint;

    public void TakeDamage(float damage) {
        curHealth-= damage;
        if (curHealth < 0) {
            transform.position = RespawnPoint.position;
            curHealth = healthMax;
        }
        


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "kill") {
            TakeDamage(20);
        }
    }
}
