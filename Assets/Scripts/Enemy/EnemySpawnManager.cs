using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    #region PUBLIC_VAR
    public List<Transform> spawnPoints = new List<Transform>();
    public Transform enemyParent;
    public GameObject enemyPrefab;
    public int spawnNumber = 15;
    #endregion

    #region PRIVATE_VAR
    private int currentSpawnNumber = 0;
    #endregion

    #region UNITY_METHOD
    private void Start()
    {
        CreateEnemy();
    }
    #endregion

    #region PUBLIC_METHODS

    #endregion

    #region PRIVATE_METHODS
    private void CreateEnemy()
    {
        StartCoroutine(nameof(WaitForSpawn));
    }
    #endregion

    #region COROUTINE
    IEnumerator WaitForSpawn()
    {
        while (spawnNumber > currentSpawnNumber)
        {
            yield return new WaitForSeconds(2f);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity, enemyParent);
            newEnemy.GetComponent<Enemy>().SetEnemyColor(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
            currentSpawnNumber++;
        }
    }
    #endregion

    #region DATA
    #endregion
}
