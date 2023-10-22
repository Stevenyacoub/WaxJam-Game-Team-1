using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public PlayerHealthTimer healthTimer;
    public VirusMovement playerControl;
    public TextMeshProUGUI countDownText;
    public int countDownTimer = 5;

    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject levelEndUI;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this); //this instance will persist through scenes
        }
    }

    private void OnDestroy()
    {
        if(this == Instance)
        {
            _instance = null;
        }
    }

    #region Game Flow
    /// <summary>
    /// Starts the Level after a 5s delay
    /// </summary>
    public void StartLevel()
    {
        StartCoroutine(StartLevelCountdown());
    }

    /// <summary>
    /// level delay start coroutine w/ countdown timer+text update
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartLevelCountdown()
    {
        countDownText.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        while (countDownTimer > -1)
        {
            countDownText.text = countDownTimer > 0 ? countDownTimer.ToString() : "GO";
            yield return new WaitForSeconds(1);
            countDownTimer--;
            if(countDownTimer == -1)
            {
                countDownText.gameObject.SetActive(false);

                healthTimer.StartTimer();
                playerControl.GrantControl();
                yield break;
            }
        }
        yield return null;
    }

    /// <summary>
    /// Ends the level, with arg for whether or not we finished or died.
    /// </summary>
    /// <param name="levelFinished"></param>
    public void EndLevel(bool levelFinished)
    {
        healthTimer.StopTimer();
        playerControl.StopControl();

        if (levelFinished)
        {
            //reached the end
            levelEndUI.SetActive(true);

        }
        else
        {
            //died
            gameOverUI.SetActive(true);
        }
    }
    #endregion

    #region Scene Loading
    /// <summary>
    /// simple reload of the current level
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// 0 - Main Menu
    /// 1 - Level 1 
    /// 2 - Level 2
    /// </summary>
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }
   #endregion
}
