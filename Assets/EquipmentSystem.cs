using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
  [SerializeField] GameObject weaponHolder;
  [SerializeField] GameObject weapon;
  [SerializeField] GameObject weaponSheath;
  public Animator anim;

  public GameObject currentWeaponInHand;
  public GameObject currentWeaponInSheath;

  private AudioSource audioSource;
  public AudioClip sheath;
  public AudioClip Draw;
  public bool animPlaying=false;

  private void Awake()
  {
    audioSource = GetComponent<AudioSource>();
  }

  void Start()
  {
    currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
  }

  public void DrawWeapon()
  {
    if (currentWeaponInHand == null) // If weapon is not equipped
    {
      currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        float animLength = stateInfo.length;
        Debug.Log(animLength);
        Invoke("Relax",animLength-0.5f);
      Destroy(currentWeaponInSheath);
      // Play the "weaponequip" animation
    }
  }

  public void SheathWeapon()
  {
    if (currentWeaponInHand != null) // If weapon is equipped
    {
      currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
      AnimatorStateInfo stateInfo1 = anim.GetCurrentAnimatorStateInfo(0);
        float animLength1 = stateInfo1.length;
        Debug.Log(animLength1);
        Invoke("Relax",animLength1-0.9f);
      Destroy(currentWeaponInHand);
      // Play the "sheath" animation
    }
  }

  public void OnAnimationComplete()
  {
    if (currentWeaponInHand != null) // If weapon is equipped
    {
      Destroy(currentWeaponInHand);
      currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
    }
    else // If weapon is not equipped
    {
      Destroy(currentWeaponInSheath);
      currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
    }
    anim.Play("idle"); // Play the "idle" animation
  }

  public void PlaySheath()
  {
    audioSource.clip = sheath;
    audioSource.Play();
  }

  public void PlayDrawWeapon()
  {
    audioSource.clip = Draw;
    audioSource.Play();
  }

  void Relax(){
      animPlaying=false;
  }
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      if (currentWeaponInHand == null)
      {
        anim.Play("Withdrawing Sword");
        animPlaying=true;
      }
      else
      {
        anim.Play("Sheathing Sword ");
        animPlaying=true;
      }
    }
  }
}
