using CodeBase.Components;
using UnityEngine;

public class TakeDamageByCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Damageable target = collision.gameObject.GetComponent<Damageable>();
        if (target != null)
        {
            target.TakeDamage(1);
        }
    }
}
