using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goodbye : MonoBehaviour
//this script transitions the scene to demo2 after the playerball has been
//moving for 4 seconds after being pushed by the falling domino 
{
    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine("LoadDemo2");

    }

    private IEnumerator LoadDemo2()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Demo_2");
    }
}
