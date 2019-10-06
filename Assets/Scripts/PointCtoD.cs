using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCtoD : MonoBehaviour
{
    
    private bool _rayDidHit;
    private Camera _mainCamera;
    private float _timeOfCollision, _timeNeededForRotation;
    private Quaternion _startRotation, _desiredRotation;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _rayDidHit = false;
        _startRotation = gameObject.transform.rotation;
        _desiredRotation = Quaternion.Euler(30, -180, -5);
        _timeNeededForRotation = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        WasMouseClicked();
        if (_rayDidHit)
        {
            Tilt();
        }

    }

    void Interact(RaycastHit hit)
    {
        if (hit.collider.name.Contains("PointC"))
        {
            _timeOfCollision = Time.time;
        }
        else //if it turns out the object that clicked on was NOT the platform
        {
            _rayDidHit = false;
        }
    }

    void Tilt()
    {
        float timeSinceStarted = Time.time - _timeOfCollision;
        float percentageComplete = timeSinceStarted / _timeNeededForRotation;

        gameObject.transform.rotation = Quaternion.Lerp(_startRotation, _desiredRotation, percentageComplete);
    }

    void WasMouseClicked()
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
    }
}
