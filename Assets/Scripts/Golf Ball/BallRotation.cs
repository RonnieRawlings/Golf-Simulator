// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class BallRotation : NetworkBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;

        Vector3 rotation = Camera.main.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(transform.rotation.x, rotation.y, transform.rotation.z);
    }
}
