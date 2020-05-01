using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switchController : MonoBehaviour
{
    public GameObject gameManager;
    public AudioSource switchSound;
    public GameObject topPlayer;
    public GameObject bottomPlayer;
    private CameraControl CC;
    private Room_1 R_1;
    private bool canSwitch = false;
    private bool inSwitch = false;
    // Start is called before the first frame update
    void Start(){
        CC = gameManager.GetComponent<CameraControl>();
        R_1 = gameManager.GetComponent<Room_1>();
        switchSound = gameManager.GetComponent<AudioSource>();
    }




    void Update(){
        if(SceneManager.GetActiveScene().name == "Level_2_alt"){
            inSwitch = true;
        }
        if(inSwitch && Input.GetKeyDown(KeyCode.RightShift)){
            if(topPlayer.activeSelf){
                R_1.Room_1_Counter();
                CC.SwitchScreens();
                switchSound.Play();
            }else if(bottomPlayer.activeSelf){
                R_1.Room_1_Counter();
                CC.SwitchScreens();
                switchSound.Play();
            }

        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inSwitch = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inSwitch = false;
        }
    }
}
