using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscene1 : MonoBehaviour
{
    // Start is called before the first frame update
void OnEnable()    {
        SceneManager.LoadScene("10Years",LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
