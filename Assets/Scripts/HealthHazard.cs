using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Deals fixed chunk of damage directly to player
/// </summary>
public class HealthHazard : MonoBehaviour
{
    [SerializeField]
    private float damageValue = 2;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D c)
    {
        PlayerHealthTimer playerHealth = c.gameObject.GetComponent<PlayerHealthTimer>();
        if (playerHealth)
        {
            UnityEngine.Debug.Log(damageValue + " Damage Taken");
            playerHealth.TakeHealthDamage(2); //just forcing a 2 hit value cause lazy to update all prefabs
        }
    }
}
