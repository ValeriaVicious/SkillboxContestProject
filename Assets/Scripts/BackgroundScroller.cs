using UnityEngine;


public class BackgroundScroller : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _speedOfScroll;

    private float _endPoint = 50.0f;

    private Vector3 _startPosition;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        var move = Mathf.Repeat(Time.time * _speedOfScroll, _endPoint);

        transform.position = _startPosition + new Vector3(0, 0, -move);
    }

    #endregion
}
