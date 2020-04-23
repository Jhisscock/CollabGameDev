using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchController : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject topPlayer;
    public GameObject bottomPlayer;
    private CameraControl CC;
    private Room_1 R_1;
    private bool canSwitch = false;
    // Start is called before the first frame update
    void Start(){
        CC = gameManager.GetComponent<CameraControl>();
        R_1 = gameManager.GetComponent<Room_1>();
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
