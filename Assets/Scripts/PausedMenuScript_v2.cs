using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausedMenuScript_v2 : MonoBehaviour
{
    public GameObject pausedCanvas; // Assign the canvas in the inspector
    public GameObject EndRaceCanvas; // Assign the canvas in the inspector
    public TMP_Text timerText; // Assign a TMP text object in the inspector
    public TMP_Text countdownText; // Assign a TMP text object for countdown in the inspector
    public TMP_Text playerTime; // Assign a TMP text object for player 1 leaderboard

    public KartControls KartControlsScript; // Drag any script (component) here in the Inspector
    public PlaybackBathtub playBackScript1; // Drag any script (component) here in the Inspector
    public PlaybackBathtub playBackScript2; // Drag any script (component) here in the Inspector

    public Button resumeBttn;

    public Button restartBttn;

    public Button quitBttn;

    public Button restartBttn_Q;

    public Button mainMenuBttn_Q;

    public Button quitBttn_Q;

    private bool isPausedCanvasActive = false;
    private bool isQuitCanvasActive = false;

    private float timer = 0f;
    private bool isTimerRunning = false;

    private float sceneTimer = 0f; // Time since scene started

    void Start()
    {
        SetScripts(false);
        StartCoroutine(StartTimerWithDelay());
        // Ensure the button is not null and add an OnClick listener
        if (resumeBttn != null)
        {
            resumeBttn.onClick.AddListener(OnButtonClickResume);
        }
        if (restartBttn != null)
        {
            restartBttn.onClick.AddListener(OnButtonClickRestart);
        }
        if (quitBttn != null)
        {
            quitBttn.onClick.AddListener(OnButtonClickQuit);
        }
        if (mainMenuBttn_Q != null)
        {
            mainMenuBttn_Q.onClick.AddListener(OnButtonClickMainMenu_Q);
        }
        if (restartBttn_Q != null)
        {
            restartBttn_Q.onClick.AddListener(OnButtonClickRestart_Q);
        }
        if (quitBttn_Q != null)
        {
            quitBttn_Q.onClick.AddListener(OnButtonClickQuit_Q);
        }
    }

    void Update()
    {
        // Scene timer always runs
        sceneTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton7)) // Enter key or Start button on controller
        {
            if (!isPausedCanvasActive)
            {
                if (!isQuitCanvasActive)
                {
                    TogglePausedCanvas();
                }
            }
        }

        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            timerText.text = FormatTime(timer);
        }
    }

    IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        SetScripts(true);
        countdownText.gameObject.SetActive(false);
    }

    IEnumerator StartTimerWithDelay()
    {
        StartCoroutine(StartCountdown());
        yield return new WaitForSeconds(4f);
        isTimerRunning = true;
        timer = 0f;
    }

    void ToggleQuitCanvas()
    {
        isPausedCanvasActive = !isPausedCanvasActive;
        isQuitCanvasActive = !isQuitCanvasActive;
        playerTime.text = FormatTime(timer);
        EndRaceCanvas.SetActive(isQuitCanvasActive);
        
    }
    void TogglePausedCanvas()
    {
        isPausedCanvasActive = !isPausedCanvasActive;

        if (isPausedCanvasActive)
        {
            SetScripts(false);
            isTimerRunning = false; // Pause the timer
        }
        else if (!isQuitCanvasActive)
        {
            SetScripts(true);
            isTimerRunning = true; // Resume the timer
        }

        pausedCanvas.SetActive(isPausedCanvasActive);
    }

    void SetScripts(bool status)
    {
        if (KartControlsScript != null)
        {
            KartControlsScript.enabled = status; //disable the script
        }
        if (playBackScript1 != null)
        {
            playBackScript1.enabled = status; // disable the script
        }
        if (playBackScript2 != null)
        {
            playBackScript2.enabled = status; // disable the script
        }
    }

    void ToggleEndGame()
    {
        Application.Quit();
    }

    void handleRestart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load the current scene again to restart it
        SceneManager.LoadScene(currentSceneName);
    }

    void handleMainMenu()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;

        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("No previous scene to load!");
        }
    }


    string FormatTime(float timeInSeconds)
    {
        int minutes = (int)(timeInSeconds / 60);
        int seconds = (int)(timeInSeconds % 60);
        int milliseconds = (int)((timeInSeconds - (int)timeInSeconds) * 100); // Multiply by 100 for 2 digits
        return string.Format("{0:D2}:{1:D2}:{2:D2}", minutes, seconds, milliseconds); // 2 digits for milliseconds
    }


    // pause menu buttons


    void OnButtonClickResume()
    {
        TogglePausedCanvas();
    }
    void OnButtonClickRestart()
    {
        handleRestart();
    }
    void OnButtonClickQuit()
    {
        ToggleQuitCanvas();
    }

    void OnButtonClickQuit_Q()
    {
        ToggleEndGame();
    }
    void OnButtonClickRestart_Q()
    {
        handleRestart();
    }
    void OnButtonClickMainMenu_Q()
    {
        handleMainMenu();
    }

}
