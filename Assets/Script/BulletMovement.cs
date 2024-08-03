using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletMovement : MonoBehaviour
{
    [SerializeField] private int _force, _damage;
    [SerializeField] private Rigidbody _rigidbody;

    private void OnValidate()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.AddForce(transform.forward * -_force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}