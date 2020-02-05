using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject topPlayer;
    public GameObject bottomPlayer;
    private bool switchSides = true;
    private Vector3 screenSize;
    // Start is called before the first frame update
    void Start()
    {
        screenSize = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        mainCamera.cullingMask = ~(1 << 9);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            if(switchSides){
                mainCamera.cullingMask = ~(1 << 8);
                mainCamera.transform.position = new Vector3((Mathf.Floor(bottomPlayer.transform.position.x/screenSize.x)) * screenSize.x * 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
                topPlayer.SetActive(false);
                bottomPlayer.SetActive(true);
                switchSides = false;
            }else{
                mainCamera.cullingMask = ~(1 << 9);
                Debug.Log(screenSize.x + " : : " + topPlayer.transform.position);
                mainCamera.transform.position = new Vector3((Mathf.Floor(topPlayer.transform.position.x/screenSize.x)) * screenSize.x * 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
                topPlayer.SetActive(true);
                bottomPlayer.SetActive(false);
                switchSides = true;
            }
        }
        Vector3 screenPosTop = mainCamera.WorldToScreenPoint(topPlayer.transform.position);
        if(Screen.width - screenPosTop.x <= 50 && PlayerController.topOpen){
            topPlayer.transform.position += new Vector3(1,0,0);
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + screenSize.x * 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }

        Vector3 screenPosBot = mainCamera.WorldToScreenPoint(bottomPlayer.transform.position);
        if(Screen.width - screenPosBot.x <= 50 && PlayerController.bottomOpen){
            bottomPlayer.transform.position += new Vector3(1,0,0);
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + screenSize.x * 2, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
    }
}
