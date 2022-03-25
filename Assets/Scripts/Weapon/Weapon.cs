using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
    private enum WeaponType { MachineGun }
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private Sprite _weaponUISprite;
    [SerializeField] private float _weaponShootDelay;

    [SerializeField] protected int MaxAmmo;
    [SerializeField] protected Pool SnowBallsPool;
    protected int CurrentAmmo;

    public float WeaponShootDelay => _weaponShootDelay;
    public abstract void Shoot(Transform shootPoint, Vector3 dir);
    public abstract void MuzzleEffect(Transform shootPoint);
}
