using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public float _rotationSpeed;
    Vector3 _rotation;
    //public float _x, _y, _z;

    // Start is called before the first frame update
    void Start()
    {
        _rotation = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_rotation * _rotationSpeed, Space.Self);
    }
}
