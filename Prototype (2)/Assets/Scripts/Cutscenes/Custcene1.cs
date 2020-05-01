using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Custcene1 : MonoBehaviour
{

  public GameObject gameManager;
  public AudioSource switchSound;
  private CameraControl CC;
  private Room_1 R_1;
  private bool canSwitch = false;

    // Start is called before the first frame update
    void Start()
    {

      CC = gameManager.GetComponent<CameraControl>();
      R_1 = gameManager.GetComponent<Room_1>();
      switchSound = gameManager.GetComponent<AudioSource>();

      Invoke("cutSwitch", 13);
      Invoke("cutSwitch", 26);

    }

public void cutSwitch()
{
  CC.SwitchScreens();
    switchSound.Play();
}


}
