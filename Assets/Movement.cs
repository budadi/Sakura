using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
  public ParticleSystem dust;
  public CharacterController controller;
  public float turnSmoothTime = 0.1f;
  float turnSmoothVelocity;
  public float speed = 6f;
  public float walkSpeed = 2f;
  public Transform cam;
  public Animator anim;
  public GameObject enemy;
  EquipmentSystem es;
  public GameObject terrain;
  public GameObject SlashRange;
  private AudioSource audioSource;
  public AudioClip footsteps;
  private bool inPray;
  private bool inBoat;

  public CinemachineFreeLook Main;
  public CinemachineVirtualCamera vcam;
  public LayerMask tree;
  CameraShake cs;
  Attack2 at;
  public float treeRange;
  public float kayakRange;
  public GameObject Check;
  public LayerMask kayak;
  public LayerMask ground;
  public LayerMask Water;
  public LayerMask Enemy;
  bool isJaegar;
  public float jumpHeight = 5f;
  public float gravity = -9f;
  Vector3 velocity;
  bool isGrounded;
  public bool isSliding;

  public Transform playerTransform;
  public Transform enemyTransform;
  public float moveSpeed = 10f;
  public float attackDistance = 100f;
  Vector3 direction;
  Vector3 behindEnemy;
  bool isSlash;
  public bool isSlashing;
  Animator enemyAnim;
  private void Start()
  {
    es = GetComponent<EquipmentSystem>();
    at = GetComponent<Attack2>();
    cs = terrain.GetComponent<CameraShake>();
    audioSource = GetComponent<AudioSource>();
    enemyAnim=enemy.GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {

    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");

    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
    inPray = Physics.CheckSphere(transform.position, treeRange, tree);
    inBoat = Physics.CheckSphere(transform.position, kayakRange, kayak);
    isGrounded = Physics.CheckSphere(Check.transform.position, 0.5f, ground);
    isJaegar = Physics.CheckSphere(transform.position, 1f, Water);
    isSlash = Physics.CheckSphere(SlashRange.transform.position, 2f, Enemy);



    if (Input.GetButtonDown("Jump") && isGrounded)
    {
      velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
      anim.Play("jump");
      // Time.timeScale = 0.2f;
      // Invoke("Reset", 0.5f);
    }
    //gravity
    velocity.y += gravity * Time.deltaTime;
    controller.Move(velocity * Time.deltaTime);

    if (direction.magnitude >= 0.1f && !at.animPlaying && !es.animPlaying && !isSlashing)
    {
      float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
      float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
      transform.rotation = Quaternion.Euler(0f, angle, 0f);

      // Debug.Log(es.currentWeaponInHand);

      Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
      if (Input.GetKeyDown(KeyCode.Tab))
      {
        anim.Play("Slide");
        AnimatorStateInfo stateInfo21 = anim.GetCurrentAnimatorStateInfo(0);
        float animLength21 = stateInfo21.length;
        Invoke("slideReset",animLength21);
        isSliding = true;
      }

      {
      }

      if (es.currentWeaponInHand == null && !inBoat)
      {
        anim.SetBool("isWalk", true);
        controller.Move(moveDir.normalized * speed * Time.deltaTime);
        // CreateDust();

      }

      else
      {
        if (!inBoat)
        {
          anim.SetBool("isSword", true);
          controller.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
        }
        else
        {
          controller.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
        }


      }

    }
    else
    {
      anim.SetBool("isWalk", false);
      anim.SetBool("isSword", false);
      // controller.Move(Vector3.down * 3.8f * Time.deltaTime);
      // z
      if (inPray && Input.GetKeyDown(KeyCode.P))
      {

        anim.Play("Praying");
      }
      if (isJaegar && Input.GetKeyDown(KeyCode.L))
      {

        anim.Play("Pointing");
      }
    }

    if (Input.GetKeyDown(KeyCode.M) && es.currentWeaponInHand)
    {

      direction = playerTransform.position - enemyTransform.position;

      // Check if the player is facing the ene
      if (isSlash)
      {
        Debug.Log(isSlash);
        behindEnemy = enemyTransform.position - direction.normalized * attackDistance;
        playerTransform.position = Vector3.MoveTowards(playerTransform.position, behindEnemy, moveSpeed);
        isSlashing = true;
        anim.Play("Sword");
        enemyAnim.Play("Great Sword Impact");

        // Main.Priority = 0;
        // vcam.Priority = 11;
        Invoke("animReset", 1f);
      }
      else
      {
        Debug.Log("Player is not facing the enemy!");
      }
    }
  }


  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, treeRange);

    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, kayakRange);

    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(Check.transform.position, 0.5f);

    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(SlashRange.transform.position, 7f);
  }

  void PlayWalk()
  {
    audioSource.clip = footsteps;
    audioSource.Play();
  }

  void CreateDust()
  {
    dust.Play();
  }
  void cameraReset()
  {
    Debug.Log("Invoked");
    vcam.Priority = 0;
    Main.Priority = 11;
  }
  void Reset()
  {
    Time.timeScale = 1f;
  }

  void animReset()
  {
    isSlashing = false;
  }

  void slideReset(){
    isSliding=false;
  }


}