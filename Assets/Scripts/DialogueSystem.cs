using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Button nextButton;
    public Button choiceA;
    public Button choiceB;

    private int index = 0;

    string[] dialogue = {
        "Siema",
        "To jest prototyp visual novelki",
        "Kliknij dalej żeby przejść",
        "A teraz wybierz opcję"
    };

    void Start()
    {
        ShowText();

        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        nextButton.onClick.AddListener(Next);
        choiceA.onClick.AddListener(ChooseA);
        choiceB.onClick.AddListener(ChooseB);
    }

    void ShowText()
    {
        dialogueText.text = dialogue[index];
    }

    void Next()
    {
        index++;

        if (index < dialogue.Length)
        {
            ShowText();
        }
        else
        {
            nextButton.gameObject.SetActive(false);
            choiceA.gameObject.SetActive(true);
            choiceB.gameObject.SetActive(true);
        }
    }

    void ChooseA()
    {
        dialogueText.text = "Wybrałeś opcję A";
        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);
    }

    void ChooseB()
    {
        dialogueText.text = "Wybrałeś opcję B";
        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);
    }
}