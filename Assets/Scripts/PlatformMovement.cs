using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject _trophy;

    private float _timeOfDisappearance, _timeNeededForRotation;
    private Quaternion _startRotation, _desiredRotation;

    // Start is called before the first frame update
    void Start()
    {
        _startRotation = transform.rotation;
        _timeNeededForRotation = 2.0f;
        _desiredRotation = Quaternion.Euler(-20, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_trophy.activeInHierarchy == false)
        {
            float timeSinceStarted = Time.time - _timeOfDisappearance;
            float percentageComplete = timeSinceStarted / _timeNeededForRotation;

            transform.rotation = Quaternion.Lerp(_startRotation, _desiredRotation, percentageComplete);
        }
        else
        {
            _timeOfDisappearance = Time.time;
        }
    }
}
