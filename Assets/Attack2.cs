using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Attack2 : MonoBehaviour
{
  public Animator anim;
  EquipmentSystem es;


  private AudioSource audioSource;
  public AudioClip katana1;
  public AudioClip bigattack;
  public bool animPlaying=false;
  public TextMeshProUGUI t2;

  private void Awake()
  {
    audioSource = GetComponent<AudioSource>();
    es=GetComponent<EquipmentSystem>();
  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
{
    if (Input.GetMouseButtonDown(0) && es.currentWeaponInHand!=null)
    {
        anim.Play("katana1");
        animPlaying=true;
        AnimatorStateInfo stateInfo0 = anim.GetCurrentAnimatorStateInfo(0);
        float animLength0 = stateInfo0.length;
        Invoke("Relax",animLength0-0.5f);
        PlayKatana1();
    }
    else if (Input.GetMouseButtonDown(1) && es.currentWeaponInHand!=null)
    {
        anim.Play("BigAttack");
        animPlaying=true;
        AnimatorStateInfo stateInfo1 = anim.GetCurrentAnimatorStateInfo(0);
        float animLength1 = stateInfo1.length;
        Invoke("Relax",animLength1-0.9f);
        BigAttack();
    }
    else if (Input.GetKeyDown(KeyCode.K) && es.currentWeaponInHand!=null)
    {
        anim.Play("katana2");
        animPlaying=true;
        AnimatorStateInfo stateInfo2 = anim.GetCurrentAnimatorStateInfo(0);
        float animLength2 = stateInfo2.length;
        Invoke("Relax",animLength2);
    }
}
  public void PlayKatana1()
  {
    audioSource.clip = katana1;
    audioSource.Play();
  }

  public void BigAttack()
  {
    audioSource.clip = bigattack;
    audioSource.Play();
  }

  void Relax(){
      animPlaying=false;
  }

}
