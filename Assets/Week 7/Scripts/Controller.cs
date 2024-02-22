using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    public Slider chargeSlider;
    float chargeValue;
    public float maxCharge = 1;
    Vector2 direction;
    
        public static Footballer SelectedPlayer { get; private set; }
    public static void SetSelectedPlayer(Footballer player)
    {
        if (SelectedPlayer == null)
        {
            SelectedPlayer.Selected(false);
        }
        SelectedPlayer = player;
        SelectedPlayer.Selected(true);

    }

    private void FixedUpdate()
    {
        if (direction != Vector2.zero)
        {
            SelectedPlayer.Move(direction);
            direction = Vector2.zero;
            chargeValue = 0;
            chargeSlider.value = chargeValue;
        }
    }

    private void Update()
    {
        if (SelectedPlayer == null) return;


        if(Input.GetKeyDown(KeyCode.Space))
            {
            chargeValue = 0;
            direction = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.Space))
            {
            chargeValue += Time.deltaTime;
            chargeValue = Mathf.Clamp(chargeValue, 0, maxCharge);
            chargeSlider.value = chargeValue;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            {
            direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - SelectedPlayer.transform.position).normalized * chargeValue;
        }
    }
}

