using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("nextScene", 29);
    }

    public void nextScene(){
      SceneManager.LoadScene("Level_1");
    }
}
