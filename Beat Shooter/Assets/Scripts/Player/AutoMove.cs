using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : PhysicsObject
{

    public float Speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = Vector2.right * Speed;
    }
}
