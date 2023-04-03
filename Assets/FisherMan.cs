using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisherMan : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        anim.Play("Fish");
    }

    // Update is called once per frame
    
}
