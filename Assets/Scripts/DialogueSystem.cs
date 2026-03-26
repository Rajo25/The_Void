using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button nextButton;
    public Button choiceA;
    public Button choiceB;

    private int index = 0;

    private bool isTyping = false;
    private Coroutine typingCoroutine;

    public float typingSpeed = 0.05f;

    string[] dialogue = {
        "Siema",
        "To jest prototyp visual novelki",
        "Kliknij spację żeby przejść dalej",
        "A teraz wybierz opcję"
    };

    void Start()
    {
        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        nextButton.gameObject.SetActive(false); 

        choiceA.onClick.AddListener(ChooseA);
        choiceB.onClick.AddListener(ChooseB);

        StartTyping();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogue[index];
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
        typingCoroutine = StartCoroutine(TypeText(dialogue[index]));
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in text)
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void Next()
    {
        index++;

        if (index < dialogue.Length)
        {
            StartTyping();
        }
        else
        {
            choiceA.gameObject.SetActive(true);
            choiceB.gameObject.SetActive(true);
        }
    }

    void ChooseA()
    {
        dialogueText.text = "Wybrałeś opcję A";
    }

    void ChooseB()
    {
        dialogueText.text = "Wybrałeś opcję B";
    }
}
