using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _slideSpeed = 10f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private bool _isCrouching = false;
    [SerializeField] private Transform[] _slidePositions;
    private int _currentPos = 2;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //Crouch();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SlideLeft();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            SlideRight();
        }
    }

    private void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void SlideRight()
    {
        if(_currentPos == 3) return;
        if (_currentPos == 2)
        {
            Vector3.MoveTowards(transform.position, _slidePositions[2].position, _slideSpeed * Time.deltaTime);
        }

        if (_currentPos == 1)
        {
            Vector3.MoveTowards(transform.position, _slidePositions[1].position, _slideSpeed * Time.deltaTime);
        }
    }
    private void SlideLeft()
    {
        if(_currentPos == 1) return;
        if (_currentPos == 3)
        {
            Vector3.MoveTowards(transform.position, _slidePositions[1].position, _slideSpeed * Time.deltaTime);
        }

        if (_currentPos == 2)
        {
            Vector3.MoveTowards(transform.position, _slidePositions[0].position, _slideSpeed * Time.deltaTime);
        }
    }
    
    
}
