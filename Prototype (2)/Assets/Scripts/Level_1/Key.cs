using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject GM;
    private bool inKey;
    public GameObject closetKey;
    // Start is called before the first frame update
    void Start()
    {
        inKey = false;
    }

    void Update(){
        if(inKey && Input.GetKeyDown(KeyCode.E) && GM.GetComponent<CameraControl>().switchSides){
            this.gameObject.SetActive(false);
            closetKey.SetActive(true);
            GM.GetComponent<Room_2>().gotKey = true;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inKey = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inKey = false;
        }
    }
}
