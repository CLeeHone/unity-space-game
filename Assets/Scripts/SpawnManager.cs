using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private IEnumerator _coroutine;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private const string PLAYER = "Player";
    private Player player;
    bool playerIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StatusRoutine());
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while (playerIsAlive)
        {
            Vector3 newPosition = new Vector3(Random.Range(Enemy.LeftLimit, Enemy.RightLimit), Enemy.UpperLimit, 0);
            GameObject enemy = Instantiate(_enemyPrefab, newPosition, Quaternion.identity);
            enemy.transform.parent = _enemyContainer.transform;
            playerIsAlive = player.getLives() > 0;

            yield return new WaitForSeconds(5);
        }

    }

    IEnumerator StatusRoutine()
    {
        player = GameObject.FindWithTag("Player").transform.GetComponent<Player>();
        while (player != null)
        {
            yield return new WaitForSeconds(1);
        }

        if (player == null)
        {
            playerIsAlive = false;
        }
        
    }

}
