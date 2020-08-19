using UnityEngine;


public class Emiter : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    [SerializeField] private GameObject[] _asteroidPrefabs;

    private float _nextLaunchTime;
    private float _difficulty = 1.0f;
    private float _plusDifficulty = 0.05f;

    #endregion


    #region UnityMethods

    private void Update()
    {
        AsteroidStart();
    }

    #endregion


    #region Methods

    private void AsteroidStart()
    {
        if (GameController.Instance.IsStarted == false)
        {
            return;
        }

        if (Time.time > _nextLaunchTime)
        {
            int indexOfPrefab = Random.Range(0, _asteroidPrefabs.Length);

            _difficulty += _plusDifficulty;

            float positionY = transform.position.y;
            float positionZ = transform.position.z;
            float positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);

            GameObject asteroid = Instantiate(_asteroidPrefabs[indexOfPrefab], new Vector3(positionX, positionY, positionZ), Quaternion.identity);
            asteroid.GetComponent<Rigidbody>().velocity *= _difficulty;
            _nextLaunchTime = Time.time + Random.Range(_minDelay, _maxDelay) / _difficulty;
        }

    }

    private void SpawnAsteroids()
    {

    }

    #endregion
}
