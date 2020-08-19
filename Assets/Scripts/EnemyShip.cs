using UnityEngine;


public class EnemyShip : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private float _shotDelay;

    [SerializeField] private GameObject _laserShot;
    [SerializeField] private Transform _laserGun;
    [SerializeField] private GameObject _enemyExplosion;

    private float _nextShotTime;

    private Rigidbody _rigidBody;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovingShip();
        Shot();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("GameBoundary") ||
            collider.CompareTag("Emiter") ||
             collider.CompareTag("EnemyShip") ||
             collider.CompareTag("EnemyLaser"))
        {
            return;
        }

        if (collider.CompareTag("Player") || collider.CompareTag("Asteroid"))
        {
            Instantiate(_enemyExplosion, collider.transform.position, Quaternion.identity);
        }

        GameController.Instance.Score += 15;
        Destroy(gameObject);
        Destroy(collider.gameObject);
    }

    #endregion


    #region Methods

    private void MovingShip()
    {
        _rigidBody.velocity = new Vector3(0, 0, -1) * _speed;
    }

    private void Shot()
    {
        if (Time.time > _nextShotTime)
        {
            Instantiate(_laserShot, _laserGun.position, Quaternion.identity);
            _nextShotTime = Time.time + _shotDelay;
        }
    }

    #endregion
}
