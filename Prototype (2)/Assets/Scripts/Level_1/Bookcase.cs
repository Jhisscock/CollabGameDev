using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookcase : MonoBehaviour
{
    public GameObject key;
    private bool inBookcase = false;
    public AudioSource keyDrop;
    // Start is called before the first frame update
    void Start()
    {
        keyDrop = GetComponent<AudioSource>();
    }

    void Update(){
        if(inBookcase && Input.GetKeyDown(KeyCode.E)){
            key.SetActive(true);
            keyDrop.Play();
            GetComponent<BoxCollider2D>().enabled = false;;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inBookcase = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inBookcase = false;
        }
    }
}
