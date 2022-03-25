using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private bool _canShoot = true;
    private PlayerInputs _playerInputs;
    private void Awake()
    {
        _currentWeapon = _weapons[0];
        _playerInputs = GetComponent<PlayerInputs>();
    }
    private void OnEnable()
    {
        _playerInputs.onShoot += Shoot;
    }
    private void OnDisable()
    {
        _playerInputs.onShoot -= Shoot;
    }

    private void Shoot()
    {
        if (_canShoot)
        {
            _currentWeapon.Shoot(_shootPoint, _playerInputs.AimDirection);
            _canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }
    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_currentWeapon.WeaponShootDelay);
        _canShoot = true;
    }
}
