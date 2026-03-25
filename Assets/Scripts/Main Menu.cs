using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeinMenu : MonoBehaviour
{
    //public string nextSceneName = "GAME";
    private bool isPaused = false;

    //public GameObject OptionsUI; 
    //public GameObject CreditsUI;
    public Button New_Game;
    //public Button _Options;
    //public Button _Credits;
    public Button Quit_Game;


    private void Start()
    {

        Cursor.lockState = CursorLockMode.None;
        New_Game.onClick.AddListener(NewGame);
        //_Options.onClick.AddListener(Options);
        //_Credits.onClick.AddListener(Credits);
        Quit_Game.onClick.AddListener(QuitGame);

    }
    public void LoadNextSpecificScene() //To nic nie robi , zostawiam se komende by nie szukaæ
    {

        //SceneManager.LoadScene(nextSceneName);
    }


    private void NewGame()
    {

        Debug.Log("Nowa gra");
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
