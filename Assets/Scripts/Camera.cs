using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform playerPosicion;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    private void Start()
    {
        cameraOffset = transform.position - playerPosicion.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = playerPosicion.position + cameraOffset;

        transform.position = Vector3.Lerp(transform.position, newPos, SmoothFactor);
    }




}
