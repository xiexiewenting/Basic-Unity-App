using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDtoE : MonoBehaviour
{
    public Transform _referenceTransform;
    private Vector3 _startScale, _desiredScale;

    private Camera _mainCamera;
    private bool _rayDidHitOnce, _rayDidHitTwice;
    float _targetYPos, _delay;
    float _enlargeSmooth = 1.0f;
    float _movementSmooth = 8.0f;
    //starting at (7.5, -17, 7.65)
    //want to end up at (7.5, 4.4, 7.65)

    // scale for each wall is (0.1, 6, 1)
    // scale for Platform D starts as (1, 0.5, 1)
    // scale for Platform D ends up as (1, 0.1, 3)

    // to optimally test ball, set ball position to (6.5, -17, 15)
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _rayDidHitOnce = false;
        _rayDidHitTwice = false;
        _targetYPos = _referenceTransform.position.y;
        _desiredScale = new Vector3(1.0f, 0.1f, 3.0f);
        _delay = 1.0f;
        _startScale = transform.localScale;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_rayDidHitOnce == false)
            { 
                //Debug.Log("Pressed left click.");
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                _rayDidHitOnce = Physics.Raycast(ray, out hitInfo);
                if (_rayDidHitOnce)
                {
                    Interact(hitInfo);
                }
            }
            else if (_rayDidHitTwice == false)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                _rayDidHitTwice = Physics.Raycast(ray, out hitInfo);
                if (_rayDidHitTwice)
                {
                    Interact(hitInfo);
                }
            }
        }

        if (_rayDidHitOnce)
        {
            Debug.Log("enlarge!");
            Enlarge();
        }

        if (_rayDidHitTwice)
        {
            Elevate();
        }
    }

    void Interact(RaycastHit hit)
    {
        //Debug.Log("HITTING" + hit.collider.name);
        //if it turns out the object that clicked on was NOT the platform
        if (hit.collider.name.Contains("PointD") == false)
        {
            if (_rayDidHitTwice) {
                _rayDidHitTwice = false;
            }
            else if (_rayDidHitOnce)
            {
                _rayDidHitOnce = false;
            }
        }
    }

    void Elevate()
    {
        //float timeSinceStarted = Time.time - _timeOfCollision;
        //float percentageComplete = timeSinceStarted / _timeNeededForRotation;

        //gameObject.transform.rotation = Quaternion.Lerp(_startRotation, _desiredRotation, percentageComplete);

        float step = _movementSmooth * Time.deltaTime; //target position should be the Y game object?
        Vector3 desiredPosition = new Vector3(gameObject.transform.position.x, _targetYPos, gameObject.transform.position.z);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, desiredPosition, step);

    }

    void Enlarge()
    {
        float percentage = Time.time / _delay;
        transform.localScale = Vector3.Lerp(_startScale, _desiredScale, percentage * _enlargeSmooth);
    }
}
