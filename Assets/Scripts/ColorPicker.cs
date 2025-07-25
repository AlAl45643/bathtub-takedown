using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    private Renderer playerRenderer;
    private Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeColor()
    {
        // Get Renderer object of Kart and Image object of button
        playerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>();
        button = GetComponent<Button>();

        // Set material basecolor of kart to color of button
        playerRenderer.material.SetColor("_BaseColor", button.colors.normalColor);



    }

}

