using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public float threshold;
   

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < threshold)
        {
            transform.position = new Vector3(0.83f,7.92f,34.14f);
        }
    }
}
