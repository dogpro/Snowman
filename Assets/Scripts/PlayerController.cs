using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _gravity = 10.0f;

    private Vector3 _direction;


    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (_controller.isGrounded)
            _direction = new Vector3(horizontal, 0f, vertical).normalized;
        else
            _direction.y -= _gravity * Time.deltaTime;

        if (_direction.magnitude >= 0.1f)
            _controller.Move(_direction * _moveSpeed * Time.deltaTime);
    }
}
