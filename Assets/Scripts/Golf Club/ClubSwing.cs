// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ClubSwing : NetworkBehaviour
{
    private Vector3 lastMousePosition;
    [SerializeField] private GameObject golfBall;

    void Update()
    {
        if (!IsOwner) return;

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

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(RotateToMinus50());
        }
    }

    IEnumerator RotateToMinus50()
    {
        float duration = 0.6f;
        float time = 0;
        float startRotation = transform.eulerAngles.x;
        Quaternion starting = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(-50, transform.localEulerAngles.y, transform.localEulerAngles.z);
        while (time < duration)
        {
            transform.localRotation = Quaternion.Lerp(starting, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = endRotation;
        transform.gameObject.SetActive(false);

        float force = Mathf.Abs(startRotation) * 50;
        Debug.Log(force);

        Rigidbody golfBallRigidbody = golfBall.GetComponent<Rigidbody>();

        Vector3 forceDirection = golfBall.transform.forward;
        golfBallRigidbody.AddForce(forceDirection * force);

        
    }
}

