using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBtoC : MonoBehaviour
{
    public Transform _referenceTransform;


    private Camera _mainCamera;
    private bool _rayDidHit, _letsMoveBack;
    float _timeOfCollision, _targetZPos;
    float _movementSmooth = 15.0f;
    //starting at (7.5, -9, -13)
    //want to end up at (7.5, -9, 11)

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _rayDidHit = false;
        _letsMoveBack = false;
        _targetZPos = _referenceTransform.position.z - 5.0f;

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

        if (_rayDidHit)
        {
            if (_letsMoveBack == false)
            {
                Translate(_targetZPos, _movementSmooth);
            }
            else
            {
                Translate(_targetZPos - 10.0f, 2.0f);
            }
        }

        if (gameObject.transform.position.z >= _targetZPos)
        {
            _letsMoveBack = true;
        }
    }


    void Interact(RaycastHit hit)
    {
        //Debug.Log("HITTING" + hit.collider.name);
        //if it turns out the object that clicked on was NOT the platform
        if (hit.collider.name.Contains("PointB") == false)
        {
            _rayDidHit = false;
        }
    }

    void Translate(float targetZPos, float movementSmooth)
    {
        //float timeSinceStarted = Time.time - _timeOfCollision;
        //float percentageComplete = timeSinceStarted / _timeNeededForRotation;

        //gameObject.transform.rotation = Quaternion.Lerp(_startRotation, _desiredRotation, percentageComplete);

        float step = movementSmooth * Time.deltaTime; //target position should be the Y game object?
        Vector3 desiredPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, targetZPos);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, desiredPosition, step);

    }

}
