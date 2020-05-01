using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene2 : MonoBehaviour
{

  public GameObject gameManager;
  public AudioSource switchSound;
  private CameraControl CC;

    // Start is called before the first frame update
    void Start()
    {

      CC = gameManager.GetComponent<CameraControl>();
      switchSound = gameManager.GetComponent<AudioSource>();

      playsound();

    }

public void cutSwitch()
{
  CC.SwitchScreens();
    switchSound.Play();
}

public void playsound()
{
  switchSound.Play();
}


}
