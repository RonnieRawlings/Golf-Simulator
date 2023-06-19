using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubRotation : MonoBehaviour
{
    public void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
        transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, Camera.main.transform.position.z);
        transform.position += new Vector3(transform.forward.x * 65, 0, transform.forward.z * 65);
    }
}