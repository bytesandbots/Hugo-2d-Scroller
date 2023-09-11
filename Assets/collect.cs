using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public Transform roketplace;
    public GameObject Player;
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
        if (collision.gameObject.tag == "item")
        {
            collision.gameObject.transform.SetParent(roketplace);
            collision.gameObject.transform.localEulerAngles = Vector3.zero;
            collision.gameObject.transform.localPosition = Vector3.zero;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            collision.gameObject.layer=roketplace.gameObject.layer;
            collision.gameObject.GetComponent<jetpack>().ready = true; 
            Player.GetComponent<Platformer>().jumpForce = 15;
            Player.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
            


        }
    }
}
