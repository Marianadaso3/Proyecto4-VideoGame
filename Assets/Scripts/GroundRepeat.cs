using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRepeat : MonoBehaviour
{
    private float spriteWidth;
    void Start()
    {
        BoxCollider groundCollider = GetComponent<BoxCollider>();
        spriteWidth = groundCollider.size.x;
    }

    void Update()
    {
        if (transform.position.x < -spriteWidth)
        {
            transform.Translate(Vector3.right * 3f * spriteWidth);
        }
    }
}
