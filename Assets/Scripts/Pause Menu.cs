using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject OptionsUI;



    private bool isPaused = false;

    public static bool IsPaused = false;

    public Button _MainMenu;
    public Button Quit_Game;
    public Button Resume_;
    public Button Options_;
    public Button SaveGameBtn;
    public Button SaveGameMainBtn;
    public Button autoOnButton;
    public Button autoOffButton;
    public Button backButton;
    public Color selectedColor = Color.green;
    public Color normalColor = Color.white;
    public Button slowButton;
    public Button mediumButton;
    public Button fastButton;

    public Transform player;

    public DialogueSystem dialogueSystem;
    public GameObject backlogPanel;

    private void Start()
    {
        _MainMenu.onClick.AddListener(MainMenu);
        Quit_Game.onClick.AddListener(QuitGame);
        Resume_.onClick.AddListener(ResumeGame);
        SaveGameMainBtn.onClick.AddListener(SaveGame);
        Options_.onClick.AddListener(Options);
        backButton.onClick.AddListener(BackFromOptions);
        SaveGameBtn.onClick.AddListener(SaveGame);
    }

    void Update()
    {
        if (!Keyboard.current.escapeKey.wasPressedThisFrame)
            return;

        if (backlogPanel != null && backlogPanel.activeSelf)
        {
            backlogPanel.SetActive(false);
            return;
        }

        if (OptionsUI.activeSelf)
        {
            OptionsUI.SetActive(false);
            pauseMenuUI.SetActive(true);
            return;
        }

        if (isPaused)
            ResumeGame();
        else
            PauseGame();
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

    private void Options()
    {
        pauseMenuUI.SetActive(false);
        OptionsUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        InitSettingsButtons();
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

    public void SaveGameGlobal()
    {
        SaveGame();
        Debug.Log("Save wykonany z UI (global)");
    }

    public void InitSettingsButtons()
    {
        if (autoOnButton == null || slowButton == null)
        {
            Debug.LogError("Buttons nie są przypisane w Inspectorze!");
            return;
        }

        if (GameSettings.Instance == null)
        {
            GameSettings.EnsureInstance();
        }

        var gs = GameSettings.Instance;
        if (gs == null)
        {
            Debug.LogError("GameSettings nadal null!");
            return;
        }

        autoOnButton.onClick.RemoveAllListeners();
        autoOffButton.onClick.RemoveAllListeners();

        slowButton.onClick.RemoveAllListeners();
        mediumButton.onClick.RemoveAllListeners();
        fastButton.onClick.RemoveAllListeners();

        autoOnButton.onClick.AddListener(() =>
        {
            gs.AutoOn();

            if (dialogueSystem != null)
                dialogueSystem.SetAuto(true);

            HighlightButton(autoOnButton, autoOffButton);
        });

        autoOffButton.onClick.AddListener(() =>
        {
            gs.AutoOff();

            if (dialogueSystem != null)
                dialogueSystem.SetAuto(false);

            HighlightButton(autoOffButton, autoOnButton);
        });
        slowButton.onClick.AddListener(() =>
        {
            gs.SpeedSlow();
            HighlightButton(slowButton, mediumButton, fastButton);
        });

        mediumButton.onClick.AddListener(() =>
        {
            gs.SpeedMedium();
            HighlightButton(mediumButton, slowButton, fastButton);
        });

        fastButton.onClick.AddListener(() =>
        {
            gs.SpeedFast();
            HighlightButton(fastButton, slowButton, mediumButton);
        });
        switch (gs.autoSpeed)
        {
            case GameSettings.AutoSpeed.Slow:
                HighlightButton(slowButton, mediumButton, fastButton);
                break;

            case GameSettings.AutoSpeed.Medium:
                HighlightButton(mediumButton, slowButton, fastButton);
                break;

            case GameSettings.AutoSpeed.Fast:
                HighlightButton(fastButton, slowButton, mediumButton);
                break;
        }
        if (gs.autoEnabled)
        {
            HighlightButton(autoOnButton, autoOffButton);
        }
        else
        {
            HighlightButton(autoOffButton, autoOnButton);
        }
    }
    private void BackFromOptions()
    {
        OptionsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    void HighlightButton(Button activeButton, params Button[] otherButtons)
    {
        Image activeImage = activeButton.GetComponent<Image>();

        if (activeImage != null)
            activeImage.color = selectedColor;

        foreach (Button btn in otherButtons)
        {
            Image img = btn.GetComponent<Image>();

            if (img != null)
                img.color = normalColor;
        }
    }
}