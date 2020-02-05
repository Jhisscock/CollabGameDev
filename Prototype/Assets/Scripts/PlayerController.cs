using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public static bool topOpen = false;
    public static bool bottomOpen = true;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);
        Walk(dir);
    }

    void Walk(Vector2 n){
        rb.velocity = new Vector2(n.x * speed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "topOpen"){
            topOpen = true;
        }
        if(other.gameObject.tag == "bottomOpen"){
            bottomOpen = true;
        }
    }
}
