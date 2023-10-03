using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    public const float LowerLimit = -5.5f;
    private const string PLAYER = "Player";

    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == PLAYER)
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.ActivateTripleShot();
                Destroy(this.gameObject);
            }
        }
    }

}
