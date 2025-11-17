using System;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform cameraTransform;
    [SerializeField] private bool reverse = true;
    [SerializeField] private bool projectedOnY = false;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (projectedOnY)
        {
            transform.forward = Vector3.ProjectOnPlane(reverse?(cameraTransform.position - transform.position).normalized:(transform.position - cameraTransform.position).normalized, Vector3.up); 
        }
        else
        {
            transform.forward = reverse?(cameraTransform.position - transform.position).normalized:(transform.position - cameraTransform.position).normalized; 
        }
    }
}
