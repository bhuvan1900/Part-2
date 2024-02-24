using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class reddie : MonoBehaviour
{
    public float speed2 = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= transform.position+ (Vector3.right*speed2)*Time.deltaTime;

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("Hit", 1, SendMessageOptions.DontRequireReceiver);
    }
}
