using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeKill : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            SceneManager.LoadScene("Snake",LoadSceneMode.Single);
            // Destroy(other.gameObject);
        }
    }
}
