using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Computer : MonoBehaviour
{
    public GameObject testCanvas;
    private bool codeActive = false;
    private bool inComputer = false;
    public GameObject lightComputer;
    private Light2D light2DComputer;
    public Color firstColor;
    public Color secondColor;
    public float flickerTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        light2DComputer = lightComputer.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, flickerTime) / flickerTime;
        light2DComputer.color = Color.Lerp(firstColor, secondColor, t);
        if(inComputer && Input.GetKeyDown(KeyCode.E)){
            testCanvas.SetActive(true);
            codeActive = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inComputer = true;
            if(codeActive){
                testCanvas.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inComputer = false;
            if(codeActive){
                testCanvas.SetActive(false);
            }
        }
    }
}
