using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    private bool waitActive = false, prepWait = false;
    public GameObject attack, weakPoint, attackPrep, brokenPrism, dad, gameManager, platforms, wall1, wall2, bim, tim, jim, endFade;
    public GameObject attackLight, wpLight, apLight;
    private Color [] colorArray = new Color[]{Color.red, Color.blue, Color.green, Color.yellow};
    public float wait1 = 2f;
    public float wait2 = 6f;
    public float prepTime = 1f;
    public int bossHealth = 3;
    private float currentTime = 0f;
    public float timeToMove = 0.2f;
    private bool isDead = false;
    public Camera mainCamera, newCamera;
    public float moveTime = 0f;
    private bool movedLeft = true;
    private bool hasntHappened = true;
    public AudioClip shatter;
    public AudioClip attackSound;
    public AudioSource sounds;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead){
            if(this.transform.position.x >= 28f && movedLeft){
                this.transform.Translate(-Time.deltaTime, 0f, 0f);
            }else{
                movedLeft = false;
                if(this.transform.position.x <= 39f){
                    this.transform.Translate(Time.deltaTime, 0f, 0f);
                }else{
                    movedLeft = true;
                }
            }
        }
        
        if(gameManager.GetComponent<CameraControl>().topCount == 2 || gameManager.GetComponent<CameraControl>().bottomCount == 2 && hasntHappened){
            hasntHappened = false;
            wall1.SetActive(true);
            wall2.SetActive(true);
            bim.SetActive(true);
            jim.SetActive(false);
            tim.SetActive(false);
            mainCamera.gameObject.SetActive(false);
            newCamera.gameObject.SetActive(true);
        }

        if(bossHealth == 0 && !isDead){
            sounds.loop = false;
            sounds.GetComponent<AudioSource>().Stop();
            sounds.PlayOneShot(shatter);
            isDead = true;
            GetComponent<SpriteRenderer>().enabled = false;
            attack.SetActive(false);
            weakPoint.SetActive(false);
            attackPrep.SetActive(false);
            platforms.SetActive(false);
            brokenPrism.SetActive(true);
            dad.SetActive(true);
            endFade.SetActive(true);
            foreach(Transform child in brokenPrism.transform){
                float x = Random.Range(-300f, 300f);
                float y = Random.Range(-300, 300f);
                child.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y));
            }
        }

        if(isDead){
            time += Time.deltaTime;
            float seconds = time % 60;
            if(seconds >= 3){
                SceneManager.LoadScene("TitleScreen");
            }else{
                endFade.GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f, seconds/3f);
            }
        }

        if(!waitActive && bossHealth != 0){
            int colorNum = Random.Range(0, 4);
            Color randColor = colorArray[colorNum];
            attackLight.GetComponent<Light2D>().color = randColor;
            StartCoroutine(AttackWait(attack, weakPoint, attackPrep));
        }
    }
    IEnumerator AttackWait(GameObject attack, GameObject weakPoint, GameObject attackPrep){
        waitActive = true;
        float waitTime = Random.Range(wait1, wait2);
        attackPrep.SetActive(true);
        yield return new WaitForSeconds(prepTime);
        attackPrep.SetActive(false);
        sounds.loop = true;
        sounds.clip = attackSound;
        sounds.Play();
        attack.SetActive(true);
        weakPoint.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        sounds.loop = false;
        sounds.Stop();
        attack.SetActive(false);
        weakPoint.SetActive(false);
        waitActive = false;
    }
}
