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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        //CheckPlayerStatus();
    }

    IEnumerator SpawnRoutine()
    {
        Player player = GameObject.FindWithTag("Player").transform.GetComponent<Player>();
        bool playerIsAlive = player.getLives() > 0;

        while (playerIsAlive)
        {
            Vector3 newPosition = new Vector3(Random.Range(Enemy.LeftLimit, Enemy.RightLimit), Enemy.UpperLimit, 0);
            GameObject enemy = Instantiate(_enemyPrefab, newPosition, Quaternion.identity);
            enemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5);
        }

    }

/*    void CheckPlayerStatus()
    {
        Player player = GameObject.FindWithTag(PLAYER).GetComponent<Player>();
        //bool playerIsAlive = player.getLives() > 0;

        if (player == null)
        {
            Debug.Log("Game Over");
        }
    }*/
}
