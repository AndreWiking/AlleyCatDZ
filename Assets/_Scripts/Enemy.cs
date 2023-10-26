using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Rigidbody2D rb;
    private float maxOffsetX = 10; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (speed > 0 && transform.position.x > maxOffsetX || speed < 0 && transform.position.x < -maxOffsetX)
        {
            speed *= -1;
            Flip();
        }
    }
}
