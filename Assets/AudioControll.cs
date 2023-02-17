using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioControll : MonoBehaviour
{
    [SerializeField] private AudioSource StartSound;
    [SerializeField] private AudioSource AmbienteSound;
    // Start is called before the first frame update
    private void Awake()
    {
        StartSound.Play();
        AmbienteSound.Play();
    }
}
