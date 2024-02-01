using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public float newPositionThreshold = 0.2f;
    Vector2 lastPosition;
    public List<Vector2> points;
    LineRenderer lineRenderer;

    
    private void OnMouseDown()
    {
        lineRenderer = GetComponent<LineRenderer>();    
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position );
        points = new List<Vector2>();

    }

    private void OnMouseDrag()

    { Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) < newPositionThreshold) ;
        {

            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount-1, newPosition);
            lastPosition = newPosition;

        }
    
    }
}
