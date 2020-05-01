using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour
{
    public GameObject broom;
    public GameObject GM;
    public bool inCloset = false;
    private bool gotBroom = false;
    public GameObject key;
    public GameObject closetKey;
    public GameObject otherBroom;
    private bool pickedUpKey = false;
    public AudioClip keyUnlcok;
    public AudioClip keyDrop;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){ 
        if(inCloset && Input.GetKeyDown(KeyCode.E) && GM.GetComponent<CameraControl>().switchSides && GM.GetComponent<Room_2>().gotKey){
            audio.PlayOneShot(keyUnlcok);
            GM.GetComponent<Room_2>().topClosetOpen = true;
            closetKey.SetActive(false);
            GetComponent<BoxCollider2D>().enabled = false;
        }else if(inCloset && Input.GetKeyDown(KeyCode.E) && GM.GetComponent<Room_2>().topClosetOpen && !GM.GetComponent<CameraControl>().switchSides){
            audio.PlayOneShot(keyUnlcok);
            broom.SetActive(true);
            GM.GetComponent<Room_2>().gotBroom = true;
            GM.GetComponent<Room_2>().topClosetOpen = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }else if(inCloset && GM.GetComponent<Room_2>().gotBroom && Input.GetKeyDown(KeyCode.E) && !GM.GetComponent<CameraControl>().switchSides){
            audio.PlayOneShot(keyDrop);
            key.SetActive(true);
            pickedUpKey = true;
            GM.GetComponent<Room_2>().gotBroom = false;
            otherBroom.SetActive(false);
        }else if(inCloset && pickedUpKey && Input.GetKeyDown(KeyCode.E) && !GM.GetComponent<CameraControl>().switchSides){
            audio.PlayOneShot(keyUnlcok);
            GM.GetComponent<Room_2>().doorKeyUsed = true;
            key.SetActive(false);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inCloset = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inCloset = false;
        }
    }
}
