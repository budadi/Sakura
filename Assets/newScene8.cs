using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newScene8 : MonoBehaviour
{
    void OnEnable() {
        SceneManager.LoadScene("T2",LoadSceneMode.Single);
    }
}
