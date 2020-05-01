using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Room_34 : MonoBehaviour
{
    private Light2D light2DTop;
    public GameObject lightTop;
    private Light2D light2DBottom;
    public GameObject lightBottom;
    private Light2D light2DMainTop;
    public GameObject mainLightTop;
    private Light2D light2DMainBottom;
    public GameObject mainLightBottom;
    private float currentTime = 0f;
    public float flickerTime = 1f;
    public Color mainColor;
    public Color otherColor;
    // Start is called before the first frame update
    void Start()
    {
        light2DTop = lightTop.GetComponent<Light2D>();
        light2DBottom = lightBottom.GetComponent<Light2D>();
        light2DMainTop = mainLightTop.GetComponent<Light2D>();
        light2DMainBottom = mainLightTop.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.PingPong(Time.time, flickerTime) / flickerTime;
        light2DTop.color = Color.Lerp(Color.white, otherColor, t);
        light2DMainTop.color = Color.Lerp(Color.white, mainColor, t);
        light2DBottom.color = Color.Lerp(Color.white, otherColor, t);
        light2DMainBottom.color = Color.Lerp(Color.white, mainColor, t);
    }
}
