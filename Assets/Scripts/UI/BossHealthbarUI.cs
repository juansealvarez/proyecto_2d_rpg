using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class BossHealthbarUI : MonoBehaviour
{
    private Slider mSlider;
    private void Start()
    {
        mSlider = GetComponent<Slider>();
        GameManager.Instance.OnBossDamage += OnBossDamageDelegate;
    }
    private void OnBossDamageDelegate(object sender, EventArgs e)
    {
        if (PlayerMovement.usingSword)
        {
            mSlider.value -= 1f;
        }else
        {
            mSlider.value -= 2f;
        }
    }
}
