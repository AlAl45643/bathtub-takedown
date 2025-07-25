using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PausedMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _settingPausedFirst;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(_settingPausedFirst);
    }
}
