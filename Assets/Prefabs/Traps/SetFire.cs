using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetFire : MonoBehaviour
{
    [SerializeField] private float startTime = 2f;
    [SerializeField] private float duration = 1f;
    private MonoBehaviour fire;
    private float enableTime;
    [SerializeField] private AudioSource FireSound;
    [SerializeField] private Collider2D triggerCollider;
    private bool playerInRange = false;
    private bool hasPlayedSound = false;

    void Start()
    {
        fire = transform.parent.GetComponent<MonoBehaviour>();
        enableTime = startTime;
        triggerCollider.isTrigger = true;
 
    }

    private void Update()
    {
        if (enableTime <= 0)
        {
            enableTime = startTime;
            if (hasPlayedSound)
            {
                gameObject.SetActive(false);
                fire.StartCoroutine(disableFire());
            }
            
        }

        enableTime -= Time.deltaTime;
      
        if(playerInRange && !hasPlayedSound)
        {
            FireSound.Play();
            hasPlayedSound = true;

        }
    }
    
    IEnumerator disableFire()
    {
       
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(true);
        hasPlayedSound = false;
    }



    private void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            playerInRange = true;   
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            playerInRange = false;
        }
    }

}
