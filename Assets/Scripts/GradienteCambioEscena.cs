using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GradienteCambioEscena : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.AllGone += AllGoneDelegate;
    }

    private void AllGoneDelegate(object sender, EventArgs e)
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
    }
}
