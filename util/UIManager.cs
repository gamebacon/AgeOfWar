using TMPro;
using UnityEditor.Build.Content;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using util;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heading;
    [SerializeField] private GameObject troops;
    [SerializeField] private GameObject menu;
    
    [SerializeField] private GameObject pauseMenu;
    
    public void toggleMenu()
    {
        if (GameManager.state == GameState.ONGOING)
        {
            menu.gameObject.SetActive(!menu.gameObject.active);
            troops.SetActive(false);
            heading.SetText("Menu");
        }
    }

    public void openTroops()
    {
        if (GameManager.state == GameState.ONGOING)
        {
            troops.SetActive(true);
            heading.SetText("Troops");
        }
    }

    public void togglePause()
    {
        bool active = !pauseMenu.gameObject.active;
        
        pauseMenu.gameObject.SetActive(active);
        
        if(active)
        {
            GameManager.state = GameState.PAUSED;
        }
        else
        {
            GameManager.state = GameState.ONGOING;
            
        }
    }

    public void Menu()
    {
        GameManager.state = GameState.MENU; 
        SceneManager.LoadScene("menu");
    }
    
}
