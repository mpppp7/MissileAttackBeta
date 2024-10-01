using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVertically : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float amplitude = 1.0f;

    private float startTime;
    private float initialY;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        initialY = transform.position.y; // Save the initial y-coordinate
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the vertical movement using Mathf.Sin
        float yPos = initialY + Mathf.Sin((Time.time - startTime) * moveSpeed) * amplitude;

        // Update the object's position
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
}
