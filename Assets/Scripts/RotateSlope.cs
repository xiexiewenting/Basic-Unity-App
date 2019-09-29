using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlope : MonoBehaviour
{
    //slope that needs to be rotated
    public GameObject slopeAxis;

    bool alreadyCollided;
    //Vector3 currentEulerAngles;
    //Quaternion currentRotation;
    Quaternion startRotation;
    Quaternion desiredRotation;

    //A float number to tweak the movement speed of the slope rotation in the editor
    [SerializeField]
    float rotationSmooth = 0.0025f;
    float timeOfCollision;
    float timeNeededForRotation = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        startRotation = slopeAxis.transform.rotation;
        desiredRotation = Quaternion.Euler(0, 0, -45);
    }

    // Update is called once per frame
    void Update()
    {
        if(alreadyCollided) {

            float timeSinceStarted = Time.time - timeOfCollision;
            float percentageComplete = timeSinceStarted / timeNeededForRotation;

            slopeAxis.transform.rotation = Quaternion.Lerp(startRotation, desiredRotation, percentageComplete);
            //currentEulerAngles += new Vector3(0, 0, -1) * Time.deltaTime * rotationSmooth;
            //currentRotation.eulerAngles = currentEulerAngles;
            //slopeAxis.transform.rotation = currentRotation;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true

        if (collision.gameObject.CompareTag("Ball"))
        {
            alreadyCollided = true;
            timeOfCollision = Time.time;
        }
    }

}
