using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public static bool topOpen = false;
    public static bool bottomOpen = false;
    public float speed = 4f;
    public float jHeight = 5f;
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

        if(Input.GetKeyDown(KeyCode.Space)){
            if(Collision.onGround){
                Jump(Vector2.up, false);
            }
        }
    }

    void Walk(Vector2 n){
        rb.velocity = new Vector2(n.x * speed, rb.velocity.y);
    }

    void Jump(Vector2 n, bool wall){
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += n * jHeight;
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
