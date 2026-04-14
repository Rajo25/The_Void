using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausejMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    //public GameObject OptionsUI;
    private bool isPaused = false;
    public Button _MainMenu;
    public Button Quit_Game;
    public Button Resume_;
    //public Button _Options;

    private void Start()
    {
        _MainMenu.onClick.AddListener(MainMenu);
        Quit_Game.onClick.AddListener(QuitGame);
        Resume_.onClick.AddListener(ResumeGame);
        //_Options.onClick.AddListener(Options);
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused) ResumeGame();  
            else PauseGame();
        }
            
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); 
        //OptionsUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(0);
        pauseMenuUI.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
        Cursor.visible = true;
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Opuszczanie gry");
    }
    //private void Options()
    //{
    // OptionsUI.SetActive(true);
    // //pauseMenuUI.SetActive(false);
    // Time.timeScale = 0f;
    // isPaused = true;
    // Cursor.lockState = CursorLockMode.None;
    // Cursor.visible = true;
    //}
}