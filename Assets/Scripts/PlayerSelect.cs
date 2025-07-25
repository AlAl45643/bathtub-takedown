using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] public int numberToPass; // The number you want to pass
    public void nextScreen()
    {
        PlayerPrefs.SetInt("PassedNumber", numberToPass);
        SceneManager.LoadSceneAsync(2);
    }

}
