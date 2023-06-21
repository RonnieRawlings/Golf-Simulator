// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotation.y, transform.rotation.z);
    }
}
