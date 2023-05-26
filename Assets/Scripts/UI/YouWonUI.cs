using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class YouWonUI : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
        GameManager.Instance.OnBossKilled += OnBossKilledDelegate;
    }
    
    private void OnBossKilledDelegate(object sender, EventArgs e)
    {
        this.gameObject.SetActive(true);
    }
}
