using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    void OnEnable() {
        SceneManager.LoadScene("T1",LoadSceneMode.Single);
    }
}