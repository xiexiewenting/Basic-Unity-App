using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgettoPointB : MonoBehaviour
{
    private Camera _mainCamera;
    private bool _rayDidHit, _doNextTilt, _getOutOfWay;
    private Quaternion _startRotation, _desiredRotationA,
        _desiredRotationB;

    float _timeOfCollisionA, _timeOfCollisionB, _timeOfEnd, _delay;
    float _timeNeededForRotation = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _rayDidHit = false;
        _doNextTilt = false;
        _getOutOfWay = false;
        _startRotation = gameObject.transform.rotation;
        _desiredRotationA = Quaternion.Euler(0, 90, 0);
        _desiredRotationB = Quaternion.Euler(0, 90, -20);        
        _delay = 2.0f;
        //Debug.Log(Time.time+", with the delay it's "+(Time.time+_delay));

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonUp(0)) && (_rayDidHit == false))
        {
            //Debug.Log("Pressed left click.");
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            _rayDidHit = Physics.Raycast(ray, out hitInfo);
            if (_rayDidHit)
            {

                Interact(hitInfo);
            }
        }

        if (_getOutOfWay == false)
        {
            if (_rayDidHit)
            {
                Tilt();
            }

            if (gameObject.transform.rotation == _desiredRotationA)
            {
                _doNextTilt = true;
                _timeOfCollisionB = Time.time;
            }

            if (gameObject.transform.rotation == _desiredRotationB)
            {
                _timeOfEnd = Time.time + _delay;
                Invoke("GetOutOfWay", _delay);
            }
        }
        else
        {
            GetOutOfWay();
        }
    }

    void Interact(RaycastHit hit)
    {
        //Debug.Log("HITTING" + hit.collider.name);
        if (hit.collider.name.Contains("Bridge"))
        {
            _timeOfCollisionA = Time.time;
        }
        else //if it turns out the object that clicked on was NOT the platform
        {
            _rayDidHit = false; 
        }
    }

    void Tilt()
    {
        if (_doNextTilt == false) {
            float timeSinceStarted = Time.time - _timeOfCollisionA;
            float percentageComplete = timeSinceStarted / _timeNeededForRotation;

            gameObject.transform.rotation = Quaternion.Lerp(_startRotation, _desiredRotationA, percentageComplete);
        }
        else
        {
            float timeSinceStarted = Time.time - _timeOfCollisionB;
            float percentageComplete = timeSinceStarted / _timeNeededForRotation;

            gameObject.transform.rotation = Quaternion.Lerp(_desiredRotationA, _desiredRotationB, percentageComplete);
        }


    }
    
    void GetOutOfWay()
    {
        _getOutOfWay = true;
        float timeSinceStarted = Time.time - _timeOfEnd;
        float percentageComplete = timeSinceStarted / _timeNeededForRotation;

        gameObject.transform.rotation = Quaternion.Lerp(_desiredRotationB, _startRotation, percentageComplete);
    }
}
