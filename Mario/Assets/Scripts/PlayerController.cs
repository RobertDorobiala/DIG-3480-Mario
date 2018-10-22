using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private bool facingRight = true;

    public float speed;
    public float jumpforce;
    public Text winText;
    public Text countText;

    //mushroom spawner
    //public float playerHitWidth;
    //public float playerHitHeight;
    //public LayerMask isPlayer;
    //public Transform playerHitBox;
    //private bool playerHit;

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    //box check
    private bool isBoxHit;
    public Transform boxcheck;
    public float boxcheckRadius;
    public LayerMask CoinBox;
    public int numberOfCoins;


    // private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;

    //audio stuff
    private AudioSource source;
    public AudioClip jumpClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private int count;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        winText.text = "";
        count = 0;
        SetCountText();

    }

    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    private void Update()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("escape"))
            Application.Quit();

        float moveHorizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        isBoxHit = Physics2D.OverlapCircle(boxcheck.position, boxcheckRadius, CoinBox);

        //playerHit = Physics2D.OverlapBox(playerHitBox.position, new Vector2(playerHitWidth, playerHitHeight), isPlayer);

        if (isBoxHit == true)
        {
            numberOfCoins = numberOfCoins - 1;
            count = count + 1;
            SetCountText();
        }

        if(numberOfCoins <= 0)
        {
            numberOfCoins = 0;
            SetCountText();
        }

        //if (playerHit == true)
        {
            
        }

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.velocity = Vector2.up * jumpforce;


                // Audio stuff

                float vol = Random.Range(volLowRange, volHighRange); source.PlayOneShot(jumpClip);

            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Mushroom"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("End"))
        {
            winText.text = "You Win";
        }

        float vol = Random.Range(volLowRange, volHighRange); source.PlayOneShot(jumpClip);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
