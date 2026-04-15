using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;
    
    public static bool IsPaused = false;

    public Button _MainMenu;
    public Button Quit_Game;
    public Button Resume_;
    public Button SaveGameBtn; 

    public Transform player;

    public DialogueSystem dialogueSystem; 

    private void Start()
    {
        _MainMenu.onClick.AddListener(MainMenu);
        Quit_Game.onClick.AddListener(QuitGame);
        Resume_.onClick.AddListener(ResumeGame);

        SaveGameBtn.onClick.AddListener(SaveGame); 
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
        
        IsPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        
        IsPaused = false;
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        isPaused = false;
        
        IsPaused = false;

        Cursor.visible = true;
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Opuszczanie gry");
    }
    
    private void SaveGame()
    {
        PlayerPrefs.SetInt("SceneIndex", SceneManager.GetActiveScene().buildIndex);
        
        PlayerPrefs.SetFloat("PlayerX", player.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.position.z);

        if (dialogueSystem != null)
        {
            PlayerPrefs.SetInt("dialogueIndex", dialogueSystem.GetIndex());
        }

        PlayerPrefs.Save();

        Debug.Log("Gra zapisana!");
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SceneIndex"))
        {
            int sceneIndex = PlayerPrefs.GetInt("SceneIndex");
            SceneManager.LoadScene(sceneIndex);

            Debug.Log("Gra wczytana!");
        }
    }
}