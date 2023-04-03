using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene5 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Player"){
            SceneManager.LoadScene("pre-snake",LoadSceneMode.Single);
        }
    }
}
