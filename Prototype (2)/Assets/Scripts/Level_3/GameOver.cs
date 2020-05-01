using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject endFade;
    public GameObject boss;
    private bool playerDied = false;
    private float currentTime = 0;
    public float seconds = 0;
    private bool enabledPerson = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(playerDied){
            boss.GetComponent<Boss>().enabled = false;
            currentTime += Time.deltaTime;
            seconds = currentTime % 60;
            if(seconds >= 3){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }else{
                if(seconds <=1.5f){
                    endFade.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f, seconds/1.5f);
                }else{
                    endFade.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f, 3f - seconds);
                }
            }
        }
    }

    public void Died(){
        GetComponent<SpriteRenderer>().enabled = false;
        endFade.SetActive(true);
        playerDied = true;
    }
}
