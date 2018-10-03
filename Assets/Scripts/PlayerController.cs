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

    private float groundCheckRadius = 0.2f;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayers);

        float move = Input.GetAxis("Horizontal");
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

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
