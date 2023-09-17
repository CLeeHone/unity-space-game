using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public const float RightLimit = 11.3f;
    public const float LeftLimit = -11.3f;
    public const float UpperLimit = 0f;
    public const float LowerLimit = -3.8f;

    // Serializes the data to allow a private variable to be visible and overridable in the Unity editor
    [SerializeField] 
    private int _speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float forwardInput = 0f;
        Vector3 direction = new Vector3(horizontalInput, verticalInput, forwardInput);

        // Time.deltaTime incorporates real time. Distributed property Vector3(1, 0, 0) * 5 * real time --> equals new Vector3(5, 0, 0)
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LowerLimit, UpperLimit), transform.position.z);

        if (transform.position.x >= RightLimit)
        {
            transform.position = new Vector3(LeftLimit, transform.position.y, transform.position.z);
        } else if (transform.position.x <= LeftLimit)
        {
            transform.position = new Vector3(RightLimit, transform.position.y, transform.position.z);
        }
    }
}
