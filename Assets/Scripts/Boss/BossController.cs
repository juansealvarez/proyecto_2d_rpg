using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Boss;

[RequireComponent(typeof(Rigidbody2D))]
public class BossController : MonoBehaviour
{
    #region Public Properties
    public float WakeDistance = 5f;
    public float Speed = 2f;
    public float AttackDistance = 1f;

    public float EnemyHealth = 10f;

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
    private FSM<BossController> mFSM;

    #endregion

    private void Start()
    {
        // Se obtiene el BOss
        //Player = GameObject.FindWithTag("Player").transform;

        Debug.Log("Jege inicializado correctamente");

        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hitBox = transform.Find("Hitbox");

        // Creo la máquina de estados finita
        mFSM = new FSM<BossController>(new IdleState(this));
        mFSM.Begin(); // prendo la máquina de estados

        this.gameObject.SetActive(false);
        GameManager.Instance.AllGone += AllGoneDelegate;

    }

    private void AllGoneDelegate(object sender, EventArgs e)
    {
        this.gameObject.SetActive(true);
        // Jefe a distancia adecuad
        // this.transform.position = Player.transform.position + Vector3.one * (WakeDistance + 1);
    }

    private void FixedUpdate()
    {
        mFSM.Tick(Time.deltaTime);
    }

    public void SetAttackingEnd()
    {
        AttackingEnd = true;
        Debug.Log("attack end");
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
            Debug.Log("Boss Abatido");
            Destroy(this.gameObject);
            GameManager.Instance.BossKilled();
        }
    }
}
