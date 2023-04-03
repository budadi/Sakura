using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip Water;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        audioSource.clip=Water;
        audioSource.Play();
    }

    // Update is called once per frame
    
}
