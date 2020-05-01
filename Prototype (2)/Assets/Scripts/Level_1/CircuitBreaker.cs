using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreaker : MonoBehaviour
{
    public GameObject circuitbreaker_on;
    public GameObject bottomLightMain;
    public GameObject bottomLightBulb;
    public GameObject bottomKeyPad;
    private bool inCB = false;
    public GameObject computer;
    public AudioSource computerSound;
    // Start is called before the first frame update
    void Start()
    {
        computerSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inCB && Input.GetKeyDown(KeyCode.E)){
            computerSound.Play();
            computer.SetActive(true);
            bottomKeyPad.SetActive(true);
            bottomLightBulb.SetActive(true);
            bottomLightMain.SetActive(true);
            circuitbreaker_on.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inCB = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inCB = false;
        }
    }
}
