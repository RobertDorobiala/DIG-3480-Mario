using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{

    //audio stuff
    private AudioSource source;
    public AudioClip endClip;

    void Awake()
    {

        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            source.PlayOneShot(endClip, 1f);
        }
    }

}
