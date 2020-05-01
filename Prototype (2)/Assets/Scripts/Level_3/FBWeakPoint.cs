using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBWeakPoint : MonoBehaviour
{
    private bool inWeakPoint = false;
    public GameObject boss;
    public GameObject player;
    public GameObject attack;
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
            canHit = false;
            reset = true;
            boss.GetComponent<FinalBoss>().bossHealth -= 1;
            attack.SetActive(false);
        }
        if(reset && currentTime <= timeToMove){
            currentTime += Time.deltaTime;
            player.transform.position = Vector2.Lerp(player.transform.position, new Vector2(33.8f, -2.96f), currentTime/timeToMove);
        }
        if(player.transform.position.x >= 34.1f || player.transform.position.x <= -2.75f){
            reset = false;
            currentTime = 0;
            canHit = true;
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
