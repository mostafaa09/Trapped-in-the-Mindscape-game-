using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip jump1;
    public AudioClip jump2;
    public AudioClip shootSound;

    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public float moveSpeed;
    public KeyCode L; // Move character left
    public KeyCode R; // Move character right
    public float jumpHeight;
    public KeyCode JumpKey;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;

    private bool grounded;

    
public KeyCode Return; /// determine the keyboard button for shooting
public Transform firepoint; ///determine the position of shooting in the player character 
public GameObject bullet;

public void Shoot(){

Instantiate(bullet, firepoint.position , firepoint.rotation); ///create a new bullet every time the function called
		
}

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rb == null) Debug.LogError("Rigidbody2D component is missing!");
        if (groundCheck == null) Debug.LogError("GroundCheck Transform is not assigned!");
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
    }

    void Update()
    {
        if(Input.GetKeyDown(Return))
    {
    Shoot();
    }

        // Update animator parameters
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", grounded);

        // Move left
        if (Input.GetKey(L))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (spriteRenderer != null) spriteRenderer.flipX = true;
        }

        // Move right
        if (Input.GetKey(R))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (spriteRenderer != null) spriteRenderer.flipX = false;
        }

        // Jump
        if (Input.GetKeyDown(JumpKey) && grounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.RandomizeSfx(jump1, jump2);
        }
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}
