using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public DialogueHolder dialogueHolder;
    [Header("Background System")]
    public Image backgroundImage;
    public Sprite[] backgrounds;

    private Stack<int> backgroundHistory = new Stack<int>();
    private int currentBackground = 0;
    public Button nextButton;
    public Button choiceA;
    public Button choiceB;
    public Button backButton;
    public Button skipButton;
    public Button autoButton;

    private bool isAuto = false;
    private Coroutine autoCoroutine;

    public static bool IsPaused;

    private string[] currentDialogue;
    private Stack<int> history = new Stack<int>();

    
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    public float typingSpeed = 0.05f;
    
    private string currentSpeaker = "";
    private string currentNode = "prologue";

    public int currentIndex;

    void Start()
    {
        currentDialogue = dialogueHolder.prologue;
        currentNode = "prologue";

        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        choiceA.onClick.AddListener(ChooseA);
        choiceB.onClick.AddListener(ChooseB);
        backButton.onClick.AddListener(GoBack);
        skipButton.onClick.AddListener(SkipDialogue);
        autoButton.onClick.AddListener(ToggleAuto);

        if (PlayerPrefs.HasKey("dialogueIndex"))
        {
            DialogueHolder.index = PlayerPrefs.GetInt("dialogueIndex");
        }

        StartTyping();
    }

    void Update()
    {
        if (PauseMenu.IsPaused)
            return;

        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            GoBack();
            return;
        }

        bool clickedUI = EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();

        if (Keyboard.current.spaceKey.wasPressedThisFrame ||
            (Mouse.current.leftButton.wasPressedThisFrame && !clickedUI))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = GetCleanText(currentDialogue[DialogueHolder.index]);
                isTyping = false;
            }
            else
            {
                Next();
            }
        }
    }

    void StartTyping()
    {
        string line = currentDialogue[DialogueHolder.index]; 
        

        UpdateSpeaker(line);
        
        if (line.Contains("[BG"))
        {
            int start = line.IndexOf("[BG");
            int end = line.IndexOf("]", start);

            if (start != -1 && end != -1)
            {
                string tag = line.Substring(start + 1, end - start - 1); // BG1

                if (tag.StartsWith("BG") && int.TryParse(tag.Substring(2), out int bgIndex))
                {
                    Debug.Log("BG PARSED OK -> " + bgIndex);
                    ChangeBackground(bgIndex);
                }
                else
                {
                    Debug.Log("BG parse failed: " + tag);
                }
            }
        }

        typingCoroutine = StartCoroutine(TypeText(GetCleanText(line)));
    }

    void UpdateSpeaker(string line)
    {
        if (nameText == null) return;
        if (!line.Contains("|"))
        {
            nameText.text = "";
            return;
        }

        string speaker = line.Split('|')[0];

        if (speaker == "NARRATOR")
        {
            nameText.text = "...";
        }
        if (speaker == "UNKNOWN")
        {
            nameText.text = "???";
        }
        else if (speaker == "ALYSIA")
        {
            nameText.text = "Alysia";
        }
        else if (speaker == "COTARD")
        {
            nameText.text = "Cotard";
        }
        else if (speaker == "BEE")
        {
            nameText.text = "Przczułka";
        }
        else if (speaker == "STUDENTS")
        {
            nameText.text = "Uczniowie";
        }
        else if (speaker == "WOMAN_1")
        {
            nameText.text = "Pierwsza Kobieta";
        }
        else if (speaker == "WOMAN_2")
        {
            nameText.text = "Druga Kobieta";
        }
        else if (speaker == "MAN_1")
        {
            nameText.text = "Pierwszy Mężczyzna";
        }
        else if (speaker == "MAN_2")
        {
            nameText.text = "Drugi Mężczyzna";
        }
        else if (speaker == "OLD_MAN")
        {
            nameText.text = "Stary Mężczyzna";
        }
        else if (speaker == "LEFT_ICEBLOCK")
        {
            nameText.text = "Lawa Bryła";
        }
        else if (speaker == "RIGHT_ICEBLOCK")
        {
            nameText.text = "Prawy Bryła";
        }
        else if (speaker == "LIL_ALYSIA")
        {
            nameText.text = "Mała Alysia";
        }
        else if (speaker == "LIL_COTARD")
        {
            nameText.text = "Mały Cotard";
        }
        else if (speaker == "FATHER")
        {
            nameText.text = "Ojciec";
        }
        else if (speaker == "MOTHER")
        {
            nameText.text = "Matka";
        }
    }

    string GetCleanText(string line)
    {
        if (!line.Contains("|")) return line;

        return line.Split('|')[1];
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in text)
        {
            if (PauseMenu.IsPaused)
                yield break;

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void Next()
    {
        if (isTyping) return;
        history.Push(DialogueHolder.index);

        DialogueHolder.index++;

        if (DialogueHolder.index < currentDialogue.Length)
        {
            StartTyping();
        }
        else
        {
            HandleDialogueEnd();
        }
    }
    void HandleDialogueEnd()
    {
        if (currentNode == "prologue")
        {
            currentDialogue = dialogueHolder.Chapter1d1;
            currentNode = "Chapter1d1";
        }
        else if (currentNode == "Chapter1d1")
        {
            currentDialogue = dialogueHolder.Chapter1d2;
            currentNode = "Chapter1d2";
        }
        else if (currentNode == "Chapter1d2")
        {
            choiceA.gameObject.SetActive(true);
            choiceB.gameObject.SetActive(true);
            return;
        }
        else if (currentNode == "Chapter1ch1d2" || currentNode == "Chapter1ch2d2")
        {
            currentDialogue = dialogueHolder.Chapter1d3;
            currentNode = "Chapter1d3";
        }
        else if (currentNode == "Chapter1d3")
        {
            choiceA.gameObject.SetActive(true);
            choiceB.gameObject.SetActive(true);
            return;
        }
        else if (currentNode == "Chapter1ch1d3" || currentNode == "Chapter1ch2d3")
        {
            currentDialogue = dialogueHolder.Chapter1d4;
            currentNode = "Chapter1d4";
        }
        else if (currentNode == "Chapter1d4")
        {
            choiceA.gameObject.SetActive(true);
            choiceB.gameObject.SetActive(true);
            return;
        }
        else if (currentNode == "Chapter1ch1d4" || currentNode == "Chapter1ch2d4")
        {
            currentDialogue = dialogueHolder.Chapter1d5;
            currentNode = "Chapter1d5";
        }
        else if (currentNode == "Chapter1d5")
        {
            choiceA.gameObject.SetActive(true);
            choiceB.gameObject.SetActive(true);
            return;
        }
        else if (currentNode == "Chapter1ch1d5" || currentNode == "Chapter1ch2d5")
        {
            currentDialogue = dialogueHolder.Chapter1d6;
            currentNode = "Chapter1d6";
        }
        else if (currentNode == "Chapter1d6")
        {
            currentDialogue = dialogueHolder.Chapter1d7;
            currentNode = "Chapter1d7";
        }
        else if (currentNode == "Chapter1d7")
        {
            currentDialogue = dialogueHolder.Chapter1d8;
            currentNode = "Chapter1d8";
        }
        else if (currentNode == "Chapter1d8")
        {
            choiceA.gameObject.SetActive(true);
            choiceB.gameObject.SetActive(true);
            return;
        }
        else if (currentNode == "Chapter1ch1d8" || currentNode == "Chapter1ch2d8")
        {
            currentDialogue = dialogueHolder.chapter2d1;
            currentNode = "chapter2d1";
           // LoadNextScene(SceneManager.GetActiveScene().buildIndex + 1);
           // return;
        }
        else if (currentNode == "chapter2d1")
        {
            choiceA.gameObject.SetActive(true);
            choiceB.gameObject.SetActive(true);
            return;
        }
        else if (currentNode == "Chapter2ch1d1" || currentNode == "Chapter2ch2d1")
        {
            currentDialogue = dialogueHolder.chapter2d1;
            currentNode = "chapter2d2";
        }
        else if (currentNode == "chapter2d2")
        {
            return;
        }

        DialogueHolder.index = 0;
        history.Clear();
        StartTyping();
    }

    void GoBack()
    {
        if (history.Count == 0) return;

        StopAllCoroutines();
        isTyping = false;

        DialogueHolder.index = history.Pop();

        if (backgroundHistory.Count > 0)
        {
            currentBackground = backgroundHistory.Pop();
            backgroundImage.sprite = backgrounds[currentBackground];
        }

        dialogueText.text = GetCleanText(currentDialogue[DialogueHolder.index]);
        UpdateSpeaker(currentDialogue[DialogueHolder.index]);
    }

    void ChooseA()
    {
        if (currentNode == "Chapter1d2")
        {
            currentDialogue = dialogueHolder.Chapter1ch1d2;
            currentNode = "Chapter1ch1d2";
        }
        else if (currentNode == "Chapter1d3")
        {
            currentDialogue = dialogueHolder.Chapter1ch1d3;
            currentNode = "Chapter1ch1d3";
        }
        else if (currentNode == "Chapter1d4")
        {
            currentDialogue = dialogueHolder.Chapter1ch1d4;
            currentNode = "Chapter1ch1d4";
        }
        else if (currentNode == "Chapter1d5")
        {
            currentDialogue = dialogueHolder.Chapter1ch1d5;
            currentNode = "Chapter1ch1d5";
        }
        else if (currentNode == "Chapter1d8")
        {
            currentDialogue = dialogueHolder.Chapter1ch1d8;
            currentNode = "Chapter1ch1d8";
        }
        else if (currentNode == "chapter2d1")
        {
            currentDialogue = dialogueHolder.Chapter2ch1d1;
            currentNode = "Chapter2ch1d1";
        }

        DialogueHolder.index = 0;
        history.Clear();

        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        StopAllCoroutines();
        StartTyping();
    }

    void ChooseB()
    {
        if (currentNode == "Chapter1d2")
        {
            currentDialogue = dialogueHolder.Chapter1ch2d2;
            currentNode = "Chapter1ch2d2";
        }
        else if (currentNode == "Chapter1d3")
        {
            currentDialogue = dialogueHolder.Chapter1ch2d3;
            currentNode = "Chapter1ch2d3";
        }
        else if (currentNode == "Chapter1d4")
        {
            currentDialogue = dialogueHolder.Chapter1ch2d4;
            currentNode = "Chapter1ch2d4";
        }
        else if (currentNode == "Chapter1d5")
        {
            currentDialogue = dialogueHolder.Chapter1ch2d5;
            currentNode = "Chapter1ch2d5";
        }
        else if (currentNode == "Chapter1d8")
        {
            currentDialogue = dialogueHolder.Chapter1ch2d8;
            currentNode = "Chapter1ch2d8";
        }
        else if (currentNode == "chapter2d1")
        {
            currentDialogue = dialogueHolder.Chapter2ch1d1;
            currentNode = "Chapter2ch2d1";
        }

        DialogueHolder.index = 0;
        history.Clear();

        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        StopAllCoroutines();
        StartTyping();
    }
    public int GetIndex()
    {
        return DialogueHolder.index;
    }
    void SkipDialogue()
    {
        StopAllCoroutines();
        isTyping = false;
        
        while (true)
        {
            if (currentNode == "Chapter1d2" ||
                currentNode == "Chapter1d3" ||
                currentNode == "Chapter1d4" ||
                currentNode == "Chapter1d5" ||
                currentNode == "Chapter1d8" ||
                currentNode == "chapter2d1")
            {
                break;
            }

            DialogueHolder.index++;

            if (DialogueHolder.index >= currentDialogue.Length)
            {
                HandleDialogueEnd();
                
                if (choiceA.gameObject.activeSelf)
                    break;
            }
        }

        dialogueText.text = GetCleanText(currentDialogue[DialogueHolder.index]);
        UpdateSpeaker(currentDialogue[DialogueHolder.index]);

        choiceA.gameObject.SetActive(true);
        choiceB.gameObject.SetActive(true);
    }
    void ToggleAuto()
    {
        isAuto = !isAuto;

        if (isAuto)
        {
            Debug.Log("AUTO ON");
            autoCoroutine = StartCoroutine(AutoPlay());
        }
        else
        {
            Debug.Log("AUTO OFF");
            if (autoCoroutine != null)
                StopCoroutine(autoCoroutine);
        }
    }
    IEnumerator AutoPlay()
    {
        while (isAuto)
        {
            if (PauseMenu.IsPaused)
            {
                yield return null;
                continue;
            }

            if (isTyping)
            {
                yield return null;
                continue;
            }

            yield return new WaitForSeconds(1.5f);
            
            if (choiceA.gameObject.activeSelf)
            {
                isAuto = false;
                yield break;
            }

            Next();
        }
    }
    void LoadNextScene(int sceneIndex)
    {
        if (sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("SceneIndex", sceneIndex);
            PlayerPrefs.SetInt("dialogueIndex", 0);
            PlayerPrefs.Save();

            Debug.Log("Loading next scene: " + sceneIndex);

            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.Log("Chapter 2 jeszcze nie istnieje (brak sceny w Build Settings)");
            
        }
    }
    void ChangeBackground(int index)
    {
        Debug.Log("ZMIANA BG -> " + index);
        if (index >= 0 && index < backgrounds.Length)
        {
            backgroundHistory.Push(currentBackground);
            currentBackground = index;
            backgroundImage.sprite = backgrounds[index];
            backgroundImage.color = Color.white;
            backgroundImage.SetNativeSize();
        }
    }
}