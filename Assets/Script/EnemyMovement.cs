using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[SelectionBase]
public class EnemyMovement : MonoBehaviour, IEnemy
{
    [SerializeField] private EnemyDectect _detect;
    private Vector3 _target ;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private void OnValidate()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
        _detect ??= GetComponentInChildren<EnemyDectect>();
    }

    private void Start()
    {
        _target = Vector3.zero;
        transform.rotation = Quaternion.LookRotation(-transform.position - _target);
    }

    private void FixedUpdate()
    {
        //_rigidbody.MovePosition(transform.position + transform.forward * _speed);
    }

    public void ChangeTarget()
    {
        transform.rotation = Quaternion.LookRotation(-transform.position - _target);
    }
}
