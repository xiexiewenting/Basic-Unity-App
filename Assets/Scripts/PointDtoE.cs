using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDtoE : MonoBehaviour
{
    public Transform _referenceTransform;


    private Camera _mainCamera;
    private bool _rayDidHit;
    float _timeOfCollision, _targetYPos;
    float _movementSmooth = 8.0f;
    //starting at (7.5, -17, 7.65)
    //want to end up at (7.5, 4.4, 7.65)

    //scale for each wall is (0.1, 6, 1)

    // to optimally test ball, set ball position to (6.5, -17, 15)
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _rayDidHit = false;
        _targetYPos = _referenceTransform.position.y;
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
            Elevate();
        }
    }

    void Interact(RaycastHit hit)
    {
        //Debug.Log("HITTING" + hit.collider.name);
        //if it turns out the object that clicked on was NOT the platform
        if (hit.collider.name.Contains("PointD") == false)
        {
            _rayDidHit = false;
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
}
