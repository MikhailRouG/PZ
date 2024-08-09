using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDectect : MonoBehaviour
{
    private List<Transform> _object = new();
    [SerializeField] private EnemyMovement _enemyMovement;


    private void OnValidate()
    {
        _enemyMovement ??= GetComponent<EnemyMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IMovable>(out IMovable component))
        {
            _object.Add(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IMovable>(out IMovable component)) _object.Remove(other.gameObject.transform);
    }

    private void OnDetected()
    {
        
    }

    private Vector3 FindObject()
    {
        if (_object.Count == 0) return Vector3.zero;
        if (_object[0].IsDestroyed())
        {
            _object.Remove(_object[0]);
            return Vector3.zero;
        }
        Debug.Log("Detected");
        return _object[0].position;
    }
}
