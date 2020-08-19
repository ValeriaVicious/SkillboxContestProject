using UnityEngine;

public class LaserShotRight : MonoBehaviour
{
    [SerializeField] private float _speedOfMiniLaser;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-45, 0, _speedOfMiniLaser);
    }
}
