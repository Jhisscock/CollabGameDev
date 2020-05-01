using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    private bool inWeakPoint = false;
    public GameObject boss;
    public GameObject player;
    public GameObject attack;
    public GameObject gameManager;
    private float currentTime = 0f;
    public float timeToMove = 0.2f;
    private bool reset = false;
    private bool canHit = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(inWeakPoint && canHit){
            this.boss.GetComponent<Boss>().bossHealth -= 1;
            attack.SetActive(false);
            canHit = false;
            reset = true;
        }
        if(gameManager.GetComponent<CameraControl>().topCount == 0 || gameManager.GetComponent<CameraControl>().bottomCount == 0){
            if(reset && currentTime <= timeToMove){
                currentTime += Time.deltaTime;
                if(player.gameObject.name == "Tim"){
                    player.transform.position = Vector2.Lerp(player.transform.position, new Vector2(-7f, 1.06f), currentTime/timeToMove);
                }else{
                    player.transform.position = Vector2.Lerp(player.transform.position, new Vector2(-7f, -2.95f), currentTime/timeToMove);
                }

            }
            if(player.transform.position.x >= -7f && player.transform.position.x <= -6.75f){
                reset = false;
                currentTime = 0;
                canHit = true;
            }
        }else if(gameManager.GetComponent<CameraControl>().topCount == 1 || gameManager.GetComponent<CameraControl>().bottomCount == 1){
            if(reset && currentTime <= timeToMove){
                currentTime += Time.deltaTime;
                if(player.gameObject.name == "Tim"){
                    player.transform.position = Vector2.Lerp(player.transform.position, new Vector2(9.25f, 1.06f), currentTime/timeToMove);
                }else{
                    player.transform.position = Vector2.Lerp(player.transform.position, new Vector2(9.25f, -2.95f), currentTime/timeToMove);
                }
                
            }
            if(player.transform.position.x >= 8.75f && player.transform.position.x <= 9.25f){
                reset = false;
                currentTime = 0;
                canHit = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && canHit){
            inWeakPoint = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inWeakPoint = false;
        }
    }
}
