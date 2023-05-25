using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform Player;
    public int numEnemies = 5;

    public static GameManager Instance { private set; get; }
    public event EventHandler OnPlayerDamage;
    public event EventHandler OnEnemyDamage;
    public event EventHandler OnPlayerDied;
    public float PlayerHealth = 100f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnEnemies();
    }

    private void Update()
    {
        if (PlayerHealth < 100f)
        {
            PlayerHealth += 0.1f;
        }
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

    public void PlayerDamage()
    {
        PlayerHealth -= 10f;
        OnPlayerDamage?.Invoke(this, EventArgs.Empty);
        if (PlayerHealth <= 0f)
        {
            OnPlayerDied?.Invoke(this, EventArgs.Empty);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void EnemyDamage()
    {
        OnEnemyDamage?.Invoke(this, EventArgs.Empty);
    }
}
