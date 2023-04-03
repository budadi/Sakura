using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newScenecherryprev : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject);
        if(other.gameObject.tag=="Player"){
            SceneManager.LoadScene("snakeToCherry",LoadSceneMode.Single);
        }
    }
}
