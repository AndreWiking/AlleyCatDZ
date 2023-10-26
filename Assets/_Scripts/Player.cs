using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public UI_Manager uiManager;
    public float speed;
    public float jumpForce;
    public float downForce;
    public LayerMask groundLayer;
    [SerializeField] private int maxHealth = 5;
    private int health;

    private bool isDownJump = false;

    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        startPosition = transform.position;
    }

    void Update()
    {
        Flip();
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Floor"),
            rb.velocity.y > 0 | isDownJump);

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(DownJump());
        }
    }

    IEnumerator DownJump()
    {
        isDownJump = true;
        rb.AddForce(-transform.up * downForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.1f);
        isDownJump = false;
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    bool IsGrounded()
    {
        float distance = 1.0f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, groundLayer);
        return hit.collider;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        var window = other.gameObject.GetComponentInParent<Window>();
        if (window != null && window.IsOpen)
        {
            Win();
        }

        if (other.gameObject.GetComponent<Enemy>() || other.gameObject.GetComponent<Bullet>())
        {
            Lose();
        }

        if (other.gameObject.GetComponent<Spike>())
        {
            StartCoroutine(DownJump());
        }
    }

    private void Win()
    {
        uiManager.ShowWin();
        Time.timeScale = 0;
    }

    private void Lose()
    {
        --health;
        uiManager.ShowDamage();
        if (health <= 0)
        {
            uiManager.ShowLose();
            health = maxHealth;
            transform.position = startPosition;
        }
    }
}