using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D _rb2d;

    public float Speed;

	void Start ()
    {
        _rb2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        _rb2d.AddForce(movement * Speed);
    }
}
