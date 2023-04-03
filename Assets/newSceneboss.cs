using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newSceneboss : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag=="Player"){
            SceneManager.LoadScene("cherryToBoss",LoadSceneMode.Single);
        }
    }
}
