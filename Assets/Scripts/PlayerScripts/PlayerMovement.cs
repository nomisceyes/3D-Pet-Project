using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _groundRadius = 0.4f;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private bool _isGrounded;

    private DefendController _defendController;
    private CharacterController _characterController;
    private Animator _animator;

    private Quaternion _rotationCamera;
    private Vector3 _velocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _defendController = GetComponent<DefendController>();
    }

    private void Update()
    {
        IsGrounded();
        GravityLogic();      
    }

    private void FixedUpdate()
    {
        MoveLogic();
    }

    private void MoveLogic()
    {
        Vector3 movement = Vector3.zero;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0f || verticalInput != 0f)
        {
            movement.x = horizontalInput * _moveSpeed;
            movement.z = verticalInput * _moveSpeed;
            movement = Vector3.ClampMagnitude(movement, _moveSpeed);

            Quaternion initialOrientation = _camera.rotation;
            _camera.eulerAngles = new Vector3(0, _camera.eulerAngles.y, 0);
            movement = _camera.TransformDirection(movement);
            _camera.rotation = initialOrientation;

            Quaternion direction;

            if (!_defendController.UpShield())
            {
                direction = Quaternion.LookRotation(movement);               
            }
            else
            {
                _rotationCamera = _camera.rotation;
                _rotationCamera.x = 0;
                _rotationCamera.z = 0;
                direction = _rotationCamera;
                movement /= 2;
            }
             transform.rotation = Quaternion.Lerp(transform.rotation, direction, _rotateSpeed * Time.deltaTime);
        }
        _animator.SetFloat("speed", movement.sqrMagnitude);

        movement *= Time.deltaTime;
        _characterController.Move(movement);
    }

   /* private void JumpLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            _animator.SetTrigger("Jump");
        }
    }*/

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
