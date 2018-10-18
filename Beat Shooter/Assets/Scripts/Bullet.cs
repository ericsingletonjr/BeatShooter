using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed = 20f;
    public Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d.velocity = transform.up * Speed;
	}
}
