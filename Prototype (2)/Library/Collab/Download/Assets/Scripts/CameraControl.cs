using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject topPlayer;
    public GameObject bottomPlayer;
    public bool switchSides = true;
    public Vector3 screenSize;
    public int topCount = 0;
    public int bottomCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        screenSize = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        mainCamera.cullingMask = ~(1 << 9 | 1 << 12);
        bottomPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //The player switches the view of the camera by masking certain layers and deactivating other players
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            if(switchSides){
                mainCamera.cullingMask = ~((1 << 8) | (1 << 11));
                mainCamera.transform.position = new Vector3(screenSize.x * 2 * bottomCount, mainCamera.transform.position.y, mainCamera.transform.position.z);
                topPlayer.SetActive(false);
                bottomPlayer.SetActive(true);
                switchSides = false;
            }else{
                mainCamera.cullingMask = ~(1 << 9 | 1 << 12);
                mainCamera.transform.position = new Vector3(topCount * screenSize.x * 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
                topPlayer.SetActive(true);
                bottomPlayer.SetActive(false);
                switchSides = true;
            }
        }


        // Converts player position into a point in pixels relative to the camera view 
        //and will move the camera if the player gets close to the edge of the screen
        Vector3 screenPosTop = mainCamera.WorldToScreenPoint(topPlayer.transform.position);
        if((Screen.width - screenPosTop.x <= 5 || Screen.width - screenPosTop.x >= Screen.width - 5) && Screen.width - screenPosTop.x >= 0 && PlayerController.topOpen && switchSides){
            if(screenPosTop.x < Screen.width /2){
                topCount--;
                topPlayer.transform.position -= new Vector3(1,0,0);
                mainCamera.transform.position = new Vector3(screenSize.x * topCount * 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }else{
                topCount++;
                topPlayer.transform.position += new Vector3(1,0,0);
                mainCamera.transform.position = new Vector3(topCount * screenSize.x * 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
        }

        Vector3 screenPosBot = mainCamera.WorldToScreenPoint(bottomPlayer.transform.position);
        if((Screen.width - screenPosBot.x <= 5 || Screen.width - screenPosBot.x >= Screen.width - 5) &&  Screen.width - screenPosBot.x >= 0 && PlayerController.bottomOpen && !switchSides){
            if(screenPosBot.x < Screen.width /2){
                bottomCount--;
                bottomPlayer.transform.position -= new Vector3(1,0,0);
                mainCamera.transform.position = new Vector3(screenSize.x * bottomCount * 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }else{
                bottomCount++;
                bottomPlayer.transform.position += new Vector3(1,0,0);
                mainCamera.transform.position = new Vector3(screenSize.x * 2 * bottomCount, mainCamera.transform.position.y, mainCamera.transform.position.z);
            }
        }
    }
    public void SwitchScreens(){
        if(switchSides){
            mainCamera.cullingMask = ~((1 << 8) | (1 << 11));
            mainCamera.transform.position = new Vector3(screenSize.x * 2 * bottomCount, mainCamera.transform.position.y, mainCamera.transform.position.z);
            topPlayer.SetActive(false);
            bottomPlayer.SetActive(true);
            switchSides = false;
        }else{
            mainCamera.cullingMask = ~(1 << 9 | 1 << 12);
            mainCamera.transform.position = new Vector3(topCount * screenSize.x * 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
            topPlayer.SetActive(true);
            bottomPlayer.SetActive(false);
            switchSides = true;
        }
    }

    public int GetScreenNumber(){
        if(switchSides){
            return topCount;
        }else{
            return bottomCount;
        }
    }
    
}
