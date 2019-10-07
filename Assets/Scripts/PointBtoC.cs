using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBtoC : MonoBehaviour
{
    public Transform _referenceTransform;
    
    private bool _rayDidHit, _letsMoveBack;
    private Camera _mainCamera;
    private float _targetZPos, _movementSmooth;
    //starting at (7.5, -9, -13)
    //want to end up at (7.5, -9, 11)

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _rayDidHit = false;
        _letsMoveBack = false;
        _targetZPos = _referenceTransform.position.z - 3.0f;
        _movementSmooth = 13.0f;

    }

    // Update is called once per frame
    void Update()
    {
        WasMouseClicked();

        if (_rayDidHit)
        {
            if (_letsMoveBack == false)
            {
                Translate(_targetZPos, _movementSmooth);
            }
            else
            {
                Translate((_targetZPos - 10.0f), 2.0f);
            }
        }

        if (transform.position.z >= _targetZPos)
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
        float step = movementSmooth * Time.deltaTime; //target position should be the Y game object?
        Vector3 desiredPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, targetZPos);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, desiredPosition, step);

    }

    void WasMouseClicked()
    {
        if ((Input.GetMouseButtonUp(0)) && (_rayDidHit == false))
        {
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
