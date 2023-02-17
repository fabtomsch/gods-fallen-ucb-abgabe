using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Attack_Area : MonoBehaviour
{
    [SerializeField] private AudioSource attackSound;
    private float attackdelay = 10f;
    private bool canPlaySound = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Playerfigur" )
        {
            if(canPlaySound == true)
            {
                StartCoroutine(SoundDelay());
            }
        
            gameObject.GetComponent<AIPath>().canMove = true;
        }
    }
  
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Playerfigur")
        {
            gameObject.GetComponent<AIPath>().canMove = false;
        }
    } 

    private IEnumerator SoundDelay()
    {
        canPlaySound = false;
        attackSound.Play();
        yield return new WaitForSeconds(attackdelay);
        canPlaySound = true;
    }

}
