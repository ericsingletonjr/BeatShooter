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
}
