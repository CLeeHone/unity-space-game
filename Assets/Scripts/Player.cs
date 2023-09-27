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
    [SerializeField]
    public const float FireRate = 0.15f;
    private float _cooldown = -1f;
    [SerializeField]
    private int _lives = 3;

    // Serializes the data to allow a private variable to be visible and overridable in the Unity editor
    [SerializeField] 
    private int _speed = 5;
    [SerializeField]
    private GameObject _laserPrefab;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _cooldown)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float forwardInput = 0f;
        Vector3 direction = new Vector3(horizontalInput, verticalInput, forwardInput);

        // Time.deltaTime incorporates real time. Distributed property Vector3(1, 0, 0) * 5 * real time --> equals new Vector3(5, 0, 0)
        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, LowerLimit, UpperLimit), 0);

        if (transform.position.x >= RightLimit)
        {
            transform.position = new Vector3(LeftLimit, transform.position.y, 0);
        } else if (transform.position.x <= LeftLimit)
        {
            transform.position = new Vector3(RightLimit, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        float offset = 0.8f;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + offset, 0);
        
        // Quaternion.identity means default rotation
        Instantiate(_laserPrefab, newPosition, Quaternion.identity);
        _cooldown = Time.time + FireRate;
    }

    public void Damage()
    {
        _lives--;

        if (_lives == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public int getLives()
    {
        return this._lives;
    }

}
