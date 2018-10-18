using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{

    public float GravityModifier = 1f;
    public float MinGroundNormalY = 0.65f;

    protected bool isGrounded;
    protected Vector2 groundNormal;
    protected Vector2 targetVelocity;
    protected Vector2 velocity;
    protected Rigidbody2D rb2d;
    protected ContactFilter2D cf2d;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);

    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        cf2d.useTriggers = false;
        //This is to check our Layer Collision on the Physics2D
        cf2d.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        cf2d.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity() { }

    void FixedUpdate()
    {
        velocity += GravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;
        //isGrounded is set to false since there aren't any registered
        //collisions
        isGrounded = false;
        Vector2 deltaPosition = velocity * Time.deltaTime;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 move = moveAlongGround * deltaPosition.x;
        Movement(move, false);
        move = Vector2.up * deltaPosition.y;
        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;
        //This is to prevent constant collision checking
        //Once our object is within a collider
        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, cf2d, hitBuffer, distance + shellRadius);
            //Clear any old data from previous collisions
            hitBufferList.Clear();
            //Used to grab only the indicies that have collision data
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                //To determine if the player is grounded
                if (currentNormal.y > MinGroundNormalY)
                {
                    isGrounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }
                //Getting the difference between our velocity
                //and currentNormal which will determine if we need to
                //subtract to prevent the player from entering another collider
                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity -= projection * currentNormal;
                }
                float modifiedDistance = hitBuffer[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

        }
        rb2d.position = rb2d.position + move.normalized * distance;
    }
}
