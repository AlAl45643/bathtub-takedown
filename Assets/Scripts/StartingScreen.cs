
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    void Update()
    {
        // Check for any key press or gamepad button press
        if (Input.anyKeyDown || Input.GetButtonDown("Fire1")) // "Fire1" is commonly mapped to the left mouse button or a gamepad button
        {
            StartGame();
        }
    }
}
