using UnityEngine;
using Cinemachine;

public class AxeThrow : MonoBehaviour
{
  public Animator anim;
  public Rigidbody axe;
  public float throwingForce = 10f;
  public Transform target, curve_point;
  private bool isReturning = false;
  public Vector3 old_Pos;
  private float time = 0.0f;
  bool thrown = false;
  public CinemachineFreeLook fpp;
  public CinemachineFreeLook tpp;
  bool isAiming;
  private Camera mainCamera;
  public GameObject currentAxeInHand;
  public GameObject AxeHolder;
  public GameObject AxeinSheath;
  public GameObject Axe;
  public GameObject currentAxeInSheath;

  void Start()
  {
    mainCamera = Camera.main;
    currentAxeInSheath = Instantiate(Axe, AxeinSheath.transform);
  }



  private void Update()
  {
    // Vector3 cameraForwar = Camera.main.transform.forward;
    // transform.forward = new Vector3(cameraForwar.x, 0f, cameraForwar.z).normalized;
    if (Input.GetMouseButtonDown(1) && !thrown)
    {
      isAiming = true;
      // anim.SetBo   ol("throw", true);
      currentAxeInHand = Instantiate(Axe, AxeHolder.transform);
       Destroy(currentAxeInSheath);
      fpp.Priority = 11;
      tpp.Priority = 0;
      // throwAxe();
      anim.Play("throw");


    }
    if (Input.GetMouseButtonUp(0) && isAiming)
    {
      throwAxe();
      Destroy(currentAxeInHand);
      thrown = true;
      isAiming = false;
      Invoke("resetCamera", 0.2f);


    }
    else
    {
      // anim.SetBool("throw", false);
      if (Input.GetKeyDown(KeyCode.LeftControl) && thrown)
      {
        ReturnAxe();
        Invoke("spawnSheath",1f);
        fpp.Priority = 0;
        tpp.Priority = 11;
        thrown = false;
      }

    }
    //
  }


  void FixedUpdate()
  {
    if (isReturning)
    {
      if (time < 1f)
      {
        axe.position = getBQCPoint(time, old_Pos, curve_point.position, target.position);
        time += Time.deltaTime;
        axe.rotation = Quaternion.Slerp(axe.transform.rotation, target.rotation, 10000 * Time.deltaTime);
      }
      else
      {
        ResetAxe();
      }
    }
    //
  }
  void throwAxe()
  {
    isReturning = false;
    axe.transform.parent = null;
    axe.isKinematic = false;

    // Get the forward direction of the camera
    Vector3 cameraForward = Camera.main.transform.forward;

    // Set the throwing direction to be the camera's forward direction
    Vector3 throwingDirection = new Vector3(cameraForward.x, 0f, cameraForward.z).normalized;

    // Add force and torque to the axe to throw it
    axe.AddForce(throwingDirection * throwingForce, ForceMode.Impulse);
    axe.AddTorque(axe.transform.TransformDirection(Vector3.right) * 5000, ForceMode.Acceleration);
  }
  void ReturnAxe()
  {
    time = 0f;
    isReturning = true;
    axe.velocity = Vector3.zero;
    old_Pos = axe.position;
    axe.isKinematic = true;
    thrown = false;
  }

  Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
  {
    float u = 1 - t;
    float tt = t * t;
    float uu = u * u;
    Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
    return p;
  }

  void ResetAxe()
  {
    isReturning = false;
    axe.position = target.transform.position;
    axe.rotation = target.transform.rotation;
    axe.transform.parent = target;
  }
  void resetCamera()
  {
    anim.Play("Breathing Idle");
    fpp.Priority = 0;
    tpp.Priority = 11;
  }
  void spawnSheath(){
      currentAxeInSheath = Instantiate(Axe, AxeinSheath.transform);
  }
}