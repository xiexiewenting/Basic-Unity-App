using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
//this script allows the camera to move at a fixed distance with the playerball
//after the playerball starts moving after being pushed by a falling domino
{
    //The target object that this camera is focosing on
    public GameObject _targetObject;

    //A float used to tweak the camera movement
    [SerializeField]
    private float cameraMovementSmooth = 1.0f;

    //An offset between camera and the target obejct
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - _targetObject.transform.position;
        //TODO Calculate the offset between the camera and the target game object
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetObject.transform.position + _offset, cameraMovementSmooth);
        //TODO Add the offset to the camera
        
    }
}
