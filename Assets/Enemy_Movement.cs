using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] private Collider2D TriggerCollider;
    [SerializeField] private float Speedboost = 8f;
    [SerializeField] public float movementSpeed = 1f;
    private Rigidbody2D rb;
 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       


    }

    // Update is called once per frame
    void Update()
    {
        if(IsfacingRight())
        {
          
            rb.velocity = new Vector2(movementSpeed,0f);
        }
        else
        {
           
            rb.velocity = new Vector2(-movementSpeed, 0f);
        }
    }
    private bool IsfacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.name != "Player" )
        {
            transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
        }
       
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            movementSpeed = Speedboost;
        }
     
    }




}
