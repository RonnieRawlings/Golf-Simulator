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

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(RotateToMinus50());
        }
    }

    IEnumerator RotateToMinus50()
    {
        float duration = 0.6f;
        float time = 0;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(-50, transform.localEulerAngles.y, transform.localEulerAngles.z);
        while (time < duration)
        {
            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = endRotation;
        transform.gameObject.SetActive(false);
    }
}

