using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 direction = new Vector3(0, 1, 0);

        // Vector3 direction = new Vector3(transform.position.x, transform.position.z);
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
