using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    public const float RightLimit = 9.48f;
    public const float LeftLimit = -9.48f;
    public const float UpperLimit = 8f;
    public const float LowerLimit = -5.5f;
    private const string PLAYER = "Player";
    private const string LASER = "Laser";

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, UpperLimit, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < LowerLimit)
        {
            transform.position = new Vector3(Random.Range(LeftLimit, RightLimit), UpperLimit, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYER)
        {
            Destroy(this.gameObject);
        }
        
        if (other.tag == LASER)
        {
            Destroy(GameObject.FindWithTag(LASER));
            Destroy(this.gameObject);
        }
    }
}
