using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class TimeLine : MonoBehaviour
{
    private Camera cam;
    public GameObject Player;


    void Start() {
        Debug.Log(cam.depth);
        Player.SetActive(true);
        Invoke("Reset",9.55f);

    }

    void Reset() {
        Destroy(cam);
    }
}
