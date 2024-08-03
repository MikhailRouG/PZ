using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private float _timeToSpawn, _radius;
    private float _currentTime;
    private int i;

    private void Start()
    {
        _currentTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _currentTime < _timeToSpawn) return;
        Instantiate(_enemy, GetPosition(), Quaternion.identity);
        _currentTime = Time.time;
    }

    private Vector3 GetPosition()
    {
        if (i == 0)
        {
            i++;
            return new Vector3(_radius, 0f, Random.Range(-_radius, _radius));
        }
        else
        {
            i--;
            return new Vector3(Random.Range(-_radius, _radius), 0f, _radius);
        }
    }
}
