using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CameraFollow : NetworkBehaviour
{
    private void Update()
    {
        if (!IsOwner) return;

        if (GameObject.Find("Test_GolfBall (Clone)") != null)
        {
            transform.GetComponent<CinemachineFreeLook>().Follow = GameObject.Find("Test_GolfBall(Clone)").transform;
            transform.GetComponent<CinemachineFreeLook>().LookAt = GameObject.Find("Test_GolfBall(Clone)").transform;
        }       
    }
}
