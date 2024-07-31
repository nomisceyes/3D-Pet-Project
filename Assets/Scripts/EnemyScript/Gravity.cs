using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _groundCheckPoint;

    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _groundRadius = 0.4f;
    [SerializeField] private bool _isGrounded;

    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Vector3 _velocity;

    private void Update()
    {
        IsGrounded();
        GravityLogic();
    }

    private void GravityLogic()
    {
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void IsGrounded()
    {
        _isGrounded = Physics.CheckSphere(_groundCheckPoint.position, _groundRadius, _groundMask);
    }
}
