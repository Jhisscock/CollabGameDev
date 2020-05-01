using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public LayerMask bossLayer;
    public LayerMask topSwitch;
    public LayerMask bottomSwitch;
    public static bool onGround;
    public static bool onWall;
    public static bool onTopSwitch;
    public static bool onBottomSwitch;
    public static bool onBoss;
    public int wallSide;
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset, bossOffset;
    private Color debugCollisionColor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        onTopSwitch = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, topSwitch);
        onBottomSwitch =  Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, bottomSwitch);
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, wallLayer) || Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, wallLayer);
        onBoss = Physics2D.OverlapCircle((Vector2)transform.position + bossOffset, collisionRadius, bossLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset,bossOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position  + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + bossOffset, collisionRadius);
    }
}
