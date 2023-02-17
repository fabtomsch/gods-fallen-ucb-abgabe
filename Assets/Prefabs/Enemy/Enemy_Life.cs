using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using Pathfinding;


public class Enemy_Life : MonoBehaviour
{
    [SerializeField] private float life = 2;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource HitSound;
    [SerializeField] private AudioSource DieSound;
    private Color originalColor;


    private void Start()
    {
      
        originalColor = spriteRenderer.color;
    }

    public void takeLife(float dmg)
    {
        
        life -= dmg;
        if(life > 0)
        {
            HitSound.Play();
        }
       
        if (life <= 0)
        {
          
            die();
        }
        else
        {
            StartCoroutine(ShowDamage());
          
        }
    }


    private IEnumerator ShowDamage()
    {
        spriteRenderer.color = Color.Lerp(originalColor, Color.red, 0.45f);
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = originalColor;
    }
    private void die()
    {
        
        anim.SetTrigger("death");
     
        foreach(Collider2D col in GetComponents<Collider2D>())
        {
            col.enabled = false;
        }
        Destroy(gameObject, 0.5f);
        if (TryGetComponent<Rigidbody2D>(out var exists))
        {
            GetComponent<Enemy_Movement>().enabled = false;
          
        }
        else
        {
            gameObject.GetComponent<AIPath>().canMove = false;
        }
        DieSound.Play();
    }
    
} 
