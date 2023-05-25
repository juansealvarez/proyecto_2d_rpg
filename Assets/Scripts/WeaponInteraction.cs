using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("enemy"))
        {
            GameManager.Instance.EnemyDamage();
            col.GetComponent<EnemyController>().damaged();
        }
    }
}
