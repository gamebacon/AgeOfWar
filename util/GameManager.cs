using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using util;
using static util.GameState;

public class GameManager : MonoBehaviour
{

    public static GameState state = MENU;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI buttonText;

    private void Awake()
    {
        string titleString = state == MENU ? "" : state.ToString();
        title.SetText(titleString);
        
        string stringButton = state == MENU ? "Start" : "Play again";
        buttonText.SetText(stringButton);
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("game");
        state = ONGOING;
    }

    public static void ResetGame(GameState result)
    {
        state = result;
        SceneManager.LoadScene("menu");
    }


}
