using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footballer : MonoBehaviour
{

    SpriteRenderer sr;
    public Color selectedColour;
    public Color unselectedColour;
    Rigidbody rb;
    public float speed = 100;

    
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        Selected(false);
        // Controller.SelectedPlayer = this;
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }
    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            sr.color = selectedColour;

        }
        else
        {
            sr.color = unselectedColour;
        }
    }
    public void Move(Vector2 direction)
    {
        rb.AddForce(direction* speed);
    }
}