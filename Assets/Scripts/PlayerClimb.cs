using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimb : MonoBehaviour
{
    [SerializeField] private float climbForce;
    private bool _isLadder;
    private bool _isClimb;
    private float _startGravity;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _startGravity = _rigidbody2D.gravityScale;
    }

    private void Update()
    {
        _isClimb = _isLadder && Mathf.Abs(_playerInput.VerticalAxis) > 0;
        _animator.SetBool("isClimb", _isClimb);
    }

    private void FixedUpdate()
    {
        if (_isClimb)
        {
            _rigidbody2D.gravityScale = 0;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x,
                climbForce * _playerInput.VerticalAxis);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ladder ladder))
        {
            _isLadder = true;
            _animator.SetBool("isOnLadder", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ladder ladder))
        {
            _isLadder = false;
            _animator.SetBool("isOnLadder", false);
            _rigidbody2D.gravityScale = _startGravity;
        }
    }
}
