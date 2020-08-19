using UnityEngine;


public class Asteroids : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _rotation;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;

    [SerializeField] private GameObject _asteroidExplosion;
    [SerializeField] private GameObject _playerExplosion;

    private float _scale;

    #endregion


    #region UnityMethods

    private void Start()
    {

        var asteroidBody = GetComponent<Rigidbody>();
        var speed = Random.Range(_minSpeed, _maxSpeed);
        var _scale = Random.Range(0.5f, 2.0f);

        asteroidBody.transform.localScale *= _scale;
        asteroidBody.angularVelocity = Random.insideUnitSphere * _rotation;
        asteroidBody.velocity = new Vector3(0.0f, 0.0f, -speed);

    }

    private void OnTriggerEnter(Collider collider)
    {


        if (collider.CompareTag("Asteroid") || collider.CompareTag("GameBoundary")
            || collider.CompareTag("Emiter"))
        {
            return;
        }



        if (collider.CompareTag("Player") || collider.CompareTag("EnemyShip"))
        {
            Instantiate(_playerExplosion, collider.transform.position, Quaternion.identity);
        }

        GameController.Instance.Score += 10;
        var explosionAsteroid = Instantiate(_asteroidExplosion, transform.position, Quaternion.identity);
        explosionAsteroid.transform.localScale *= _scale;
        Destroy(gameObject);
        Instantiate(_asteroidExplosion, transform.position, Quaternion.identity);
        Destroy(collider.gameObject);
    }

    #endregion
}
