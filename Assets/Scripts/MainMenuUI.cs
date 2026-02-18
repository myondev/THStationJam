using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenuUI;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeSpeed;
    public void OpenMenu(GameObject menuToOpen)
    {
        menuToOpen.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void CloseMenu(GameObject menuToClose)
    {
        menuToClose.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Game");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        {
            EditorApplication.ExitPlaymode();
        }
#else
        {
        Application.Quit();
        }
#endif
    }
}