using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Apple;

public class bluey : MonoBehaviour
{
    //declaring things
    Rigidbody2D rb;
    Vector2 movement;
    Vector2 clickPoint;
    public float speed = 5;


    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //making bluey move to click point
        movement = clickPoint - (Vector2)transform.position;

        //code to stop the jitter when click point is reached
        if (movement.magnitude <0.3)
        { movement  = Vector2.zero; }
        
        rb.MovePosition(rb.position + movement.normalized* speed*  Time.deltaTime);
    }
   
    void Update()
    {
        //where is bluey moving
       clickPoint= Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

   private void Hit(float damage)
    {

    }



}
