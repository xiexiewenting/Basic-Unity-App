using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeUpAnimation : MonoBehaviour
{
    private Vector3 _localScale;
    private float _delay;
    private float _shrinkSmooth;
    // Start is called before the first frame update
    void Start()
    {
        _localScale = transform.localScale;
        _delay = 2.0f;
        _shrinkSmooth = 1.0f; 
    }

    // Update is called once per frame
    void Update()
    {
        float percentage = Time.time / _delay;
        transform.localScale = Vector3.Lerp(Vector3.zero, _localScale, percentage * _shrinkSmooth);
    }
}
