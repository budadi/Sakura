using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PromptUi : MonoBehaviour
{
    public TextMeshProUGUI t1;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            Time.timeScale=0.2f;
            t1.enabled=true;
            // if(Input.GetButtonDown("Jump")){
            //     t1.enabled=false;
            // }
            // while(t1.enabled){
            //     if(Input.GetButtonDown("Jump")){
            //         t1.enabled=false;
            //     }
            // }
        }
    }
    private void Start() {
        t1.enabled=false;
    }
    private void Update() {
        if(t1.enabled && Input.GetButtonDown("Jump")){
                t1.enabled=false;
                Invoke("slowReset",0.7f);
        }
    }

    void slowReset(){
        Time.timeScale=1f;
    }
}
