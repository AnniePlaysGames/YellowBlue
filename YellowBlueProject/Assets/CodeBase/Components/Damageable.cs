using System;
using UnityEngine;

namespace CodeBase.Components
{
    public class Damageable : MonoBehaviour
    {
        public Action<GameObject> OnDie;
        private int? _health;
        
        public void InitHealth(int value)
        {
            _health ??= value;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                OnDie?.Invoke(gameObject);
                Destroy(gameObject);
            }
        }
    }
}