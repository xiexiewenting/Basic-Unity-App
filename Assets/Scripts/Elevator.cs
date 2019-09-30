using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
//this script controls the movements of the "elevator" platforms to move up when the ball
// hits the switch 
{
    //Elevator cube 1-4 that you want to control in this script
    public GameObject[] _elevators;

    //A cube you want to use its position y as reference to the elevators
    public Transform _referenceTransform;

    //The position y of the reference cube
    float _targetYPos;
    
    //A bool to show if the elevator switch has been collided with the ball
    bool _alreadyCollided;

    //A float number to tweak the movement speed of the elevators in the editor
    [SerializeField]
    float _movementSmooth = 15.0f;
    

    void Start()
    {
        //TODO Use the pos.y of this transform and assign it to the targetYPos
        _targetYPos = _referenceTransform.position.y;
    }

    void Update()
    {
        if(_alreadyCollided)
        {
            //TODO When the collision with the ball has happened on the switch, call MoveUp() for each elevator in the elevators array.
            foreach (GameObject elevator in _elevators)
            {
                MoveUp(elevator);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO Check if the collision object has a tag of "Ball", if so then set the boolean isColliding to true

        if (collision.gameObject.CompareTag("Ball"))
        {
            _alreadyCollided = true;
        }
    } 

    void MoveUp(GameObject thisElevator)
    {
        //TODO calculate a taget position for this very elevator, and move it to the target position
        float step = _movementSmooth * Time.deltaTime; //target position should be the Y game object?
        Vector3 desiredPosition = new Vector3(thisElevator.transform.position.x, _targetYPos, thisElevator.transform.position.z);
        thisElevator.transform.position = Vector3.MoveTowards(thisElevator.transform.position, desiredPosition, step);

    }
}
