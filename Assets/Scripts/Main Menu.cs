using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public string nextSceneName = "GAME";
    private bool isPaused = false;

    //public GameObject OptionsUI;
    //public GameObject CreditsUI;

    public Button New_Game;
    public Button Quit_Game;

    public Button Continue_Game; 

    public GameObject continueButton; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        New_Game.onClick.AddListener(NewGame);
        Quit_Game.onClick.AddListener(QuitGame);

        //Continue
        if (Continue_Game != null)
            Continue_Game.onClick.AddListener(ContinueGame);

        // pokaz/ukryj continue
        if (continueButton != null)
            continueButton.SetActive(PlayerPrefs.HasKey("dialogueIndex"));
    }

    public void LoadNextSpecificScene() //To nic nie robi , zostawiam se komende by nie szukać
    {
        //SceneManager.LoadScene(nextSceneName);
    }

    private void NewGame()
    {
        Debug.Log("Nowa gra");

        PlayerPrefs.DeleteKey("dialogueIndex");
        PlayerPrefs.DeleteKey("dialogueType");

        SceneManager.LoadScene(1);
    }

    private void ContinueGame()
    {
        Debug.Log("Kontynuuj grę");

        SceneManager.LoadScene(1);
    }

    //private void Credits()
    //{
    //    CreditsUI.SetActive(true);
    //}

    //private void Options()
    //{
    //    OptionsUI.SetActive(true);
    //}

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("Opuszczanie gry");
    }
}