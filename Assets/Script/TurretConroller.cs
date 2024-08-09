using System;
using UnityEngine;

public class TurretConroller : MonoBehaviour, IShootable
{
    [SerializeField] private Transform _gun;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private float _timeToShoot;
    private float _currentShootTime;
    private DetectEnemy _detectEnemy;
    private IMovable _movable;

    private Transform _enemePosition;
    private void Start()
    {
        _detectEnemy = GetComponentInChildren<DetectEnemy>();
        _movable = GetComponent<IMovable>();
    }

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        Transform enemy = _detectEnemy.Enemy();
        if (enemy == null)
        {
            _gun.rotation = Quaternion.identity;
            return;
        }
        Vector3 offset = Quaternion.LookRotation(_gun.transform.position - enemy.position).eulerAngles;
        _gun.rotation = Quaternion.Euler(0f, offset.y, 0f);
        Shoot();
    }

    private void Shoot()
    {
        if(Time.time - _currentShootTime < _timeToShoot) return;
        Instantiate(_bulletPrefab, _bulletStartPosition.position, _gun.rotation);
        _currentShootTime = Time.time;
    }
}
