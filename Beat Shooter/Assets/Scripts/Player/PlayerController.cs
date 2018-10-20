using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public float MaxSpeed = 7;
    public float JumpSpeed = 7;
    public float JumpMultiplier = 0.25f;

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        targetVelocity = move * MaxSpeed;
    }
}
