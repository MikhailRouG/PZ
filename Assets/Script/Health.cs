using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Action<int> OnDamaged;
    [SerializeField] private int _health;

    public void TakeDamage(int damage)
    {
        if (_health <= 0) return;
        _health -= damage;
        OnDamaged?.Invoke(_health);
        if (_health <= 0) Destroy(gameObject);
    }
}
