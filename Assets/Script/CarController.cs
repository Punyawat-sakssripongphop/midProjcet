using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float rotateSpeed = 180f;
      
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get input w to move z position
        // if(Input.GetKey(KeyCode.W))
        // {
        //    transform.position = transform.position + new Vector3(0f, 0f, 1f);
        // }

        float v = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        //transform.position += new Vector3(0f, 0f, v) * speed * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, h, 0f));
    }
}
