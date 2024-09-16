using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 1000; // Скорость полета пули
    [SerializeField] private float _shootingSpeed = 4; // Кол-во выстрелов в секунду
    [SerializeField] private Transform _bulletSpawnPlaceTransform;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private PlayerAmmo _playerAmmo;

    private BulletPool _bulletPool;
    private bool _isShooting;
    private Animator _animator;

    private void Awake()
    {
        _bulletPool = new BulletPool(_bulletPrefab);
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Bullet.BulletCollides += ReleaseBulletFromPool;
    }

    private void OnDisable()
    {
        Bullet.BulletCollides -= ReleaseBulletFromPool;
    }

    public void GetShootingInput(bool mustShoot)
    {
        if (mustShoot && !_isShooting)
        {
            StartShooting();
        }

        else if (_isShooting && !mustShoot)
        {
            StopShooting();
        }
    }

    private void StartShooting()
    {
        StartCoroutine(ShootingCoroutine());
        _isShooting = true;
        _animator.SetBool("IsShooting", true);
    }

    private void StopShooting()
    {
        StopAllCoroutines();
        _isShooting = false;
        _animator.SetBool("IsShooting", false);
    }

    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            _audioManager.PlaySFX(AudioManager.Sound.Shoot);
            GameObject bullet = _bulletPool.Get();
            bullet.transform.position = _bulletSpawnPlaceTransform.position;
            bullet.GetComponent<Rigidbody2D>().AddForce(ShootingForce());
            _playerAmmo.ChangeBulletAmount(-1);
            yield return new WaitForSeconds(1 / _shootingSpeed);
        }
    }

    private void ReleaseBulletFromPool(GameObject bullet)
    {
        _bulletPool.Release(bullet);
    }

    private Vector2 ShootingForce()
    {
        return new Vector2(transform.localScale.x * _bulletSpeed, transform.position.y);
    }
}
