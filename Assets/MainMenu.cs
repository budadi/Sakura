using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private float delay=1f;
    [SerializeField]
    
    private float time;
     


    public string first;
    void Start(){

    }

    void Update() {
       time+=Time.deltaTime;
    }

    public void Click(){
         
        if(time>delay)
        {
           Invoke("StartGame",1f); 
           
        }
    }
    public void AudioSource()
    {
        
    }


    public void StartGame(){
        SceneManager.LoadScene("mother story telling",LoadSceneMode.Single);
    }


    

    public void QuitGame(){
      //Invoke("StartGame",1f);
        Debug.Log("Quit");
        Application.Quit();
    }
}
