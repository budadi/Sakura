using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W : MonoBehaviour
{
  // Start is called before the first frame update
  public Material night;
  public Material day;

  bool dayy = true;
  bool nightt = false;
  private void OnTriggerEnter(Collider other)
  {
    Debug.Log("HIT");
    if (other.gameObject.tag == "Player")
    {
        if(dayy){
            RenderSettings.skybox = night;
            dayy=false;
        
        }
        else{
            dayy=true;
            RenderSettings.skybox = day;
        }
    }
  }
}
