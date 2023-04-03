using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class SlideSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;
    // Start is called before the first frame update

    Movement mv;
    void Start()
    {
        
        mv=GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mv.isSliding){
            vcam1.Priority=100;
            vcam2.Priority=0;
        }
        else{
            vcam1.Priority=0;
            vcam2.Priority=100;
        }
    }
}
