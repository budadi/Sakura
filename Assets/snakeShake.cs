using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeShake : MonoBehaviour
{
    CameraShake cs;
    AudioSource audioSource;
    public AudioClip background;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        cs=GetComponent<CameraShake>();
        audioSource=player.GetComponent<AudioSource>();
        audioSource.clip=background;
        audioSource.Play();
        Invoke("shake",5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void shake(){
        cs.shake(2.8f);
        Time.timeScale=0.2f;
    }
}
