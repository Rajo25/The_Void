using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public DialogueHolder dialogueHolder;

    public Button nextButton;
    public Button choiceA;
    public Button choiceB;

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

        if (Keyboard.current.spaceKey.wasPressedThisFrame ||
            Mouse.current.leftButton.wasPressedThisFrame)
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

        typingCoroutine = StartCoroutine(TypeText(GetCleanText(line)));
    }

    void UpdateSpeaker(string line)
    {
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
}