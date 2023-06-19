// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubSwing : MonoBehaviour
{
    private Vector3 lastMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            lastMousePosition = Input.mousePosition;
            float newRotation = transform.eulerAngles.x + delta.y;
            if (newRotation > 0 && newRotation < 90)
            {
                transform.Rotate(Vector3.right * delta.y * 0.5f);
            }
        }
    }
}

