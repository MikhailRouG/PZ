using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectEnemy : MonoBehaviour
{
    private List<Transform> _enemys = new();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IEnemy>(out IEnemy enemy))
        {
            _enemys.Add(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<IEnemy>(out IEnemy enemy)) _enemys.Remove(other.gameObject.transform);
    }

    public Transform Enemy()
    {
        if (_enemys.Count == 0) return null;
        if (_enemys[0].IsDestroyed())
        {
            _enemys.Remove(_enemys[0]);
            return null;
        }
        return _enemys[0];
    }
}
