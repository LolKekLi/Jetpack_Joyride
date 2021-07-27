using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0.001f, 0, 0);
    }
}
