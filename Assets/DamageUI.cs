    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;


    public class DamageUI : MonoBehaviour
    {
        public GameObject screen;
        public GameObject terrain;
        CameraShake cs;

        private void Awake() {
            cs=terrain.GetComponent<CameraShake>();
        }
        private void Update() {
            if(screen!=null){
                var color=screen.GetComponent<Image>().color;

                if(color.a>0){
                    color.a-=0.01f;

                    screen.GetComponent<Image>().color=color;
                }
            }
        }
        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.CompareTag("Player")){
                gothurt();
            }
        }

        void gothurt(){
            var color= screen.GetComponent<Image>().color;
            color.a=0.8f;
            cs.shake(0.2f);

            screen.GetComponent<Image>().color=color;
        }
    }
