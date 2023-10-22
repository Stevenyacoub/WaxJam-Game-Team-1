using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartZone : MonoBehaviour
{
    private bool hasStarted = false;

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //GameManager.gameManager.StartLevel();
        }
    }

    public void OnMouseEnter()
    {
        if(hasStarted == false)
        {
            hasStarted = true;
            GameManager.Instance.StartLevel();
        }
    }
}
