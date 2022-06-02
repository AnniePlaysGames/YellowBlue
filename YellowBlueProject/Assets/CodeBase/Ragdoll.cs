using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;

    private void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        
        ToggleRagdoll(false);
    }

    public void ToggleRagdoll(bool state)
    {
        _animator.enabled = !state;

        foreach (Rigidbody rb in _rigidbodies)
        {
            rb.isKinematic = !state;
        }        
        foreach (Collider collider in _colliders)
        {
            collider.enabled = state;
        }
    }
}
