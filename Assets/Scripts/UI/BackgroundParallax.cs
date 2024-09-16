using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private float _parallaxValue;

    private float _startPosition;
    private GameObject _camera;
    private float _length;

    void Start()
    {
        _startPosition = transform.position.x;
        _camera = Camera.main.gameObject;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float movement = _camera.transform.position.x * (1 - _parallaxValue);
        transform.position = new Vector3(_startPosition * movement, transform.position.y, transform.position.z);

        if (movement > _startPosition + _length)
        {
            _startPosition += _length;
        }

        else if (movement < _startPosition - _length)
        {
            _startPosition -= _length;
        }
    }
}
