using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    Transform CheckPoint;
    public int jumps = 2;
    // Start is called before the first frame update
    void Start()
    {
        CheckPoint = GameObject.Find("Respawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            CheckPoint.position = transform.position;
            collision.gameObject.GetComponent<Platformer>().defaultAdditionalJumps =  jumps;
        }
    }
}
