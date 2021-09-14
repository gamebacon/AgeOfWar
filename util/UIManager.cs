using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heading;
    [SerializeField] private GameObject troops;
    [SerializeField] private GameObject menu;
    
    public void toggleMenu()
    {
        menu.gameObject.SetActive(!menu.gameObject.active);
        troops.SetActive(false);
        heading.SetText("Menu");
    }

    public void openTroops()
    {
        troops.SetActive(true);
        heading.SetText("Troops");
    }
    
}
