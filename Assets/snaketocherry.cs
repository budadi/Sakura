using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snaketocherry : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable() {
        SceneManager.LoadScene("Cherry",LoadSceneMode.Single);
    }
}