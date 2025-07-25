using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import for TextMeshPro

public class CustomizationMenuScript : MonoBehaviour
{

    public TextMeshProUGUI numberText; // Reference to the TextMeshProUGUI component

    // Start is called before the first frame update
    void Start()
    {
        int numberReceived = PlayerPrefs.GetInt("PassedNumber");

        // Display the number on the Text component
        numberText.text = numberReceived.ToString(); // Convert the number to string and display it
    }

}
