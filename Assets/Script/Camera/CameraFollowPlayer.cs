using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTarget;

    public Vector3 camOffset;

    float slerpFactor = 0.5f;
    void Start()
    {
        camOffset = transform.position - playerTarget.transform.position;
    }

    void LateUpdate()
    {
        processTransform();
    }

    void processTransform()
    {
        Vector3 camNewPos = playerTarget.transform.position + camOffset;
        // transform.position = camNewPos;
        transform.position = Vector3.Slerp(transform.position, camNewPos, slerpFactor * Time.deltaTime);

        transform.LookAt(playerTarget);
    }
}
