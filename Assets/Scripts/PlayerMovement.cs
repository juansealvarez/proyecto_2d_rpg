using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    private Rigidbody2D mRb;
    private Vector3 mDirection = Vector3.zero;
    private Animator mAnimator;
    private PlayerInput mPlayerInput;
    private Transform hitBox;
    private bool usingSword = true; //bool de sword1
    public GameObject SwordGUI;
    public GameObject Sword2GUI;
    public float CooldownInicial = 10f;

    private float Cooldown = 0f;

    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
        mPlayerInput = GetComponent<PlayerInput>();

        hitBox = transform.Find("HitBox");

        ConversationManager.Instance.OnConversationStop += OnConversationStopDelegate;
    }

    private void OnConversationStopDelegate()
    {
        mPlayerInput.SwitchCurrentActionMap("Player");
    }

    private void Update()
    {
        if (mDirection != Vector3.zero)
        {
            mAnimator.SetFloat("Horizontal", mDirection.x);
            mAnimator.SetFloat("Vertical", mDirection.y);
            mAnimator.SetBool("IsMoving", true);
        }else
        {
            // Quieto
            mAnimator.SetBool("IsMoving", false);
        }
        
        if(Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (usingSword){
                usingSword = false;
            }else
            {
                usingSword = true;
            }
        }

        if (usingSword)
        {
            SwordGUI.gameObject.SetActive(true);
            Sword2GUI.gameObject.SetActive(false);
        }else
        {
            SwordGUI.gameObject.SetActive(false);
            Sword2GUI.gameObject.SetActive(true);
        }
        Cooldown -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        mRb.MovePosition(
            transform.position + (mDirection * speed * Time.fixedDeltaTime)
        );
    }

    public void OnMove(InputValue value)
    {
        mDirection = value.Get<Vector2>().normalized;
    }

    public void OnNext(InputValue value)
    {
        if (value.isPressed)
        {
            ConversationManager.Instance.NextConversation();
        }
    }

    public void OnCancel(InputValue value)
    {
        if (value.isPressed)
        {
            ConversationManager.Instance.StopConversation();
        }
    }

    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            if (usingSword)
            {
                mAnimator.SetTrigger("Attack");
                hitBox.gameObject.SetActive(true);
            } else
            {
                if (Cooldown <= 0)
                {
                    mAnimator.SetTrigger("Attack2");
                    hitBox.gameObject.SetActive(true);
                    Cooldown = CooldownInicial;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Conversation conversation;
        if (other.transform.TryGetComponent<Conversation>(out conversation))
        {
            mPlayerInput.SwitchCurrentActionMap("Conversation");
            ConversationManager.Instance.StartConversation(conversation);
        }
    }

    public void DisableHitBox()
    {
        hitBox.gameObject.SetActive(false);
    }
}
