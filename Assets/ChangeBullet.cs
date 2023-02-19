using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeBullet : MonoBehaviour
{


    [SerializeField] private Sprite earth;
    [SerializeField] private Sprite emptiness;
    [SerializeField] private Sprite sky;
    [SerializeField] private Sprite hell;
    
    

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().sprite == earth)
        {
            GetComponent<BulletMovement>().moveSpeed = 10f;
      
        }
    }
}
