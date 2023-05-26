using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class BossController : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.AllGone += AllGoneDelegate;
    }
    
    private void AllGoneDelegate(object sender, EventArgs e)
    {
        this.gameObject.SetActive(true);
    }
}
