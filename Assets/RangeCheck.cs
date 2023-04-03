using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask Player;
    bool inRange;
    public GameObject obj;
    Animator anim;

    private void Start() {
        anim=GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {
        inRange=Physics.CheckSphere(obj.transform.position,5f,Player);
        Debug.Log(inRange);

        if(inRange){
            anim.SetBool("inRange",true);
        }
        else{
            anim.SetBool("inRange",false);
        }
    }

    private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(obj.transform.position,2f);
  }
}
