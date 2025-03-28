using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCar : MonoBehaviour
{
    public float speed = 10f;
    public float rotateSpeed = 180f;
    public float flySpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        float v = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);


        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);


        if (Input.GetKey(KeyCode.Q)) 
        {
            transform.Rotate(Vector3.left * flySpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E)) 
        {
            transform.Rotate(Vector3.right * flySpeed * Time.deltaTime);
        }
    }
}
