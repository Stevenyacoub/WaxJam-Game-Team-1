using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthTimer : MonoBehaviour
{
    [SerializeField]
    private float maxHealthTime = 100.0f; //time in seconds?
    [SerializeField]
    private float timeSpeed = 1; //how fast does the timer move down?

    private float internalTimeMod = 1f; //adjust how fast the bar should be moving at base speed

    [SerializeField]
    private Image timeBarSprite = null;

    private float curHealthTime;
    [SerializeField]
    bool isLevelStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        curHealthTime = maxHealthTime;
        isLevelStarted = true;
    }

    private void Update()
    {
        if (isLevelStarted)
        {
            curHealthTime -= timeSpeed * Time.deltaTime * internalTimeMod;
            UpdateUI();
            if (curHealthTime <= 0)
            {
                curHealthTime = 0;
                isLevelStarted = false;
                GameOver();
            }
        }    
    }

    /// <summary>
    /// modify the speed at which health drains
    /// </summary>
    /// <param name="newModifier"></param>
    public void ModifyHealthDrain(float newModifier = 1)
    {
        timeSpeed = newModifier;
    }

    /// <summary>
    /// remove a chunk of health
    /// </summary>
    /// <param name="damage"></param>
    public void TakeHealthDamage(float damage)
    {
        curHealthTime -= damage;
        UpdateUI();
    }

    /// <summary>
    /// Updates healthbar and anything else related to health
    /// </summary>
    private void UpdateUI()
    {
        timeBarSprite.fillAmount = curHealthTime / maxHealthTime;
    }

    /// <summary>
    /// handle game over stuff
    /// </summary>
    private void GameOver()
    {
        
    }
}
