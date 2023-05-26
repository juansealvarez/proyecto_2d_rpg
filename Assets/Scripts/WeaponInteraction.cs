using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("enemy"))
        {
            col.GetComponent<EnemyController>().damaged();
            
        }

        if(col.CompareTag("boss"))
        {
            col.GetComponent<BossController>().damaged();
            GameManager.Instance.BossDamage();
        }
    }
}
