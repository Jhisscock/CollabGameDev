using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("nextScene", 13);
    }

    public void nextScene(){
      SceneManager.LoadScene("Level_2_alt");
    }
}
