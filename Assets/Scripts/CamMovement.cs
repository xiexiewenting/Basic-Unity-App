using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    //The target object that this camera is focosing on
    public GameObject targetObject;

    //A float used to tweak the camera movement
    [SerializeField]
    float cameraMovementSmooth = 1.0f;

    //An offset between camera and the target obejct
    Vector3 offset;

    void Start()
    {
        //TODO Calculate the offset between the camera and the target game object
    }

    void Update()
    {
        //TODO Add the offset to the camera
    }
}
