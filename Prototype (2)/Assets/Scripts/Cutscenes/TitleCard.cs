using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){
            openScene();
        }
    }

    public void openScene(){
      SceneManager.LoadScene("OpenCutscene");
    }
}
