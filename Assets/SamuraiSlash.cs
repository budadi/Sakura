using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiSlash : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }
  public Transform playerTransform;
  public Transform enemyTransform;
  public float moveSpeed = 1000f;
  public float attackDistance = 2f;


  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.M))
    {
        Debug.Log(playerTransform.position);
        Debug.Log("PRESSED");
        Vector3 direction = enemyTransform.position - playerTransform.position;
        // Debug.Log(direction);
       Vector3 behindEnemy = enemyTransform.position - direction.normalized * attackDistance;
    //    Debug.Log(behindEnemy);
        playerTransform.position = Vector3.MoveTowards(playerTransform.position, behindEnemy, moveSpeed );
        // Trigger the attack animation
    }
  }
}
