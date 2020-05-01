using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool lostHealth = false;
    private bool inAttack = false;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inAttack){
            if(!lostHealth){
                player.GetComponent<PlayerController>().health -= 1;
                lostHealth = true;
            }
            player.GetComponent<PlayerController>().canMove = false;
        }else{
            lostHealth = false;
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            player.GetComponent<PlayerController>().canMove = true;
            inAttack = false;
        }
    }
}
