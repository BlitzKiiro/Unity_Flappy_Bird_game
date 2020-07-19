using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Manager manager;
    public float velocity;
    private Rigidbody2D rb;
    public AudioSource wing;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
            wing.Play();
           
        }
        if ( rb.velocity.y > rb.gravityScale )
        {
            transform.rotation = Quaternion.AngleAxis(15, new Vector3(0, 0, 1));
        }
        else if ( rb.velocity.y < rb.gravityScale )
        {
            transform.rotation = Quaternion.AngleAxis(-5, new Vector3(0, 0, 1));
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.GameOver();
    }
    
}
