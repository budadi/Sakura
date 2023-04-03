using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;

public class HitDetection : MonoBehaviour
{
    public CinemachineFreeLook v1;
    public CinemachineVirtualCamera v2;
    public GameObject health;
    public TextMeshProUGUI comboText;
    Healthbar hb;
    private float lastAttackTime = 0f;
    public float comboTimeLimit = 0.5f;
    int comboCounter;
    bool hasHitEnemy = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
        {
             if (hasHitEnemy) return;
             hasHitEnemy=true;
             Invoke("hitReset",0.5f);
            // Reset combo counter if time limit exceeded
            float timeSinceLastAttack = Time.time - lastAttackTime;
            if (timeSinceLastAttack > comboTimeLimit)
            {
                comboCounter = 0;
                comboText.text = "Hits: " + comboCounter.ToString();
            }

            // Update combo counter and text
            comboCounter++;
            comboText.text = "Hits: " + comboCounter.ToString();

            // Update last attack time
            lastAttackTime = Time.time;

            Animator anim = other.gameObject.GetComponent<Animator>();
            Healthbar hb = other.gameObject.GetComponentInChildren<Healthbar>();

            if (anim != null)
            {
                anim.Play("Great Sword Impact");
            }

            if (hb != null)
            {
                if (hb.fraction == 0.4f)
                {
                    v1.Priority = 0;
                    v2.Priority = 1;
                    Invoke("Slowmotion", 0.8f);
                }
                else{
                    Reset();
                }

                if (hb.fraction == 0.1f)
                {
                    Reset();
                    v1.Priority = 1;
                    v2.Priority = 0;
                }
            }
            else
            {
                Debug.Log("SORRY BOSS");
            }

            // Update combo text display
            comboText.enabled = true;
            Invoke("DisableComboText", 2f);
        }
    }

    void Slowmotion()
    {
        Time.timeScale = 0.2f;
        Invoke("Reset",4f);
    }

    void Reset()
    {
        Time.timeScale = 1f;
    }

    void DisableComboText()
    {
        comboText.enabled = false;
    }

    void hitReset(){
      hasHitEnemy=false;
    }
}
