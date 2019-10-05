using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlayerCube : MonoBehaviour
{
    //public GameObject _transformationSphere;
    public GameObject _playerSphere;

    private Camera _mainCamera;
    private bool _rayDidHit;
    private Rigidbody _rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _rigidBody = GetComponent<Rigidbody>();
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
    }

    void Interact(RaycastHit hit)
    {
        //Debug.Log("HITTING" + hit.collider.name);
        if (hit.collider.name == gameObject.name)
        {
            _rigidBody.useGravity = true;

        }
        else //if it turns out the object that clicked on was NOT the platform
        {
            _rayDidHit = false;
        }
    }

}
