using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  public Animator anim;
  public int comboCount = 0;
  private float comboTimeout = 1f;
  private float comboTimer = 0f;
  public bool animationPlaying = false;
  public float slowMotionTimeScale = 0f; // New variable for slow motion time scale
  private AudioSource audioSource;
  public AudioClip katana1;


  private void Awake()
  {
    audioSource = GetComponent<AudioSource>();
  }

 
  void Update()
  {

    if (Input.GetKeyDown(KeyCode.Q))
    {
      comboCount++;
      comboTimer = comboTimeout;

      if (comboCount == 1)
      {
        anim.Play("katana1");
        animationPlaying = true;
        AnimatorStateInfo stateInfo0 = anim.GetCurrentAnimatorStateInfo(0);
        float animLength0 = stateInfo0.length;
        Invoke("relax", animLength0 - 0.5f);
      }
      else if (comboCount == 2)
      {
        anim.Play("katana1");
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float animLength = stateInfo.length;
        Invoke("combo2", animLength - 0.4f);
      }
      else if (comboCount == 3)
      {
        anim.Play("katana1");
        AnimatorStateInfo stateInfo1 = anim.GetCurrentAnimatorStateInfo(0);
        float animLength1 = stateInfo1.length;
        Invoke("combo2", animLength1 - 0.4f);
        // Invoke("combo3", animLength2);
        // comboCount=0;

      }
      // Set slow motion time scale
    }

    if (comboTimer > 0f)
    {
      comboTimer -= Time.deltaTime;
    }
    else
    {
      comboCount = 0;
    }

    // Reset time scale after attack animation is finished
  }

  private void combo2()
  {
    anim.Play("katana2");
    animationPlaying = true;

    if (comboCount >= 3)
    {
      AnimatorStateInfo stateInfo2 = anim.GetCurrentAnimatorStateInfo(0);
      float animLength2 = stateInfo2.length;
      Invoke("combo3", animLength2 + 1f);
    }
    else
    {
      AnimatorStateInfo stateInfo21 = anim.GetCurrentAnimatorStateInfo(0);
      float animLength21 = stateInfo21.length;
      Invoke("relax", animLength21);
    }
  }

  private void combo3()
  {
    anim.Play("BigAttack");
    animationPlaying = true;

    AnimatorStateInfo stateInfo3 = anim.GetCurrentAnimatorStateInfo(0);
    float animLength3 = stateInfo3.length;
    Invoke("relax", animLength3);
    comboCount = 0;
  }

  private void SlowMotion()
  {
    Time.timeScale = slowMotionTimeScale;
  }
  private void RelaxSlowMotion()
  {
    Time.timeScale = 1f;
  }

  public void PlayKatana1()
  {
    audioSource.clip = katana1;
    audioSource.Play();
  }


  private void relax()
  {
    animationPlaying = false;
  }
}