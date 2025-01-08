using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] Animator _animator;
    [SerializeField] private float _slideSpeed = 10f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform[] _slidePositions;
    [SerializeField] private bool _isGrounded; 
    private int _currentPos = 2;
    private bool _isSliding = false; 

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_slidePositions.Length != 3)
        {
            Debug.LogError("SlidePositions array must contain exactly three elements.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Jump();
        if (Input.GetKeyDown(KeyCode.D)) SlideLeft();
        if (Input.GetKeyDown(KeyCode.A)) SlideRight();
    }

    private void Jump()
    {
        if (!_isGrounded) return;
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _animator.SetTrigger("Jumped");
    }

    private void SlideRight()
    {
        if (_currentPos == 3 || _isSliding) return;
        _currentPos++;
        StartCoroutine(SlideToPosition(_slidePositions[_currentPos - 1].position));
    }

    private void SlideLeft()
    {
        if (_currentPos == 1 || _isSliding) return;
        _currentPos--;
        StartCoroutine(SlideToPosition(_slidePositions[_currentPos - 1].position));
    }

    private System.Collections.IEnumerator SlideToPosition(Vector3 targetPosition)
    {
        _isSliding = true;
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _slideSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        _isSliding = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) _isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground")) _isGrounded = false;
    }
}
