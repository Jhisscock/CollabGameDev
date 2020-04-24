using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchController : MonoBehaviour
{
    public GameObject gameManager;
    public AudioSource switchSound;
    public GameObject topPlayer;
    public GameObject bottomPlayer;
    private CameraControl CC;
    private Room_1 R_1;
    private bool canSwitch = false;
    // Start is called before the first frame update
    void Start(){
        CC = gameManager.GetComponent<CameraControl>();
        R_1 = gameManager.GetComponent<Room_1>();
        switchSound = gameManager.GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.RightShift)){
            R_1.Room_1_Counter();
            CC.SwitchScreens();
            switchSound.Play();
        }
    }



    void Update(){
        if(Input.GetKeyDown(KeyCode.RightShift)){
            if(topPlayer.activeSelf && Collision.onTopSwitch){
                R_1.Room_1_Counter();
                CC.SwitchScreens();
            }else if(bottomPlayer.activeSelf && Collision.onBottomSwitch){
                R_1.Room_1_Counter();
                CC.SwitchScreens();
            }
        }
    }
    
}
