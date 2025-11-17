using UnityEngine;
using System.Collections;

namespace PresentFutures.XRAI.Florence
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineReveal : MonoBehaviour
    {
        public float speed = 5f; // Units per second
        private LineRenderer lr;
        private Vector3[] points;
        private int currentIndex = 1; // start animating from point 1
        private Vector3 startPos;
        private Vector3 endPos;
        private float progress = 0f;

        void Start()
        {
            lr = GetComponent<LineRenderer>();

            // Get original points from LineRenderer
            points = new Vector3[lr.positionCount];
            lr.GetPositions(points);

            // Initialize: collapse line at first point
            for (int i = 1; i < points.Length; i++)
            {
                lr.SetPosition(i, points[0]);
            }

            // Prepare first segment
            startPos = points[0];
            endPos = points[1];
        }

        void Update()
        {
            if (currentIndex >= points.Length) return;

            // Move current point from start to end
            progress += (speed * Time.deltaTime) / Vector3.Distance(startPos, endPos);
            progress = Mathf.Clamp01(progress);

            Vector3 currentPos = Vector3.Lerp(startPos, endPos, progress);
            lr.SetPosition(currentIndex, currentPos);

            // When finished this segment, move to next
            if (progress >= 1f)
            {
                currentIndex++;
                if (currentIndex < points.Length)
                {
                    startPos = points[currentIndex - 1];
                    endPos = points[currentIndex];
                    progress = 0f;
                }
            }
        }
    }
}
