using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public float MaxSpeed = 7;
    public float JumpSpeed = 7;
    public float JumpMultiplier = 0.25f;

    // Use this for initialization
    void Start()
    {

    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = JumpSpeed;
        }
        else if(Input.GetButtonUp("Jump"))
        {
            if(velocity.y > 0)
            {
                velocity.y *= JumpMultiplier;
            }
        }
        targetVelocity = move * MaxSpeed;
    }
}
