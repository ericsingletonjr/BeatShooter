using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatWeapon : MonoBehaviour
{

    public Transform ProjectilePoint;
    public Bullet BulletPrefab;
    public float WaitModifier = 0.5f;
    public int FFTScale = 100;
    public int Threshold = 20;
    public float Tempo = 110;
    public int BeatFlag = 0;

    private bool _fired = false;
    private float _timePressed;
    private float[] _beatDivision = new float[3];

    void Start()
    {
        _beatDivision[0] = 60 / Tempo;
        _beatDivision[1] = 30 / Tempo;
        _beatDivision[2] = 15 / Tempo;
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        BeatSwitch();
        if (!_fired && Time.time > _timePressed + _beatDivision[BeatFlag])
        {
            _timePressed = Time.time;
            _fired = true;
            FireWeapon();
        }
        else
        {
            _fired = false;
        }
    }

    void FireWeapon()
    {
        Instantiate(BulletPrefab, ProjectilePoint.position, ProjectilePoint.rotation).ChangeBeatFlag(BeatFlag);
    }

    void BeatSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) BeatFlag = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) BeatFlag = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) BeatFlag = 2;
    }
}
