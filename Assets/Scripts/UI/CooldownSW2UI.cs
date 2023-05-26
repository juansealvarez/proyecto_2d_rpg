using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CooldownSW2UI : MonoBehaviour
{
    private Slider mSlider;
    private bool onCooldown = false;
    private float mDuration = PlayerMovement.CooldownInicial;
    
    void Start()
    {
        mSlider = GetComponent<Slider>();
        mSlider.value = 0f;
        GameManager.Instance.OnPlayerAttackSW2 += OnPlayerAttackDelegate;
    }

    private void OnPlayerAttackDelegate(object sender, EventArgs e)
    {
        onCooldown = true;
        mSlider.value = mDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(onCooldown){
            mSlider.value = PlayerMovement.Cooldown;
        }
        if (mSlider.value == 0f)
        {
            onCooldown = false;
        }
    }
}
