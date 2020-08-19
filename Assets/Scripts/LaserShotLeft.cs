using UnityEngine;


public class LaserShotLeft : MonoBehaviour
{
    [SerializeField] private float _speedOfMiniLaser;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(45, 0, _speedOfMiniLaser);
    }
}
