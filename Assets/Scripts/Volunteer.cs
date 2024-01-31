using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volunteer : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float deadSpeed;
    [SerializeField] private float maxFallTime;
    private Rigidbody2D rb;
    private BoxCollider2D groundCollider;
    private Animator anim;
    public bool isAlive = true;
    private bool isGrounded = false;


    private float fallTime = 0f;
    private float timeSinceInstanciation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundCollider = GetComponent<BoxCollider2D>();
    }

    void Update() {
        
        timeSinceInstanciation += Time.deltaTime;

        if (!isGrounded) {
            fallTime += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (isAlive && isGrounded && timeSinceInstanciation > 1f && rb.velocity.x < deadSpeed * Time.deltaTime) {
            MakeUnalive();
        }

        if (isAlive && isGrounded && rb.velocity.x < maxSpeed * Time.deltaTime) {
            rb.AddForce(new Vector2(moveSpeed * Time.deltaTime, 0f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground" || other.tag == "Volunteer")
        {
            if (fallTime > maxFallTime) {
                MakeUnalive();
            }

            isGrounded = true;
            fallTime = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Ground" || other.tag == "Volunteer")
        {
            isGrounded = false;
        }
    }

    private void MakeUnalive() {
        isAlive = false;
        anim.SetBool("isAlive", isAlive);
    }

    public void SwapToBriefcase() 
    {   
        anim.SetBool("hasCase", true);
    }
}
