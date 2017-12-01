using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{

//    float lockPos = 0;

    void Update()
    {
          transform.LookAt(Camera.main.transform.position, -Vector3.down);

//          transform.rotation = Quaternion.Euler( 0, 0, 0);

//          transform.position = new Vector3( 0, 0, 0);
    }

}