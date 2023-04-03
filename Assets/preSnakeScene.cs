using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class preSnakeScene : MonoBehaviour
{
    private void OnEnable() {
        SceneManager.LoadScene("Snake",LoadSceneMode.Single);
    }
}
