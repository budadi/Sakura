using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthba;
    public GameObject damage;
    DamageHandler dh;
    public float fraction;
    void Start(){
        dh=damage.GetComponent<DamageHandler>();
        Debug.Log(damage);
    }

    private void FixedUpdate() {
       fraction= (float)dh.curHealth / (float)dh.maxHealth;
       healthba.fillAmount = fraction ;
   }
}