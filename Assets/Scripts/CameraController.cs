using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FilpCamera();   
    }

    private void FilpCamera()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        Vector3 curPosition = transform.position;
        Vector3 curRotation = transform.eulerAngles;

        if (vAxis < 0)
        {
            curPosition.z *= -1;   
            curRotation.y = 180;
        }
        else
        {
            if (curPosition.z > 0)
            {
                curPosition.z *= -1;
            }

            curRotation.y = 0;
        }

        transform.position = curPosition;
        transform.eulerAngles = curRotation;
    }
}
