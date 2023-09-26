using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private IEnumerator _coroutine;
    [SerializeField]
    private GameObject _enemyPrefab;

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
            Enemy enemy = gameObject.AddComponent(typeof(Enemy)) as Enemy;
            Vector3 newPosition = new Vector3(Random.Range(Enemy.LeftLimit, Enemy.RightLimit), Enemy.UpperLimit, 0);
            Instantiate(_enemyPrefab, newPosition, Quaternion.identity);

            yield return new WaitForSeconds(5);
        }
    }
}
