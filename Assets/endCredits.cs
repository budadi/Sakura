using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endCredits : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable() {
        SceneManager.LoadScene("SIMPS",LoadSceneMode.Single);
    }
}