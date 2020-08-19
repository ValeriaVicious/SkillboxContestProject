using UnityEngine;


public class SpaceShipController : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speedOfShip = 10.0f;
    [SerializeField] private float xMinSizeOfScreen;
    [SerializeField] private float xMaxSizeOfScreen;
    [SerializeField] private float zMinSizeOfScreen;
    [SerializeField] private float zMaxSizeOfScreen;
    [SerializeField] private float _tilt;
    [SerializeField] private float _shotDelay;
    [SerializeField] private float _shotDelayForMiniLasers;

    [SerializeField] private GameObject _playerExplosion;
    [SerializeField] private GameObject _laserShot;
    [SerializeField] private GameObject _laserShotRight;
    [SerializeField] private GameObject _laserShotLeft;
    [SerializeField] private Transform _laserGunCenter;
    [SerializeField] private Transform _laserGunRight;
    [SerializeField] private Transform _laserGunLeft;

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
        MoveShip();
        Shot();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("EnemyLaser") || collider.CompareTag("EnemyShip"))
        {
            Instantiate(_playerExplosion, collider.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
    }

    #endregion


    #region Methods

    private void MoveShip()
    {
        if (GameController.Instance.IsStarted == false)
        {
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        _rigidBody.velocity = new Vector3(horizontalInput, 0, verticalInput) * _speedOfShip;

        var clampedPositionOfSheepX = Mathf.Clamp(_rigidBody.position.x, xMinSizeOfScreen, xMaxSizeOfScreen);
        var clampedPositionOfSheepZ = Mathf.Clamp(_rigidBody.position.z, zMinSizeOfScreen, zMaxSizeOfScreen);
        _rigidBody.position = new Vector3(clampedPositionOfSheepX, 0, clampedPositionOfSheepZ);

        _rigidBody.rotation = Quaternion.Euler(verticalInput * _tilt, 0, -horizontalInput * _tilt);
    }

    private void Shot()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > _nextShotTime)
        {
            Instantiate(_laserShot, _laserGunCenter.position, Quaternion.identity);
            _nextShotTime = Time.time + _shotDelay;

        }

        if (Input.GetButtonDown("Fire2") && Time.time > _nextShotTime)
        {
            Instantiate(_laserShotRight, _laserGunRight.position, Quaternion.Euler(0, -45, 0));
            _nextShotTime = Time.time + _shotDelayForMiniLasers;

            Instantiate(_laserShotLeft, _laserGunLeft.position, Quaternion.Euler(0, 45, 0));
            _nextShotTime = Time.time + _shotDelayForMiniLasers;
        }
    }

    #endregion
}
