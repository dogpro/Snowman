using UnityEngine;

[RequireComponent(typeof(Rigidbody), (typeof(PoolObject)))]
public class SnowBall : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _speed;
    private Rigidbody _rb;
    private PoolObject _poolObject;

    private void Awake()
    {
        _poolObject = GetComponent<PoolObject>();
        _rb = GetComponent<Rigidbody>();
    }
    public void InitBullet(Vector3 shootDir)
    {
        shootDir = shootDir.normalized;
        _rb.velocity = new Vector3(shootDir.x * _speed, 1, shootDir.z * _speed);
        _poolObject.ReturnToPool(_timeToDestroy);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // deal damage

        _poolObject.ReturnToPool();
    }

}
