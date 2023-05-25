using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthbarUI : MonoBehaviour
{
    private Slider mSlider;
    private void Start()
    {
        mSlider = GetComponent<Slider>();
        GameManager.Instance.OnPlayerDamage += OnPlayerDamageDelegate;
    }

    private void Update()
    {
        if (mSlider.value < 100f)
        {
            mSlider.value += 0.1f;
        }
    }

    private void OnPlayerDamageDelegate(object sender, EventArgs e)
    {
        mSlider.value -= 10f;
    }
}
