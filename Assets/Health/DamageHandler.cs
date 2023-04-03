using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageHandler : MonoBehaviour
{
  // Start is called before the first frame update

  public float Health = 100;
  public  int maxHealth = 100;
  public  int curHealth=100;
  private Animator anim;
  public bool isdying;
  public GameObject Player;
  EquipmentSystem es;
  private void Start() {
    curHealth = maxHealth;
    anim=GetComponent<Animator>();
    es=Player.GetComponent<EquipmentSystem>();
  }
  // void OnCollisionEnter(Collision co)
  // {
   
  // }
  private void OnTriggerEnter(Collider other) {
     if (other.gameObject.tag == "katana")
    {
      // Debug.Log("GOT HIT");
      curHealth -= 10;
      Debug.Log(curHealth);
      if (curHealth <= 0)
      {
        Debug.Log("THIS GUY"+gameObject.tag);
        if(gameObject.tag=="Enemy"){
          Destroy(gameObject);
        }
        else{
          isdying=true;
        anim.Play("Death");
        }
        // Destroy(gameObject);
        // Invoke("sceneLoader",10f);
      }
      else{
        isdying=false;
        anim.Play("Great Sword Impact");
      }
    }
  }
  private void Update() {
    if(isdying&&es.currentWeaponInSheath){
      SceneManager.LoadScene("endCredits",LoadSceneMode.Single);
    }
  }

  void sceneLoader(){
    SceneManager.LoadScene("endCredits",LoadSceneMode.Single);
  }



}
