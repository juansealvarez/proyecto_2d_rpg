using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Boss;

[RequireComponent(typeof(Rigidbody2D))]
public class BossController : MonoBehaviour
{
    #region Public Properties
    public float WakeDistance = 10f;
    public float Speed = 3f;
    public float AttackDistance = 2f;
    public float SpecialAttackDistance = 5f;
    public float BossHealth = 10f;
    #endregion

    #region Components
    public Transform Player;
    public SpriteRenderer spriteRenderer { private set; get; }
    public Rigidbody2D rb { private set; get; }
    public Animator animator { private set; get; }

    public bool AttackingEnd { set; get; } = false;
    public bool SpecialAttackEnd { set; get; } = false;
    public Transform hitBox { private set; get; }
    public Transform specialAttackHitBox { private set; get; }
    #endregion

    #region Private Properties
    private FSM<BossController> mFSM;
    private FSMState<BossController> mCurrentState;
    #endregion

    private void Start()
    {
        // Se obtiene el BOss
        Player = GameObject.FindWithTag("Player").transform;

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

    private void Update()
    {
        mCurrentState?.OnUpdate(Time.deltaTime);
    }

    private void ChangeState(FSMState<BossController> newState)
    {
        if (mCurrentState != null)
            mCurrentState.OnExit();

        mCurrentState = newState;

        if (mCurrentState != null)
            mCurrentState.OnEnter();
    }
}
