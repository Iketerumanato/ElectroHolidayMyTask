using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurikoRenderer : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;

    void FixedUpdate()
    {
        var RenderPositions = new Vector3[] { startPoint.position, endPoint.position, };
        lineRenderer?.SetPositions(RenderPositions);
    }
}
