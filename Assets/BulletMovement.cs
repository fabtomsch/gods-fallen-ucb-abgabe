using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour
{
    //[SerializeField] private Transform spawnPlace;
    [SerializeField] private float projectileDmg;
    private Rigidbody2D rB;
    [SerializeField] private Transform player;
    [SerializeField] public float moveSpeed = 100f;
    [SerializeField] private Sprite earth;
    [SerializeField] private Sprite emptiness;
    [SerializeField] private Sprite sky;
    [SerializeField] private Sprite hell;
    
   public  PlayerAttack playerAttack;


    private void Start()
    {
        player = GameObject.Find("Playerfigur").transform;

        rB = GetComponent<Rigidbody2D>();
        Vector3 mousePos = Input.mousePosition;
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 startDir = (mousePosInWorld - transform.position).normalized;
        Vector2 velo = new Vector2(startDir.x, startDir.y).normalized;
        rB.velocity = velo * moveSpeed ;
     
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Enemy_Life>().takeLife(projectileDmg);
           

        }
            Destroy(gameObject);
    }

    private void Update()
    {
        float playerHeight = transform.position.y;
        if (GetComponent<SpriteRenderer>().sprite == earth)
        {
            transform.localScale = new Vector3(.7f, .7f, 1f);
            rB.velocity = rB.velocity.normalized * moveSpeed / 3f;
         
        }
        else if (playerHeight > PlayerAnimations.skyDepth && playerHeight < PlayerAnimations.skyHeigth && SceneManager.GetActiveScene().name != "EndBossScene")
        {
            transform.localScale = new Vector3(.45f, .45f, .1f);
            rB.velocity = rB.velocity.normalized * moveSpeed / .5f;
        }

   


    }


}
