using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _speed = 8f;
    private const float UpperLimit = 8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckVisibility();
    }

    void Move()
    {
        Vector3 direction = new Vector3(0, 1, 0);

        // Vector3 direction = new Vector3(transform.position.x, transform.position.z);
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    void CheckVisibility()
    {
        // if laser position on y is greater than 8, remove the object
        if (transform.position.y > UpperLimit)
        {
           Destroy(this.gameObject);
        }
    }
}
