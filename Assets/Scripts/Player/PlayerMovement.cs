using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PlayerInputs))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _smoothTime = .1f;
    private float _smoothVelocity;
    private Rigidbody _rb;
    private PlayerInputs _playerInputs;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInputs = GetComponent<PlayerInputs>();
    }
    private void FixedUpdate()
    {
        if (_playerInputs.MovementDirection == Vector3.zero)
        {
            _rb.angularVelocity = Vector3.zero;
            _rb.velocity = Vector3.zero;
            return;
        }
        PlayerMove();
    }
    private void Update()
    {
        if (_playerInputs.MovementDirection == Vector3.zero && _playerInputs.AimDirection == Vector3.zero)
            return;
        if (_playerInputs.AimDirection != Vector3.zero)
        {
            transform.forward = _playerInputs.AimDirection;
            return;
        }
        MoveRotation(_playerInputs.MovementDirection);
    }

    private void PlayerMove()
    {
        _rb.velocity = new Vector3(_playerInputs.MovementDirection.x * _moveSpeed, _rb.velocity.y, _playerInputs.MovementDirection.z * _moveSpeed);
    }
    private void MoveRotation(Vector3 _dir)
    {
        float targetAngle = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _smoothVelocity, _smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

}