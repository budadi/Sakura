using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    CinemachineImpulseSource impulse;
    public GameObject player;
    private Animator anim;
    // Start is called before the first frame update
    public bool isShaking=false;
    void Start()
    {
        impulse = transform.GetComponent<CinemachineImpulseSource>();
        anim=player.GetComponent<Animator>();
    }

    public void shake(float force){
        impulse.GenerateImpulse(force);
        isShaking=true;
        Invoke("Reset",2f);
        // anim.Play("shake");
    }

     private void Reset() {
        isShaking=false;
    }

    // Update is called once per frame
}
