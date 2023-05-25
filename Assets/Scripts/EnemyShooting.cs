using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the weapon zone");
            GameManager.Instance.PlayerDamage();
        }
    }
}
