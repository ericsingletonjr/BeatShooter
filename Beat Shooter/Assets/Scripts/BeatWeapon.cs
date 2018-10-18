using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatWeapon : MonoBehaviour {

    public Transform ProjectilePoint;
    public GameObject BulletPrefab;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
	}

    void FireWeapon()
    {
        Instantiate(BulletPrefab, ProjectilePoint.position, ProjectilePoint.rotation);
    }
}
