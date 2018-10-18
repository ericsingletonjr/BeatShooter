using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 20f;
    public Rigidbody2D rb2d;

    //TODO: Different flags for the beat types of bullet
    // 0 = quarter, 1 = eighth, 2 = sixteenth
    public byte[] BeatFlag = new byte[] { 0, 1, 2 };
    public byte CurrentBeatType = 0;

    // Use this for initialization
    void Start()
    {
        rb2d.velocity = transform.up * Speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //TODO: Setup for hitting and destroying blocks
        // according to the beat flag
        //Block block = hitInfo.GetComponent<Block>();
        //if(block != null)
        //{
        //    if(CurrentBeatType == block.BeatType)
        //    {
        //        block.Remove();
        //    }
        //}
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
