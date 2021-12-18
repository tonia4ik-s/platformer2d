using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private bool facingRight;

    private Animator _animator;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody2D;
    

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_playerInput.HorizontalAxisRaw < 0 && facingRight)
        {
            Flipper.FlipX(transform);
            facingRight = !facingRight;
        }
        else if (_playerInput.HorizontalAxisRaw > 0 && !facingRight)
        {
            Flipper.FlipX(transform);
            facingRight = !facingRight;
        }
        
        _rigidbody2D.velocity = new Vector2(
            _playerInput.HorizontalAxis*force, 
            _rigidbody2D.velocity.y);
        _animator.SetFloat("velocityX", Mathf.Abs(_rigidbody2D.velocity.x));
        
    }

    
}
