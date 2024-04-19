using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
   private float scrollSpeed = 8f;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed *Time.deltaTime);
    }
}
