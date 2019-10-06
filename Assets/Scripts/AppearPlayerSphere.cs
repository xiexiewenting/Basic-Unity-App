using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AppearPlayerSphere : MonoBehaviour
// using this script to make the PlayerSphere appear when PlayerCube hits it 
{
    public GameObject _playerCube;
    private Rigidbody _rigidBody;

    // position is (-7.285, 3.193594, 2.734375)

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){}

    private void OnCollisionEnter(Collision collision)
    { //if PlayerCube collides with it, PlayerCube disappears and PlayerSphere takes on its velocity 
        if (collision.gameObject.name == _playerCube.name) {
            _rigidBody.velocity = _playerCube.GetComponent<Rigidbody>().velocity;
            _rigidBody.useGravity = true;
            _playerCube.SetActive(false);
        } 
    }

}
