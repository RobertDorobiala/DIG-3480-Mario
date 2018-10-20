using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour {

    public float speed;
    public bool wallHit;
    public float wallHitHeight;
    public float wallHitWidth;
    private bool isGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
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

}
