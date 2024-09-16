using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    private ObjectPool<GameObject> _pool;
    private GameObject _bulletPrefab;

    public BulletPool(GameObject bulletPrefab)
    {
        _bulletPrefab = bulletPrefab;
        _pool = new ObjectPool<GameObject>(OnCreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, false);
    }

    private GameObject OnCreateBullet()
    {
        return Instantiate(_bulletPrefab);
    }

    private void OnGetBullet(GameObject bullet)
    {
        bullet.SetActive(true);
    }

    private void OnReleaseBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    private void OnDestroyBullet(GameObject bullet)
    {
        Destroy(bullet);
    }

    public GameObject Get()
    {
        return _pool.Get();
    }
    public void Release(GameObject objectToRelease)
    {
        _pool.Release(objectToRelease);
    }
}
