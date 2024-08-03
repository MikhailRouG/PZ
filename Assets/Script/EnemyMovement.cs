using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    private Vector3 _base;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private void OnValidate()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _base = FindObjectOfType<Base>().transform.position;
        transform.rotation = Quaternion.LookRotation(-transform.position - _base);
    }

    private void Update()
    {
        _rigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * _speed);
    }
}
