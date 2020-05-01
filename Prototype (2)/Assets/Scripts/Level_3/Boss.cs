using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Boss : MonoBehaviour
{
    private bool waitActive = false, prepWait = false;
    public GameObject topAttack, bottomAttack, topWeakPoint, bottomWeakPoint, topAttackPrep, bottomAttackPrep, walls1Top, walls1Bottom, walls2Top, walls2Bottom, brokenPrism, dad, gameManager, finalBoss;
    public GameObject topALight, bottomALight, topWPLight, bottomWPLight, topAPLight, bottomAPLight;
    private Color [] colorArray = new Color[]{Color.red, Color.blue, Color.green, Color.yellow};
    public float wait1 = 2f;
    public float wait2 = 6f;
    public float prepTime = 1f;
    public int bossHealth = 9;
    private float currentTime = 0f;
    public float timeToMove = 0.2f;
    private bool isDead = true;
    public Camera mainCamera;
    public AudioSource attackSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {     
        if(bossHealth == 6 && currentTime <= timeToMove){
            walls1Top.SetActive(false);
            walls1Bottom.SetActive(false);
            currentTime += Time.deltaTime;
            this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(23.14f, this.transform.position.y), currentTime/timeToMove);
        }else if(bossHealth == 6){
            currentTime = 0;
        }

        if(bossHealth == 3 && currentTime <= timeToMove){
            //6.024092 camera size, y position :  2.05, width = 0.85
            walls2Top.SetActive(false);
            walls2Bottom.SetActive(false);
            currentTime += Time.deltaTime;
            this.transform.position = Vector2.Lerp(this.transform.position, new Vector2(33.35f, 5.93f), currentTime/timeToMove);
            finalBoss.SetActive(true);
            this.gameObject.SetActive(false);
        }

        if(!waitActive){
            int attackNum = Random.Range(0, 2);
            int colorNum = Random.Range(0, 4);
            GameObject attack = null, weakPoint = null, attackPrep = null;
            Color randColor = colorArray[colorNum];
            if(attackNum == 0){
                attack = topAttack;
                weakPoint = topWeakPoint;
                attackPrep = topAttackPrep;
                topALight.GetComponent<Light2D>().color = randColor;
                topAPLight.GetComponent<Light2D>().color = randColor;
            }else if(attackNum == 1){
                attack = bottomAttack;
                weakPoint = bottomWeakPoint;
                attackPrep = bottomAttackPrep;
                bottomALight.GetComponent<Light2D>().color = randColor;
                bottomAPLight.GetComponent<Light2D>().color = randColor;
            }
            StartCoroutine(AttackWait(attack, weakPoint, attackPrep));
        }
    }
    IEnumerator AttackWait(GameObject attack, GameObject weakPoint, GameObject attackPrep){
        waitActive = true;
        float waitTime = Random.Range(wait1, wait2);
        attackPrep.SetActive(true);
        yield return new WaitForSeconds(prepTime);
        attackPrep.SetActive(false);
        attackSound.GetComponent<AudioSource>().Play();
        attack.SetActive(true);
        weakPoint.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        attackSound.GetComponent<AudioSource>().Stop();
        attack.SetActive(false);
        weakPoint.SetActive(false);
        waitActive = false;
    }
}
