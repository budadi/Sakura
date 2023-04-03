using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        anim.Play("EnemyAttack1");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
