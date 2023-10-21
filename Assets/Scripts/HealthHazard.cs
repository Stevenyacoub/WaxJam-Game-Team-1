using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Deals fixed chunk of damage directly to player
/// </summary>
public class HealthHazard : MonoBehaviour
{
    [SerializeField]
    private float damageValue = 5;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D c)
    {
        PlayerHealthTimer playerHealth = c.gameObject.GetComponent<PlayerHealthTimer>();
        if (playerHealth)
        {
            playerHealth.TakeHealthDamage(damageValue);
        }
    }
}
