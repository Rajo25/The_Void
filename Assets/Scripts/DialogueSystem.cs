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
    private string[] currentDialogue;

    private int index = 0;
    
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    public float typingSpeed = 0.05f;

    string[] dialogue = {
        "Dziennik Alysii - Wpis 001\nDla moich uczniów",
        "Jeżeli to czytacie, oznacza to, że weszłam tam, gdzie nikt nie powinien.",
        "Mówiono mi, żebym tego nie robiła\nŻe nie wszystko jest do odkrycia",
        "Że niektóre tajemnice istnieją tylko po to aby pozostać tajemnicami",
        "Ale jeśli świat ma sens  to musi istnieć jego źródło\nA jeśli nie ma sensu…",
        "… to chce wiedzieć dlaczego.",
        "...",
        "Nie idę tam jako bohaterka\nIdę jako nauczycielka, która nie może znieść niewiedzy",
        "I nie jestem sama.",
        "Podnóże góry",
        "Wiatr jest dziwnie cichy\nNie zimny, nie ciepły\nPo prostu… nieobecny",
        "Ogromny krater ciągnie się w dół jakby świat został wyrwany z własnego ciała",
        "Alysia stoi na krawędzi, a obok niej… Cotard.",
        "Alysia:\n…to tutaj.",
        "Cottard:\nNie.",
        "...",
        "...",
        "...",
        "Tu nic nie ma",
        "Alysia wybucha śmiechem",
        "Alysia:\nWłaśnie dlatego tu jesteśmy",
        "Cotard patrzy w dół.",
        "Długo.",
        "Zbyt długo.",
        "Cotard:\nNie czuję strachu",
        "...",
        "To nie jest odwaga.",
        "Alysia:\nWiem.",
        "Cottard:\nBo ja nie istnieję.",
        "...",
        "Cisza",
        "...",
        "Nie niezręczna, nie ciężka\nPo prostu… pusta",
        "Alysia:\nMoże dlatego jesteś jedyną osobą która może tam wejść.",
        "Cotard przekrzywia głowe jakby analizował coś czego nie da się zrozumieć",
        "Cotard\nJeśli mnie tam nie ma…\n…to nic mnie nie dotknie.",
        "Alysia:\nAlbo wszystko",
        "Dziennik Alysii - wpis 002",
        "Cotard twierdzi, że nie istnieje\nNie próbuje go przekonywać, że sie myli",
        "Bo jeśli Góra Nicości robi to co podejrzewam\nto jego “choroba” może być… adaptacją",
        "...",
        "Albo początkiem",
        "Zejście",
        "Pierwszy krok\nZiemia nie wydaje dźwięku",
        "Alysia:\nSłyszysz to?",
        "Cotard:\nNie",
        "...",
        "Właśnie o to chodzi.",
        "...",
        "Każdy kolejny krok sprawia, że świat za nimi staje się… mniej wyraźny",
        "Jakby ktoś ścierał go gumką",
        "Alysia:\n(szeptem)\nNie odwracaj się",
        "Cotard\nJuż tego nie ma",
        "Alysia:\nCo? czego",
        "Cotard:\nGóra",
        "...",
        "Nie pamiętam jak wyglądała.",
        "Alysia zatrzymuje się na chwilę.",
        "Alysia:\nZa szybko to sie dzieje",
        "Cotard:\nTo nie “za szybko”",
        "...",
        "to normalne.",
        "Pierwsze zmiany",
        "Powietrze zaczyna pachnieć… słodko\nZbyt słodko",
        "Pierwsze kwiaty\nDelikatne. Piękne. Nierealne.",
        "Alysia:\nAAAAAHHHHH Kwiatowa Nicośc, ale tu pięknie!",
        "Cotard:\nNie są prawdziwe.",
        "Alysia:\nSkąd wiesz?",
        "Cotard podchodzi bliżej jednego z kwiatów\nDotyka go.\nPłatki “zacinają się” na ułamek sekundy. Jak glitch",
        "Cotard\nBo ja też nie jestem",
        "Alysia zapisuje coś szybko w notesie.",
        "Alysia\nHalucynacje!!! Albo coś więcej!",
        "Cotard uśmiechając się\nA jeśli to nie halucynacje?",
        "Alysia:\nTo co?",
        "Cotard:\nMoże to powierzchnia była iluzją.",
        "...",
        "Cisza.",
        "Dziennik Alysii - Wpis 003",
        "Kwiaty wydzielają coś do powietrza\nWidze rzeczy, które nie istnieją",
        "Albo przestaje widzieć rzeczy, które istnieją",
        "Nie jestem jeszcze pewna",
        "On.. reaguje inaczej\nJakby był mniej podatny",
        "Albo już wcześniej coś stracił",
        "Halucynacje",
        "Świat zaczyna się rozpadać\nNie gwałtownie\nSubtelnie.",
        "Alysia widzi swoich uczniów, ale nie mają twarzy\nŚwiatło na nich pada\nCzuje spokój",
        "Uczeń (Iluzja)\nPani Alysio! Wróci pani?",
        "Alysia zamiera",
        "Cotard ostro mówi\nNIE PATRZ.",
        "Alysia:\nOni są tacy… prawdziwi",
        "Cotard chwyta jej ramię.\nJego dłoń jest zimna",
        "Cotard:\nTo nie są oni",
        "Alysia:\nSkąd wiesz?!",
        "Cotard śmieje się lekko\nBo ja ich nie widzę.",
        "...",
        "A ja widze tylko rzeczy, które są istnieniem. A nie otchłanią.",
        "Alysia:\n…\n",
        "Decyzja",
        "Kwiaty zaczynają świecić\nŚwiat dzieli się na dwie wersje\nPrzed bohaterami pojawiają się dwie decyzje",
        "Nicość:\nJedno. Musi. Zniknąć.",
        "Alysia patrzy na Cotarda\nSłyszysz to?!",
        "Cotard\nTak",
        "...",
        "To nie głos",
        "Alysia:\nto co…?",
        "Cotard\nTo brak czegoś.",
        "Dziennik Alysii wpis 004",
        "Nie wiem co wybierzemy\nNie wiem, czy to w ogóle jest wybór",
        "Ale czuję, że to dopiero początek\nJeśli każde zejście wymaga poświęcenia…",
        "…to pytanie brzmi:",
        "Ile z nas zostanie na końcu?",
        "Końcówka:",
        "Cotard patrzy na Alysie:\nJeśli znikniesz to…",
        "czy kiedykolwiek istniałaś?",
        "Alysia uśmiecha się słabo.",
        "A jeśli nigdy nie istniałeś\nto\ndlaczego wciąż tu jesteś?",
        "...",
        "Alysia\nJeśli ich usuniemy… już nigdy ich nie zobaczę…",
        "Cotard:\nJeśli tego nie usuniesz… nigdy nie wyjdziesz."
        
        
    };

    string[] Choice_A =
    {
        "Alysia zamyka oczy",
        "To nie oni.",
        "Iluzja zaczyna pękać",
        "Uczeń:\nPani… dlaczego…?",
        "Alysia odwraca wzrok\nPrzepraszam…\nZaczyna płakać.",
        "Cottard:\nDobrze.",
        "...",
        "To było prawdziwe.",
        "Alysia:\nCo?",
        "Cottard:\nTo, że ich nie było.",
        "...",
        "Chodź..\nIdziemy niżej.",
        "Alysia:\nZaczynam rozumieć, dlaczego ludzie nie chcą wiedzieć.",
        "Nie pamiętam już swoich uczniów.",
        "DZIĘKUJĘ ZA GRĘ W PROTOTYP"
        
        
    };

    void Start()
    {
        currentDialogue = dialogue;
        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        nextButton.gameObject.SetActive(false); 

        choiceA.onClick.AddListener(ChooseA);
        choiceB.onClick.AddListener(ChooseB);

        StartTyping();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Return) ||
            Input.GetMouseButtonDown(0) ||
        Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = currentDialogue[index];
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
        typingCoroutine = StartCoroutine(TypeText(currentDialogue[index]));
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

    void ChooseA()
    {
        currentDialogue = Choice_A;
        index = 0;

        choiceA.gameObject.SetActive(false);
        choiceB.gameObject.SetActive(false);

        StopAllCoroutines();
        StartTyping();
    }

    void ChooseB()
    {
        dialogueText.text = "WIP";
        
    }
}
