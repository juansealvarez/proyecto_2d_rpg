using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    #region Public Properties
    public float WakeDistance = 5f;
    public float Speed = 2f;
    public float AttackDistance = 1f;

    public float EnemyHealth = 4f;

    #endregion

    #region Components
    public Transform Player;
    public SpriteRenderer spriteRenderer { private set; get; }
    public Rigidbody2D rb { private set; get; }
    public Animator animator { private set; get; }

    public bool AttackingEnd { set; get; } = false;
    public Transform hitBox { private set; get; }

    #endregion

    #region Private Properties
    private FSM<EnemyController> mFSM;

    #endregion

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hitBox = transform.Find("Hitbox");

        // Creo la maquina de estados finita
        mFSM = new FSM<EnemyController>(new Enemy.IdleState(this));
        mFSM.Begin(); // prendo la maquina de estados
    }


    public void damaged()
    {
        if (PlayerMovement.usingSword)
        {
            EnemyHealth -= 1f;
            Debug.Log("-1 de vida");
        }
        else
        {
            EnemyHealth -= 2f;
            Debug.Log("-2 de vida");
        }

        if (EnemyHealth <= 0f)
        {
            Debug.Log("Enemigo Abatido");
            Destroy(this.gameObject);
            GameManager.Instance.EnemyKilled();
        }
    }

    private void FixedUpdate()
    {
        mFSM.Tick(Time.deltaTime);
    }

    public void SetAttackingEnd()
    {
        AttackingEnd = true;
    }
}
