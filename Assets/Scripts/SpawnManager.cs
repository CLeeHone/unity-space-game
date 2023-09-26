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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            Vector3 newPosition = new Vector3(Random.Range(Enemy.LeftLimit, Enemy.RightLimit), Enemy.UpperLimit, 0);
            GameObject enemy = Instantiate(_enemyPrefab, newPosition, Quaternion.identity);
            enemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(5);
        }
    }
}
