using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        anim.Play("Plant");
    }
  
}
