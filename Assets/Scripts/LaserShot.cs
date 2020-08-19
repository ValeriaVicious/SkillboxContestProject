using UnityEngine;


public class LaserShot : MonoBehaviour
{
    [SerializeField] private float _speedOfLaser;


    private void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, _speedOfLaser);
    }

}
