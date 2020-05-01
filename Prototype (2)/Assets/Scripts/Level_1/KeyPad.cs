using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KeyPad : MonoBehaviour
{
    private bool inKeyPad;
    private string correctCode = "1234";
    public TextMeshProUGUI textMesh;
    public GameObject textCanvas;
    public GameObject elevatorBottom;
    public GameObject elevatorTop;
    public AudioSource typing;

    // Start is called before the first frame update
    void Start()
    {
        typing = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && inKeyPad){
            typing.Play();
            textMesh.text += 1.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && inKeyPad){
            typing.Play();
            textMesh.text += 2.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && inKeyPad){
            typing.Play();
            textMesh.text += 3.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && inKeyPad){
            typing.Play();
            textMesh.text += 4.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) && inKeyPad){
            typing.Play();
            textMesh.text += 5.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Alpha6) && inKeyPad){
            typing.Play();
            textMesh.text += 6.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Alpha7) && inKeyPad){
            typing.Play();
            textMesh.text += 7.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Alpha8) && inKeyPad){
            typing.Play();
            textMesh.text += 8.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Alpha9) && inKeyPad){
            typing.Play();
            textMesh.text += 9.ToString();
        }
        if(Input.GetKeyDown(KeyCode.Alpha0) && inKeyPad){
            typing.Play();
            textMesh.text += 0.ToString();
        }
        if(textMesh.text == correctCode && Input.GetKeyDown(KeyCode.E)){
            SceneManager.LoadScene("ElevatorCutScene");
        }
        if(textMesh.text != correctCode && Input.GetKeyDown(KeyCode.E)){
            textMesh.text = "";
        }

        if(textMesh.text.Length > 4){
            textMesh.text = "";
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inKeyPad = true;
            textCanvas.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            inKeyPad = false;
            textMesh.text = "";
            textCanvas.SetActive(false);
        }
    }
}
