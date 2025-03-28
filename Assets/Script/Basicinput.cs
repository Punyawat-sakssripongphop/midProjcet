using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basicinput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Key [R] Down");
        }
        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Key [R] Hold");
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("Key [R] Up");
        }
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse-Left Down");
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse-Left Hold");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse-Left Up");
        }
        Debug.Log("Mouse pos : " + Input.mousePosition);
    }
}
