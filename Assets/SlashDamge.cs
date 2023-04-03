using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashDamge : MonoBehaviour
{
    Movement mv;
    DamageHandler dh;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        mv=GetComponent<Movement>();
        dh=Enemy.GetComponent<DamageHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mv.isSlashing){
            dh.curHealth-=20;
        }
    }
}
