using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class reddie : MonoBehaviour
{
    public float speed2 = 5;

    void Update()
    {
        transform.position= transform.position+ (Vector3.right*speed2)*Time.deltaTime;
    }
}
