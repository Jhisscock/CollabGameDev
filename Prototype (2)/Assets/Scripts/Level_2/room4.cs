using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class room4 : MonoBehaviour
{
    public GameObject player;
    public GameObject player1;
    public GameObject wrong;
    public GameObject correct;
    public GameObject wrongB;
    public GameObject correctB;

    private bool a;
    private bool b;
    public GameObject lockT;
    public GameObject lockB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<pEntercode>().rightCode && player1.GetComponent<p1EnterCode>().rightCode){
            lockT.SetActive(false);
            lockB.SetActive(false);
            correct.SetActive(true);
            correctB.SetActive(true);
            wrong.SetActive(false);
            wrongB.SetActive(false);
            SceneManager.LoadScene("Scene_3");
        }
        
    }
}
