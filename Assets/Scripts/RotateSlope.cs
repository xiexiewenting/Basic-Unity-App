using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlope : MonoBehaviour
// this script rotates the slope using its slopeaxis
{
    //slope that needs to be rotated
    public GameObject _slopeAxis;

    private bool _alreadyCollided;
    //Vector3 currentEulerAngles;
    //Quaternion currentRotation;
    private Quaternion _startRotation, _desiredRotation;

    //A float number to tweak the movement speed of the slope rotation in the editor
    //[SerializeField]
    //float rotationSmooth = 0.0025f;
    float _timeOfCollision;
    float _timeNeededForRotation = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _startRotation = _slopeAxis.transform.rotation;
        _desiredRotation = Quaternion.Euler(0, 0, -45);
    }

    // Update is called once per frame
    void Update()
    {
        if(_alreadyCollided) {

            float timeSinceStarted = Time.time - _timeOfCollision;
            float percentageComplete = timeSinceStarted / _timeNeededForRotation;

            _slopeAxis.transform.rotation = Quaternion.Lerp(_startRotation, _desiredRotation, percentageComplete);
            //currentEulerAngles += new Vector3(0, 0, -1) * Time.deltaTime * rotationSmooth;
            //currentRotation.eulerAngles = currentEulerAngles;
            //slopeAxis.transform.rotation = currentRotation;
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
