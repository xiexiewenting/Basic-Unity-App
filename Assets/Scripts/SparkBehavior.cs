using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkBehavior : MonoBehaviour
//this script informs what the generated "sparks" should do
{
    public Vector3 _startVelocity;
    public float _delay, _shrinkSmooth;

    private float _startTime;
    private Rigidbody _rigidBody;
    private Vector3 _localScale;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _startVelocity = new Vector3(0, 10, 0);

        _delay = 2; 
        _shrinkSmooth = 0.1f;

        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = Random.rotation * _startVelocity;
        _localScale = transform.localScale;
        _startTime = Time.time;
        //to multiply quaternion & vector3, quaternion has to go first.

        Invoke("Die", _delay);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float percentage = (Time.time - _startTime)/ _delay;
        transform.localScale = Vector3.Lerp(_localScale, Vector3.zero, percentage * _shrinkSmooth);
    }
}
