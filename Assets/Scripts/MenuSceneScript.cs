using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneScript : MonoBehaviour
{

    public GameObject[] canvases; // Assign canvases in the inspector
    private int currentCanvasIndex = 0;
    private bool playerSelectCanvasActive = false;

    public TMP_Text onlySinglePlayerText; // Assign error text only single player is available

    public Button singlePlayerBttn;
    private bool singlePlayerBttnActive = false;
    public Button twoPlayerBttn;
    private bool twoPlayerBttnActive = false;
    public Button threePlayerBttn;
    private bool threePlayerBttnActive = false;
    public Button fourPlayerBttn;
    private bool fourPlayerBttnActive = false;

    void Start()
    {
        // Ensure only the first canvas is active at the start
        UpdateCanvasVisibility();
        if (singlePlayerBttn != null)
        {
            singlePlayerBttn.onClick.AddListener(OnButtonClickPlayerSelect);
        }
        if (twoPlayerBttn != null)
        {
            twoPlayerBttn.onClick.AddListener(setError);
        }
        if (threePlayerBttn != null)
        {
            threePlayerBttn.onClick.AddListener(setError);
        }
        if (fourPlayerBttn != null)
        {
            fourPlayerBttn.onClick.AddListener(setError);
        }

    }

    void Update()
    {
        if (Input.anyKeyDown || Input.GetButtonDown("Fire1")) // Toggle canvases using Tab key
        {
            if (!playerSelectCanvasActive)
            {
                CycleCanvases();
                playerSelectCanvasActive = true;
                EventSystem.current.SetSelectedGameObject(singlePlayerBttn.gameObject);
            }

            if (playerSelectCanvasActive)
            {
                if (singlePlayerBttnActive)
                {
                    singlePlayerBttnActive = false;
                    StartGame();
                }
            }
        }
    }

    void OnButtonClickPlayerSelect()
    {
        singlePlayerBttnActive = true;
    }

    void CycleCanvases()
    {
        canvases[currentCanvasIndex].SetActive(false); // Deactivate current
        currentCanvasIndex = (currentCanvasIndex + 1) % canvases.Length; // Move to next
        canvases[currentCanvasIndex].SetActive(true); // Activate next
    }

    void UpdateCanvasVisibility()
    {
        for (int i = 0; i < canvases.Length; i++)
        {
            canvases[i].SetActive(i == currentCanvasIndex);
        }
    }

    // Start is called before the first frame update
    void StartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex + 1;

        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("No scene to load!");
        }
    }

    public void setError()
    {
        onlySinglePlayerText.text = "This game mode is currently unavailable";
    }

}
