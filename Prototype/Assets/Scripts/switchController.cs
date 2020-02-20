using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchController : MonoBehaviour
{
    public GameObject gameManager;
    private CameraControl CC;
    // Start is called before the first frame update
    void Start(){
        CC = gameManager.GetComponent<CameraControl>();
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.RightShift)){
            CC.SwitchScreens();
        }
    }

    
}
