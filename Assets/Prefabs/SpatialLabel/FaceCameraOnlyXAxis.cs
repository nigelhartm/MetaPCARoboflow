using System;
using UnityEngine;

namespace PresentFutures.XRAI.Florence
{
    public class FaceCameraOnlyXAxis : MonoBehaviour
    {
        private Transform cameraTransform;

        private void Awake()
        {
            cameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            // Get current rotation
            Vector3 currentRotation = transform.eulerAngles;

            // Calculate direction to camera
            Vector3 dirToCamera = cameraTransform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dirToCamera);

            // Get only the X axis from the look rotation
            Vector3 lookEuler = lookRotation.eulerAngles;

            // Apply only the X rotation, keep Y and Z as current
            transform.rotation = Quaternion.Euler(-lookEuler.x, currentRotation.y, currentRotation.z);
        }
    }
}
