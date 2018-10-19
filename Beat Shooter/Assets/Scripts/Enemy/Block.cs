using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public byte BeatType = 0;

    public void Remove()
    {
        Destroy(gameObject);
    }
}
