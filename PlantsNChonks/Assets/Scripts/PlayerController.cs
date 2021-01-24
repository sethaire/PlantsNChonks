﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public KeyCode jumpKey = KeyCode.W;
    public float speed = 3.0f;
    public float jumpHeight = 300f;
    Rigidbody2D rb;
    bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        transform.position = position;

        //if jumpKey is down Jump & canJump is true, then it'll jump. CanJump turns then to false in order to stop the player from jumping more than once.
        if (Input.GetKeyDown(jumpKey) && canJump == true)
        {
            rb.AddForce(gameObject.transform.up * jumpHeight);
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player collides with the tag Ground, the bool canJump will be true and the player will be able to jump once again.
        if (collision.collider.tag == "Ground")
        {
            canJump = true;
        }
    }

}
