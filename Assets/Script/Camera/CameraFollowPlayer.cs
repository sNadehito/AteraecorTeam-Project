using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTarget;

    public Vector3 camOffset;
    public float heightCam;

    public GameObject groundObject;
    [Header("Camera Limit")]
    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float bottomLimit;

    float slerpFactor = 1.0f;
    void Start()
    {
        heightCam = transform.position.y;
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
        leftLimit = groundObject.GetComponent<Renderer>().bounds.extents.x / -2.5f;
        rightLimit = groundObject.GetComponent<Renderer>().bounds.extents.x / 2.5f;
        topLimit = groundObject.GetComponent<Renderer>().bounds.extents.z / 2.5f + camOffset.z;
        bottomLimit = groundObject.GetComponent<Renderer>().bounds.extents.z / -1.5f + camOffset.z;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), heightCam, Mathf.Clamp(transform.position.z, bottomLimit, topLimit));

    }
}
