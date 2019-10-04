using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppearPlayerSphere : MonoBehaviour
{
    public GameObject _playerCube;
    private Rigidbody _rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -20.0f)
        {
            SceneManager.LoadScene("Demo_2");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == _playerCube.name) {
            Debug.Log("registers collision at time: "+Time.time);
            _rigidBody.velocity = _playerCube.GetComponent<Rigidbody>().velocity;
            _rigidBody.useGravity = true;
            _playerCube.SetActive(false);
        } //if it is colliding with _transformationSphere, we want it to turn into 
    }

}
