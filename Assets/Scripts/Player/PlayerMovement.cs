using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(PlayerInputs))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _smoothTime = .1f;
    [SerializeField] private Transform _camera;
    private float _smoothVelocity;


    private Rigidbody _rb;
    private PlayerInputs _playerInputs;
    private Vector3 _currentMovementDir = Vector3.zero;

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
        if (_playerInputs.MovementDirection == Vector3.zero)
            return;
        _currentMovementDir = _playerInputs.MovementDirection;
        _currentMovementDir = _camera.TransformDirection(_currentMovementDir);
        PlayerRotation();
    }

    private void PlayerMove()
    {
        _rb.velocity = new Vector3(_currentMovementDir.x * _moveSpeed, _rb.velocity.y, _currentMovementDir.z * _moveSpeed);
    }
    private void PlayerRotation()
    {
        float targetAngle = Mathf.Atan2(_currentMovementDir.x, _currentMovementDir.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _smoothVelocity, _smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

}
