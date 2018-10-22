using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBoxController : MonoBehaviour
{
    //mushroom spawner
    public float playerHitWidth;
    public float playerHitHeight;
    public LayerMask isPlayer;
    public Transform playerHitBox;
    public SpriteRenderer mushroom;
    private bool shroomBoxHit;
    private bool playerHit;

    void Start()
    {
        //gameObject.SetActive(false);
    }
    void FixedUpdate()
    {

        playerHit = Physics2D.OverlapBox(playerHitBox.position, new Vector2(playerHitWidth, playerHitHeight), isPlayer);

        if (playerHit == true)
        {
            mushroom.enabled = true;
        }
    }

}
