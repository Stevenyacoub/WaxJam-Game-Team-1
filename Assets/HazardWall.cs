using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// modifies the rate at which the player loses health while in contact
/// </summary>
public class HazardWall : MonoBehaviour
{
    [SerializeField]
    private float timerDrainModifier = 2f;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D c)
    {
        PlayerHealthTimer playerHealth = c.gameObject.GetComponent<PlayerHealthTimer>();
        if (playerHealth)
        {
            playerHealth.ModifyHealthDrain(timerDrainModifier);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c"></param>
    public void OnCollisionExit2D(Collision2D c)
    {
        PlayerHealthTimer playerHealth = c.gameObject.GetComponent<PlayerHealthTimer>();
        if (playerHealth)
        {
            playerHealth.ModifyHealthDrain();
        }
    }
}
