using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float health;
    
    [SerializeField]
    private GameObject gameOverUI;
    
    public UnityAction<float> damaged { get; set; }

    private float _startHealth;
    private float _damageTaken;

    private void Start()
    {
        _startHealth = health;
        _damageTaken = 0;
    }

    public void ApplyDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, health);
        _damageTaken += damage;
        
        damaged.Invoke(health / _startHealth);
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void ApplyBonus(float bonus)
    {
        health += bonus;
        damaged.Invoke(health / _startHealth);
    }
    

    private void Die()
    {
        Destroy(gameObject);
        gameOverUI.SetActive(true);
    }
}
