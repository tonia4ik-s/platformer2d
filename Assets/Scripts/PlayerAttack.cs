using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator _animator;
    private PlayerInput _playerInput;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput.Attack)
        {
            
        }
    }
}
