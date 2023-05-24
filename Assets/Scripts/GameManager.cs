using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Player;
    public int numEnemies = 5;

    public static GameManager Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        var enemyToInstantiate = Resources.Load<GameObject>("EnemyNPC");

        for (int i=0; i < numEnemies; i++)
        {
            var instanciatePosition = new Vector3(
                UnityEngine.Random.Range(-12f, 13f),
                UnityEngine.Random.Range(-11f, 6f),
                0f
            );

            var enemy = Instantiate(enemyToInstantiate, instanciatePosition, Quaternion.identity);
            enemy.GetComponent<EnemyController>().Player = Player;
        }
    }
}
