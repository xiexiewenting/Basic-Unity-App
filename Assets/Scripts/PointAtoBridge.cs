﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtoBridge : MonoBehaviour
{

    //private Collider _collider;

    private Camera _mainCamera;
    private bool _rayDidHit;
    private Quaternion _startRotation, _desiredRotation;

    float _timeOfCollision;
    float _timeNeededForRotation = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //_collider = GetComponent<Collider>();
        _mainCamera = Camera.main;
        _rayDidHit = false;
        _startRotation = gameObject.transform.rotation;
        _desiredRotation = Quaternion.Euler(45, 90, 0);
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
            Tilt();
        }

    }

    void Interact(RaycastHit hit)
    {
        //Debug.Log("HITTING" + hit.collider.name);
        if (hit.collider.name.Contains("PointA"))
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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    StartCoroutine("Disappear");
    //}

    //private IEnumerator Disappear()
    //{
    //    yield return new WaitForSeconds(0.25f);
    //    _collider.isTrigger = true;
    //}
}