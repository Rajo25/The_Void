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

    public Button nextButton;
    public Button choiceA;
    public Button choiceB;

    public static bool IsPaused;

    private string[] currentDialogue;
    private Stack<int> history = new Stack<int>();

    private int index = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    public float typingSpeed = 0.05f;
    
    private string currentSpeaker = "";

    string[] dialogue = {
        "NARRATOR|Dziennik Alysii - Wpis 001\nDla moich uczniów",
        "NARRATOR|Jeżeli to czytacie, oznacza to, że weszłam tam, gdzie nikt nie powinien.",
        "NARRATOR|Mówiono mi, żebym tego nie robiła\nŻe nie wszystko jest do odkrycia",
        "NARRATOR|Że niektóre tajemnice istnieją tylko po to aby pozostać tajemnicami",
        "NARRATOR|Ale jeśli świat ma sens to musi istnieć jego źródło\nA jeśli nie ma sensu…",
        "NARRATOR|… to chce wiedzieć dlaczego.",
        "NARRATOR|...",
        "NARRATOR|Nie idę tam jako bohaterka\nIdę jako nauczycielka, która nie może znieść niewiedzy",
        "NARRATOR|I nie jestem sama.",
        "NARRATOR|Podnóże góry",

        "NARRATOR|Wiatr jest dziwnie cichy\nNie zimny, nie ciepły\nPo prostu… nieobecny",
        "NARRATOR|Ogromny krater ciągnie się w dół jakby świat został wyrwany z własnego ciała",

        "ALYSIA|…to tutaj.",
        "COTARD|Nie.",
        "NARRATOR|...",
        "NARRATOR|...",
        "NARRATOR|...",

        "NARRATOR|Tu nic nie ma",
        "NARRATOR|Alysia wybucha śmiechem",
        "ALYSIA|Właśnie dlatego tu jesteśmy",

        "NARRATOR|Cotard patrzy w dół.",
        "NARRATOR|Długo.",
        "NARRATOR|Zbyt długo.",
        "COTARD|Nie czuję strachu",

        "NARRATOR|...",
        "NARRATOR|To nie jest odwaga.",
        "ALYSIA|Wiem.",
        "COTARD|Bo ja nie istnieję.",

        "NARRATOR|...",
        "NARRATOR|Cisza",
        "NARRATOR|...",
        "NARRATOR|Nie niezręczna, nie ciężka\nPo prostu… pusta",

        "ALYSIA|Może dlatego jesteś jedyną osobą która może tam wejść.",
        "NARRATOR|Cotard przekrzywia głowę jakby analizował coś czego nie da się zrozumieć",

        "COTARD|Jeśli mnie tam nie ma…\n…to nic mnie nie dotknie.",
        "ALYSIA|Albo wszystko",

        "NARRATOR|Dziennik Alysii - wpis 002",
        "NARRATOR|Cotard twierdzi, że nie istnieje\nNie próbuje go przekonywać, że sie myli",
        "NARRATOR|Bo jeśli Góra Nicości robi to co podejrzewam\nto jego “choroba” może być… adaptacją",
        "NARRATOR|...",
        "NARRATOR|Albo początkiem",
        "NARRATOR|Zejście",
        "NARRATOR|Pierwszy krok\nZiemia nie wydaje dźwięku",
        "Alysia|\nSłyszysz to?",
        "Cotard|\nNie",
        "NARRATOR|...",
        "Właśnie o to chodzi.",
        "NARRATOR|...",
        "NARRATOR|Każdy kolejny krok sprawia, że świat za nimi staje się… mniej wyraźny",
        "NARRATOR|Jakby ktoś ścierał go gumką",
        "Alysia|\n(szeptem)\nNie odwracaj się",
        "Cotard|\nJuż tego nie ma",
        "Alysia|\nCo? czego",
        "Cotard|\nGóra",
        "NARRATOR|...",
        "NARRATOR|Nie pamiętam jak wyglądała.",
        "NARRATOR|Alysia zatrzymuje się na chwilę.",
        "Alysia|\nZa szybko to sie dzieje",
        "Cotard|\nTo nie “za szybko”",
        "NARRATOR|...",
        "NARRATOR|to normalne.",
        "NARRATOR|Pierwsze zmiany",
        "NARRATOR|Powietrze zaczyna pachnieć… słodko\nZbyt słodko",
        "NARRATOR|Pierwsze kwiaty\nDelikatne. Piękne. Nierealne.",
        "Alysia|\nAAAAAHHHHH Kwiatowa Nicośc, ale tu pięknie!",
        "Cotard|\nNie są prawdziwe.",
        "Alysia|\nSkąd wiesz?",
        "NARRATOR|Cotard podchodzi bliżej jednego z kwiatów\nDotyka go.\nPłatki “zacinają się” na ułamek sekundy. Jak glitch",
        "Cotard|\nBo ja też nie jestem",
        "NARRATOR|Alysia zapisuje coś szybko w notesie.",
        "Alysia|\nHalucynacje!!! Albo coś więcej!",
        "NARRATOR|Cotard uśmiechając się\nA jeśli to nie halucynacje?",
        "Alysia|\nTo co?",
        "Cotard|\nMoże to powierzchnia była iluzją.",
        "NARRATOR|...",
        "NARRATOR|Cisza.",
        "NARRATOR|Dziennik Alysii - Wpis 003",
        "NARRATOR|Kwiaty wydzielają coś do powietrza\nWidze rzeczy, które nie istnieją",
        "NARRATOR|Albo przestaje widzieć rzeczy, które istnieją",
        "NARRATOR|Nie jestem jeszcze pewna",
        "NARRATOR|On.. reaguje inaczej\nJakby był mniej podatny",
        "NARRATOR|Albo już wcześniej coś stracił",
        "NARRATOR|Halucynacje",
        "NARRATOR|Świat zaczyna się rozpadać\nNie gwałtownie\nSubtelnie.",
        "NARRATOR|Alysia widzi swoich uczniów, ale nie mają twarzy\nŚwiatło na nich pada\nCzuje spokój",
        "NARRATOR|Uczeń (Iluzja)\nPani Alysio! Wróci pani?",
        "NARRATOR|Alysia zamiera",
        "NARRATOR|Cotard ostro mówi\nNIE PATRZ.",
        "Alysia|\nOni są tacy… prawdziwi",
        "NARRATOR|Cotard chwyta jej ramię.\nJego dłoń jest zimna",
        "Cotard|\nTo nie są oni",
        "Alysia|\nSkąd wiesz?!",
        "NARRATOR|Cotard śmieje się lekko\nBo ja ich nie widzę.",
        "NARRATOR|...",
        "NARRATOR|A ja widze tylko rzeczy, które są istnieniem. A nie otchłanią.",
        "Alysia|\n…\n",
        "NARRATOR|Decyzja",
        "NARRATOR|Kwiaty zaczynają świecić\nŚwiat dzieli się na dwie wersje\nPrzed bohaterami pojawiają się dwie decyzje",
        "NARRATOR|Nicość:\nJedno. Musi. Zniknąć.",
        "NARRATOR|Alysia patrzy na Cotarda\nSłyszysz to?!",
        "Cotard|\nTak",
        "NARRATOR|...",
        "NARRATOR|To nie głos",
        "Alysia|\nto co…?",
        "Cotard|\nTo brak czegoś.",
        "NARRATOR|Dziennik Alysii wpis 004",
        "NARRATOR|Nie wiem co wybierzemy\nNie wiem, czy to w ogóle jest wybór",
        "NARRATOR|Ale czuję, że to dopiero początek\nJeśli każde zejście wymaga poświęcenia…",
        "NARRATOR|…to pytanie brzmi:",
        "NARRATOR|Ile z nas zostanie na końcu?",
        "NARRATOR|Końcówka:",
        "NARRATOR|Cotard patrzy na Alysie:\nJeśli znikniesz to…",
        "NARRATOR|czy kiedykolwiek istniałaś?",
        "NARRATOR|Alysia uśmiecha się słabo.",
        "NARRATOR|A jeśli nigdy nie istniałeś\nto\ndlaczego wciąż tu jesteś?",
        "NARRATOR|...",
        "Alysia|\nJeśli ich usuniemy… już nigdy ich nie zobaczę…",
        "Cotard|\nJeśli tego nie usuniesz… nigdy nie wyjdziesz."
    };

    string[] Choice_A = {
        "ALYSIA|To nie oni.",
        "NARRATOR|Iluzja zaczyna pękać",
        "NARRATOR|Uczeń:\nPani… dlaczego…?",
        "ALYSIA|Przepraszam…",
        "COTARD|Dobrze.",
        "NARRATOR|...",
        "NARRATOR|DZIĘKUJĘ ZA GRĘ W PROTOTYP"
    };

    public int currentIndex;

    void Start()
    {
        currentDialogue = dialogue;

        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        choiceA.onClick.AddListener(ChooseA);
        choiceB.onClick.AddListener(ChooseB);

        if (PlayerPrefs.HasKey("dialogueIndex"))
        {
            index = PlayerPrefs.GetInt("dialogueIndex");
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
                dialogueText.text = GetCleanText(currentDialogue[index]);
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
        string line = currentDialogue[index];

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
            nameText.text = "";
        }
        else if (speaker == "ALYSIA")
        {
            nameText.text = "Alysia";
        }
        else if (speaker == "COTARD")
        {
            nameText.text = "Cotard";
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
        history.Push(index);

        index++;

        if (index < currentDialogue.Length)
        {
            StartTyping();
        }
        else
        {
            choiceA.gameObject.SetActive(true);
            choiceB.gameObject.SetActive(true);
        }
    }

    void GoBack()
    {
        if (history.Count == 0) return;

        StopAllCoroutines();
        isTyping = false;

        index = history.Pop();

        dialogueText.text = GetCleanText(currentDialogue[index]);
        UpdateSpeaker(currentDialogue[index]);
    }

    void ChooseA()
    {
        currentDialogue = Choice_A;
        index = 0;

        history.Clear();

        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        StopAllCoroutines();
        StartTyping();
    }

    void ChooseB()
    {
        dialogueText.text = "WIP";
    }

    public int GetIndex()
    {
        return index;
    }
}