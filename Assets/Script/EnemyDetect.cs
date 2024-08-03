using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    private List<Health> _enemys;

    private void Start()
    {
        _enemys = new List<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Health>(out Health health))
        {
            _enemys.Add(health);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<Health>(out Health health)) _enemys.Remove(health);
    }

    public Transform Enemy()
    {
        if (_enemys.Count == 0) return null;
        if (_enemys[0].IsDestroyed())
        {
            _enemys.Remove(_enemys[0]);
            return null;
        }
        return _enemys[0].transform;
    }
}
