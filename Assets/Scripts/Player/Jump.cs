using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class Jump : MonoBehaviour
{
  
    [SerializeField] private float fallGravity = 2;
    private bool grounded = false;
    private int countJump = 0;
    private Rigidbody2D rb;
    public float force;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask Ground;
    public LayerMask Traps;
    public float TimeCounter;
    public float jumpTime;
    private bool isJumping;
    [SerializeField] float glidingSpeed;
    private float initialGravityscale;






    [SerializeField] private AudioSource jumpSource;
    [SerializeField] private AudioSource bottomSource;

    private ParticleSystem pSDust;
    private ParticleSystem pSjumpDust;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pSDust = GameObject.Find("movingDust").GetComponent<ParticleSystem>();
        pSjumpDust = GameObject.Find("jumpDust").GetComponent<ParticleSystem>();
        initialGravityscale = rb.gravityScale;
    }

    private void OnJump(InputValue value)
    {
        pSDust.Play();
        
       

        if (Physics2D.OverlapCircle(feetPos.position, checkRadius, Ground) == true || Physics2D.OverlapCircle(feetPos.position, checkRadius, Traps) == true)
        {
            grounded = true;
            ResetJumpCounter();
            bottomSource.Play();
        }

       
        if (value.isPressed && (countJump < 6))
        {
            isJumping = true;
            TimeCounter = jumpTime;
            rb.velocity = Vector2.up * force;
            countJump++;
            pSjumpDust.Play();

            if (!jumpSource.isPlaying)
            {
                jumpSource.Play();
            }
        }
        else
        {
            pSjumpDust.Stop();
        }

      
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && rb.velocity.y <= 0)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, -glidingSpeed);
        }
        else
        {
            rb.gravityScale = initialGravityscale;
        }




        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {

            if (TimeCounter > 0)
            {

                rb.velocity = Vector2.up * force;
                TimeCounter -= Time.deltaTime;

            }
            else
            {
                isJumping = false;
            }




        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

    }


    private void ResetJumpCounter() 
    {
        grounded = true;
        countJump = 0;
    }
}
