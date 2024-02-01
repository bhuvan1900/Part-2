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
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed = 1;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x,direction.y)* Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
            
        }

        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);

    }

    private void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0 )
        {
            if (Vector2.Distance(currentPosition, points[0]) < newPositionThreshold)
            { 
                points.RemoveAt(0);

                for (int i = 0; i< lineRenderer.positionCount-2;  i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i+1));
                }
                lineRenderer.positionCount--;
            
            }
        }
    }

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
