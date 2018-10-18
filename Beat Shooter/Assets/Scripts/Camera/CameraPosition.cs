using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Vector2 Velocity;
    public GameObject Player;
    public float SmoothTimeX = 0.15f;
    public float ForwardPosition = 10f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        float positionX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x + ForwardPosition, ref Velocity.x, SmoothTimeX);

        transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
    }
}
    