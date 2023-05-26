using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CooldownSWUI : MonoBehaviour
{
    private Slider mSlider;
    private bool onCooldown = false;
    private float mDuration = PlayerMovement.CooldownInicialSword1;
    
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
            mSlider.value = PlayerMovement.CooldownSword1;
        }
        if (mSlider.value == 0f)
        {
            onCooldown = false;
        }
    }
}
