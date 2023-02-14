using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jumping : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    public float force;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask Ground;
    public float TimeCounter;
    public float jumpTime;
    private bool isJumping;
    private float moveInput;





    // Start is called before the first frame update
    void Start()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, Ground);

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            TimeCounter = jumpTime;
            rb.velocity = Vector2.up * force;

        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
          
            if (TimeCounter > 0) {
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
}
