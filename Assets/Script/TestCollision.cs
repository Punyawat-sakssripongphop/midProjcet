using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(name + "Hit : " + collision.gameObject.name);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " : " + other.gameObject.name + "Enter Area");
    }
}
