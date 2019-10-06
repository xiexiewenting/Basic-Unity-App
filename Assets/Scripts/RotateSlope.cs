using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlope : MonoBehaviour
// this script rotates the slope using its slopeaxis
{
    //slope that needs to be rotated
    public GameObject _slopeAxis;

    private bool _alreadyCollided;
    private float _timeOfCollision, _timeNeededForRotation;
    private Quaternion _startRotation, _desiredRotation;
    

    // Start is called before the first frame update
    void Start()
    {
        _startRotation = _slopeAxis.transform.rotation;
        _desiredRotation = Quaternion.Euler(0, 0, -45);
        _timeNeededForRotation = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_alreadyCollided) {

            float timeSinceStarted = Time.time - _timeOfCollision;
            float percentageComplete = timeSinceStarted / _timeNeededForRotation;

            _slopeAxis.transform.rotation = Quaternion.Lerp(_startRotation, _desiredRotation, percentageComplete);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true
        if (collision.gameObject.CompareTag("Ball"))
        {
            _alreadyCollided = true;
            _timeOfCollision = Time.time;
        }
    }

}
