using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
//using this script to make the trophy disappear when the ball hits it
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        //TODO When entering a Collider, set that object inactive if it has a tag called "PickUp"
        {
            other.gameObject.SetActive(false);
        }
    }
}
