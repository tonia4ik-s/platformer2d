using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHeart : MonoBehaviour
{
    [SerializeField] private float bonus;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.ApplyBonus(bonus);
            Destroy(gameObject);
        }
    }
}
