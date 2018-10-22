using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGoombaController : MonoBehaviour
{

    public float speed;
    private Animator anim;


    //player check
    public float playerHitWidth;
    public float playerHitHeight;
    public LayerMask isPlayer;
    public Transform playerHitBox;
    private bool playerHit;

    //ground check
    public float wallHitWidth;
    public float wallHitHeight;
    public LayerMask isGround;
    public Transform wallHitBox;
    private bool wallHit;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);

        if (wallHit == true)
        {
            speed = speed * -1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        playerHit = Physics2D.OverlapBox(playerHitBox.position, new Vector2(playerHitWidth, playerHitHeight), isPlayer);

        if (collision.collider.tag == "Player" && playerHit == true)
        {
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }
}
