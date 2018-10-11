using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isFacingRight = true;

    [HideInInspector]
    public bool isJumping = false;

    [HideInInspector]
    public bool isGrounded = false;

    public float jumpForce = 650.0f;
    public float maxSpeed = 7.0f;

    public Transform groundCheck;
    public LayerMask groundLayers;

    public Rigidbody2D rb;
    private float groundCheckRadius = 0.2f;


    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetButtonDown("Jump"))
        {
            if (isGrounded == true)
            {
                this.rb.velocity = new Vector2(rb.velocity.x, 0);
                this.rb.AddForce(new Vector2(0, jumpForce));
            }
            else
            {
                Debug.Log("jump pressed while not grounded");
            }
        }
	}

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        float move = Input.GetAxis("Horizontal");
        // float climb = Input.GetAxis("Vertical");

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if((move > 0.0f && isFacingRight == false) || (move < 0.0f && isFacingRight == true))
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x = playerScale.x * -1;
        transform.localScale = playerScale;
    }
}
