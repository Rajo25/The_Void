using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    //PROLOGUE
    public static int index = 0;
    public string[] prologue =
    {
        "ALYSIA|Jestem osobą, która pyta.\nNie potrafię inaczej, nigdy nie potrafiłam.",
        "ALYSIA|Pytam o wszystko, jakby ktoś zapisał we mnie wewnętrzny przymus aby zrozumieć niezrozumiałe. \nPociąga mnie to co jeszcze nienazwane, niewypowiedziane, o których inni boją się nawet pomyśleć.",
        "ALYSIA|Znaleźli go na wybrzeżu, gdzie spacerowali.\nNigdy nie dowiedziałam się kto go tam porzucił i dlaczego.\nAle to nieważne.",
        "ALYSIA|Liczyło się dla mnie tylko to, że został.\nDołączył do naszej rodziny jako jej pełnoprawna część.\n",
        "ALYSIA|Nie rozumiem tego, co wydarzyło się później.\nPrzecież było idealnie.\nAle wtedy rodzice postanowili wyruszyć w Nicość.\nBez wyjaśnień i bez pożegnań.\n",
        "ALYSIA|Poszli tam, gdzie nikt się nie zapuszcza.\nPo co?\nW końcu jeszcze nikt stamtąd nie wrócił.\n",
        "ALYSIA|To wydarzenie strzaskało moją potrzebę rozumienia wszystkiego.\nOto bowiem stało się coś, czego zrozumieć nie mogłam i nadal nie mogę.\n",
        "ALYSIA|Może to okrutne, ale uważam, że moi rodzice nigdy nie myśleli trzeźwo.\nChoć jestem im za to wdzięczna, zabrali do domu obce dziecko i potraktowali jak własne.\nKto normalny tak robi?!\n",
        "ALYSIA|Zawsze wszystko robili po swojemu.\nNasze wychowanie nie odbiegało od dziwnego schematu, w którym postanowili uczyć nas samodzielnie w domu zamiast posłać do szkoły.\n",
        "ALYSIA|Gdy skończyłam cztery wiosny uczyli nas zielarstwa i podstawowej pierwszej pomocy.\nGdy skończyłam szóstą wiosnę umiałam już polować i przyrządzać zwierzęta.\n",
        "ALYSIA|Na Górze nie miałam nikogo, rodzice przypłynęli tu z kontynentu.\nZostaliśmy więc zupełnie sami.\nWylądowaliśmy w sierocińcu.\n",
        "ALYSIA|Było to dobre i bezpieczne miejsce, a nasi opiekunowie pełni pasji i miłości do dzieci.\nAle nie byli NIMI.\nSamotność i poczucie opuszczenia pożerały nas od środka.\nDobrze, że mieliśmy choć siebie.\n",
        "ALYSIA|Już dosyć wcześnie interesowałam się pracą społeczną i pomaganiem innym.\nZaczęłam się przyglądać, a potem uczestniczyć w opiece nad innymi dziećmi.\nStopniowo dochodziłam do siebie.\n",
        "ALYSIA|Dorastając znów czułam pociąg do zdobywania wiedzy, by potem dzielić się nią z innymi.\nByło więc oczywiste, że zostanę nauczycielką.\n",
        "ALYSIA|Wiedza jest bezcenna - bo pozwala oswoić strach.\n",
        "ALYSIA|Zaś co do Dratoca…\nZniknięcie rodziców zmieniło go.\nNie zauważyłam tego od razu.\n",
        "ALYSIA|Coś w nim pękło.\nZ czasem ta szczelina rosła i rosła, aż pochłonęła go w całości.\nZamykał się w sobie, odcinał.\n",
        "ALYSIA|Przeraziło mnie, gdy pewnego dnia stwierdził, że nie ma go już.\nŻe nie istnieje.\n",
        "ALYSIA|Oświadczył też, że przestał być Dratocem, a zaczął…\n",
        "ALYSIA|Cotardem.",
        "ALYSIA|Reagował wyłącznie na swoje nowe imię.\nPróbowałam walczyć, ale co mogłam zrobić?\n",
        "ALYSIA|Mogłam się z nim porozumieć tylko wtedy, gdy ulegałam i zwracałam się do niego tak, jak chciał.\nInni o dziwo nie zwracali uwagi.\nNie obchodziło to ich tak, jak mnie.\n",
        "ALYSIA|Stał się chłodny. Cichy.",
        "ALYSIA|Nie był już dzieckiem, które poznałam i uznałam za swojego małego braciszka.\nDawniej potrafił gadać bez końca, topił mnie w potoku słów.\n",
        "ALYSIA|Ale już nie.\nOdzywa się tylko wtedy, gdy uzna to za konieczne.\nCzyli prawie nigdy.\n",
        "ALYSIA|Ale wciąż uważam go za mojego brata.\nZawsze będę. Kocham go całym sercem.\n",
        "ALYSIA|To postępuje.\nZmuszam go do posiłków, sam najchętniej nic by nie jadł.\nTwierdzi, że nie potrzebuje jedzenia.\n",
        "ALYSIA|Tylko moje łzy i błagania skutkują.\nChoć do straszne, znajduję w tym pocieszenie - oznacza bowiem, że mój brat nadal czuje emocje. Nadal mu zależy.\nTo dla mnie znaczy wszystko.\n",
        "ALYSIA|Ubrania zużywają się na nim jak drewno w ognisku.\nWrzucam je potajemnie, żeby nie zobaczył zaschniętych śladów krwi i oderwanych kawałków skóry.\n",
        "ALYSIA|Przeraża mnie to.\nCotard ropieje, jego skóra pęka, pokrywa się pęcherzami i liszajem.\nNie mówi mi skąd się to bierze.\n",
        "ALYSIA|Ale ja wiem.\n",
        "ALYSIA|Kiedy próbuje zdecynferkować jego rany, on spokojnie odmawia.\nMówi, że tego nie potrzebuje.\n",
        "ALYSIA|Tutaj mój płacz nie pomaga.",
        "ALYSIA|NIC nie pomaga.\n",
        "ALYSIA|NIC.\n",
        "ALYSIA|Nigdy nie chodzi z nami do gorących źródeł.\nPytałam, czy chodzi o rany, ale stwierdził, że nie.\nPo prostu nie chce.\n",
        "ALYSIA|Myśli, że nie widzę jego reakcji na wodę.\nUnika jej jak trucizny. \nNie myje się.",
        "ALYSIA|Cuchnie chorobą, ale o dziwo nie jest chory.\nO co w tym chodzi…\n",
        "ALYSIA|Pije tylko grzybowy napar. Dobrze, że chociaż tyle.\n",
        "ALYSIA|Wiem już na pewno, ale nikomu nie powiem.\nOn chodzi do Nicości.\n",
        "ALYSIA|Jest jedynym, który w Niej był i wrócił.\nPróbowałam go o to pytać, ale udaje, że nie słyszy.\n",
        "ALYSIA|Zamyka się zupełnie i mnie odcina,\nNie zaprzecza.\nPo prostu stawia przede mną mur.\n",
        "ALYSIA|Praca w prosektorium mu pomaga. \nMało kto go tam ogląda, a sam Cotard dobrze się czuje wśród zmarłych.\nZupełnie, jakby był jednym z nich.\n",
        "ALYSIA|Dopiero po czasie zrozumiałam, że Cotard nie ma węchu.\n",
        "ALYSIA|Do domu wraca uśmiechnięty, zadowolony.\nZamyka się w szopie i siedzi w niej do następnego dnia.\nRano idzie do pracy. I tak dzień w dzień.\n",
        "ALYSIA|Nieraz próbowałam się włamać do jego kryjówki, ale nic z tego.\nKłódka jest mocna, a łańcuchy dobrej jakości. Drzwi mocne.\n",
        "ALYSIA|Z wnętrza dobiega dziwny jęk.\n",
        "ALYSIA|Boję się.\n",
        "ALYSIA|Ludzie dziwnie na nas patrzą.\nGdyby tylko umieli w nim dostrzec, co ja…\n",
        "ALYSIA|Wczoraj spytałam go co robi w tej swojej szopie\n",
        "ALYSIA|Powiedziałam, że chcę wiedzieć BO MAM PRAWO.\n",
        "ALYSIA|Uśmiechnął się tylko i odparł, że to niespodzianka.\n",
        "ALYSIA|NIESPODZIANKA?\n",
        "ALYSIA|Ile lat to już trwa\n",
        "ALYSIA|PO CO?\n",
        "ALYSIA|DLA KOGO?\n",
        "ALYSIA|Pogłaskał mnie po głowie mówiąc: “Już niedługo siostrzyczko. Zobaczysz. Już niedługo”\n",
        "ALYSIA|Zaczęłam płakać.\n",
    };
    //KONIEC PROLOGUE
    
    //POCZĄTEK AKTU 1
    //Dziennik Alysii Wpis 001
    public string[] Chapter1d1 =
    {
        "NARRATOR|Dziennik Alysii Wpis 001",
        "ALYSIA|Dla moich uczniów",
        "ALYSIA|Jeśli czytacie te słowa, to wiecie już, że jestem w miejscu, do którego nikt nie powinien wchodzić.",
        "ALYSIA|On… mówił mi, żebym tego nie robiła.\nŻe nie wszystko jest do odkrycia.\nŻe niektóre tajemnice istnieją tylko po to, by pozostać tajemnicami.",
        "ALYSIA|Ale jeśli świat ma sens, to musi istnieć jego źródło.",
        "ALYSIA|A jeśli go nie ma…\n…to chcę wiedzieć dlaczego.\n",
        "ALYSIA|Nie idę tam jako bohaterka.\nIdę jako nauczycielka, która nie potrafi znieść niewiedzy.\n",
        "ALYSIA|Chcę wiedzieć, co się stało z moimi rodzicami.\n",
        "ALYSIA|I nie jestem sama.\nNie martwcie się.\nOn się mną zaopiekuje.\n",
    };

    //Wejście do Nicości.
    public string[] Chapter1d2 =
    {
        "NARRATOR|Wiatr… jest dziwnie cichy\nNie zimny. Nie ciepły.\nPo prostu… czuć, że pochodzi z Nicości.",
        "NARRATOR|Ogromny krater ciągnie się w dół, jakby świat został wyrwany z własnego ciała.",
        "NARRATOR|Alyssia staje na krawędzi.\nA obok niej \nCotard.\n",
        "ALYSIA|…to tutaj.\n",
        "COTARD|Nie.\n",
        "COTARD|…\n",
        "COTARD|Tu Nic nie ma.\n",
        "NARRATOR|Alyssia wybucha lekkim śmiechem\n",
        "ALYSIA|Właśnie dlatego tu jesteśmy.\n",
        "NARRATOR|Cotard patrzy w dół.\n",
        "NARRATOR|Długo.\n",
        "NARRATOR|Zbyt długo.\n",
        "COTARD|Nie czuję strachu.\n",
        "COTARD|…\n",
        "COTARD|To nie jest odwaga.\n",
    };

    //Wiem, to głupota.
    public string[] Chapter1ch1d2 =
    {
        "ALYSIA|Wiem, to głupota.",
        "COTARD|To dobrze.\nPrzynajmniej to się nie zmieniło",
    };
    
    //Dlaczego tak mówisz?
    public string[] Chapter1ch2d2 =
    {
        "ALYSIA|Dlaczego tak mówisz?",
        "COTARD|Bo ja i tak nie istnieję.\nA jednak nadal potrafię popełniać błędy.",
    };

    //Zejście
    public string[] Chapter1d3 =
    {
        "NARRATOR|Pierwszy krok.\nZiemia nie wydaje dźwięku.",
        "ALYSIA|Słyszysz to?",
        "COTARD|Nie",
        "COTARD|…i właśnie to powinno cię martwić.\n",
        "ALYSIA|Jesteś jedyną osobą, która może tam wejść i wrócić.\n",
        "NARRATOR|Cotard przekrzywia głowę jakby analizował coś czego nie da się zrozumieć\n",
        "COTARD|Boje się, jak na Ciebie zadziała to otoczenie.\n",
    };
    
    //Też się martwię
    public string[] Chapter1ch1d3 =
    {
        "ALYSIA|Też się martwię.",
        "ALYSIA|Boję się, że nagle coś się zmieni i Nicość zacznie działać również na ciebie.\nŻe odbierze mi nawet tę pewność, którą teraz mam.\n",
        "ALYSIA|Ale… przekonamy się, gdy dojdziemy do Kwiecistej Nicości.",
        "NARRATOR|Cotard patrzy na nią długo.\nJego twarz pozostaje niemal nieruchoma, ale głos staje się cichszy.\n",
        "COTARD|…",
        "COTARD|Nie martw się o mnie.",
        "COTARD|Na mnie już Nicość wypróbowała wszystko, co mogła.",
        "ALYSIA|…",
        "ALYSIA|Nieprawda.\nGdyby zrobiła wszystko, nie szedłbyś teraz obok mnie.\n",
        "NARRATOR|Cotard milknie.\nJakby nie potrafił znaleźć odpowiedzi.\nPo chwili rusza dalej.\n",
        "COTARD|…to nie jest argument.\n",
        "NARRATOR|Alyssia lekko się uśmiecha.\n",
        "ALYSIA|Jest.\n",
    };
    
    //Przekonamy się.
    public string[] Chapter1ch2d3 =
    {
        "ALYSIA|Przekonamy się z czasem.\n",
        "ALYSIA|Mam nadzieję, że po prostu nic nam się nie stanie\nMoże to miejsce tylko tylko próbuje nas przestraszyć.\n",
        "NARRATOR|Spogląda w nicość\n",
        "COTARD|Dziwne.\n",
        "COTARD|Ludzie zawsze próbują nadać sens temu, czego się boją.",
        "COTARD|Jakby nazwanie lęku czyniło go mniejszym.",
        "ALYSIA|A ty?\nNa czym budujesz swój spokój\n",
        "COTARD|Na pustce.",
        "COTARD|Nie oczekuję już niczego dobrego.\n",
        "ALYSIA|A ja właśnie odwrotnie.\nOczekuje, że damy sobie radę.\nDlatego dobrze, że idziemy razem.\n",
    };
    
    //JAKIEŚ PÓŁ H ZEJŚCIA
    public string[] Chapter1d4 =
    {
        "COTARD|Nie odwracaj się.\n",
        "COTARD|Już tego nie ma.",
        "ALYSIA|Czego?",
        "COTARD|Góry.\n",
        "COTARD|Zapomniałem jak wyglądała.\n",
    };

    public string[] Chapter1ch1d4 =
    {
        "ALYSIA|Co?! To się dzieje za szybko…\n",
        "COTARD|Nie przesadzaj\nTo normalne.\n",
    };
    public string[] Chapter1ch2d4 =
    {
        "ALYSIA|Zauważyłam już… i to mnie przeraża.\n",
        "COTARD|To normalne.\nPrzyzwyczaisz się.\n",
    };

    public string[] Chapter1d5 =
    {
        "NARRATOR|Po tych słowach Cotard rusza dalej.\nJego kroki są ciche.\nNie dlatego, że stawia je lekko,\n",
        "NARRATOR|Po prostu Nicość nie oddaje dźwięku\nAlyssia idzie tuż za nim\nIm niżej schodzą, tym bardziej powietrze staje się…\n",
        "NARRATOR|inne\n",
        "NARRATOR|Nie cięższe.\n",
        "NARRATOR|Nie rzadsze.\n",
        "NARRATOR|Po prostu obce.\nJakby nie należało do świata.\n",
        "ALYSIA|Cotard…\nCzy to tylko mi sie wydaje, czy powietrze tutaj pachnie inaczej?\n",
        "NARRATOR|Cotard zatrzymuje się na moment \n",
        "NARRATOR|Unosi głowę.\n",
        "COTARD|Tak.",
        "COTARD|Wszystko zaczyna się tutaj.",
        "ALYSIA|Co takiego?",
        "COTARD|Pierwszy poziom.\nKwiecista Nicość.",
        "NARRATOR|Powietrze robi się słodkie.\n",
        "NARRATOR|Zbyt słodkie.\n",
        "NARRATOR|Duszące.\n",
        "NARRATOR|W oddali zaczynają się wyłaniać pierwsze kwiaty.",
        "NARRATOR|Delikatne.",
        "NARRATOR|Białe.\n",
        "NARRATOR|Ich płatki poruszają się mimo, że nie ma wiatru\n",
        //Z zachwytem
        "ALYSIA|Och…\nCotard!\nspójrz tylko\nJak tu pięknie!\n",
        "NARRATOR|Na jej twarzy pojawia się prawdziwy, ciepły uśmiech.\nPierwszy od wejścia.\n",
        "COTARD|Nie podchodź!\n",
    };
    
    //Dlaczego?
    public string[] Chapter1ch1d5 =
    {
        "ALYSIA|Dlaczego?\nSą niebezpieczne?\n",
        "NARRATOR|Cotard patrzy na kwiaty.\n",
        "NARRATOR|Jeden z płatków drży\nPotem cofa się.\nJakby czas na moment się załamał.\n",
        "COTARD|Nie.",
        "COTARD|Gorzej.",
        "COTARD|Chcą, abyś została.\n",
        "ALYSIA|Kwiaty?\n",
        "COTARD|Nie.",
        "COTARD|Całe to miejsce.\n",
    };
    
    //Chcesz powiedzieć, że to…?
    public string[] Chapter1ch2d5 =
    {
        "ALYSIA|Chcesz powiedzieć, że to…?\n",
        "NARRATOR|Dotyka jednego z kwiatów.\n",
        "NARRATOR|Jeden z płatków drży\nPotem cofa się.\nJakby czas na moment się załamał.\n",
        "COTARD|Tak samo jak ja. \n",
        "COTARD|Też powoli znikam.\n",
        "ALYSIA|Nie mów tak.\n",
        "COTARD|Dlaczego?\n",
        "COTARD|Ty jedyna nie próbujesz mi wmówić, że żyję.\n",
    };
    
    //Dziennik Alysii Wpis 002
    public string[] Chapter1d6 =
    {
        "ALYSIA|Dziennik Alysii Wpis 002",
        "ALYSIA|Kwiaty.\nNie potrafię opisać ich piękna.\nSą zbyt doskonałe.\nA przez to nienaturalne.\n",
        "ALYSIA|Cotard twierdzi, że nie są prawdziwe.\nI co najgorsze…\n",
        "ALYSIA|wierzę mu.",
        "ALYSIA|Mam jednak dziwne wrażenie, że to miejsce reaguje na emocje.\nNa zachwyt.\nNa lęk.\nNa wspomnienia.\n",
        "ALYSIA|Im bardziej chcę coś zrozumieć, tym bardziej rzeczywistość wydaje się miękka.\nJakby można ją było rozerwać palcami.\n",
    };
    
    public string[] Chapter1d7 =
    {
        "NARRATOR|Kwiaty drżą.\n",
        "NARRATOR|Pył unosi się w powietrzu jak złoty dym.\nZ głębi łąki dobiega dźwięk.\nCoś bardziej pomiędzy śmiechem a buczeniem\n",
        "UNKNOWN|PRRRRRRRRRRR.\n",
        "NARRATOR|Coś małego przelatuje tuż przed twarzą Alysii.\nOdruchowo cofa się o krok.",
        "NARRATOR|Przed nimi zawisa drobna istota.\n",
        "BEE|Prrr–prrrr!\nOoooOOOO, goście!\nŻywi goście!\n",
        "BEE|Przekrzywia głowę.\nPatrzy na Cotarda.\n",
        "COTARD|…",
        "BEE|Hhahahahahahahahha\nA nie.\nnie wszyscy\nPRRRR.\n",
        "NARRATOR|Zaczyna latać wokół niego.\n",
        "BEE|Ty śmierdzisz!\nFuj FUJ FUUUJJJ",
        "BEE|Jak stare liście.\nJak mokry grób.\nJak coś, co już dawno powinno zostać na dole.",
        "BEE|Prawda Cotard?\n",
        "NARRATOR|Cotard patrzy na nią pustym wzrokiem.\n",
        "COTARD|Odejdź.",
        "BEE|Oooodejdź.\nOoooo odeeejdźź\nPrrrrrrr.\n",
        "NARRATOR|Alysia mimowolnie się uśmiecha.\nTrochę nerwowo\nTrochę rozbawiona\n",
        "ALYSIA|Jesteś… mieszkanką tego miejsca?\n",
        "BEE|A ty jesteś śmieszna.\nPrrr.\n",
        "BEE|Pytasz tak, jakby to miejsce miało mieszkańców.\nTo miejsce ma tylko to, co zostało\nI to jest SUUUUUUUUUUUUPER\n",
        "ALYSIA|A co to znaczy… “ to, co zostało”?\n",
        "BEE|To, czego Nicość nie połknęła.\n",
        "BEE|Jeszcze.",
        "BEE|Wspomnienia… żale\nResztki ludzi.\n",
        "NARRATOR|Pszczółka znów patrzy na Cotarda\n",
        "BEE|Albo resztki życia.\nPrrrrrrrrrrrr\n",
        "ALYSIA|Przepraszam, że spytam ale…\nWidziałaś może naszych rodziców?\n",
        "ALYSIA|Badaczy.\nByli tu lata temu\n",
        "BEE|OoooooOOOo.\nTych.\nPrrrrr.\n",
        "BEE|Tak.\nWidziałam.\n",
        "ALYSIA|Co?! Naprawdę?!\n",
        "ALYSIA|Gdzie?!\n",
        "ALYSIA|Co się z nimi stało?!",
        "NARRATOR|Pszczółka wykonuje kilka chaotycznych obrotów w powietrzu.\n",
        "BEE|Pachniesz jak oni.\n",
        "BEE|Zeszli niżej.\n",
        "BEE|Niżej.\nNiżej.\n",
        "BEE|Zawsze niżej.\n",
        "BEE|Szukali.\ntak jak ty.\n",
        "BEE|…\n",
        "BEE|Aleeee\n",
        "BEE|PRRRR",
        "BEE|Źródło patrzy też w górę.\n",
        "NARRATOR|Cotard patrzy na nią chłodno.",
        "COTARD|Wiesz coś więcej o rodzicach?.\n",
        "NARRATOR|Pszczółka śmieje się.\n",
        "BEE|Prr.\nCzyli jednak ci zależy.\n",
        "COTARD|…\n",
        "BEE|Przeszli przez łąkę.\nKłócili się.\n",
        "BEE|O to, które z nich zaczęło znikać pierwsze.\n",
        "NARRATOR|Cotard spogląda na Alyssie.\nW jego oczach po raz pierwszy pojawia się cień napięcia.\n",
        "COTARD|Kiedy?\n",
        "BEE|Tutaj?\nTu czas nie istnieje.\nPrr.\n",
        "BEE|Ale dla Was?\n",
        "BEE|DAWNO.",
        "BEE|Miło się gadało, lecę zapylać kwiatkiiiii!!!!\nPrrrrrrrrr!\n",
        "NARRATOR|Pszczółka odlatuje i znika w oddali.\n",
        "NARRATOR|Alyssia i Cotard stoją dłuższą chwilę w ciszy.\n",
        "NARRATOR|…",
        "NARRATOR|Patrzą na siebie\nAlysia przerywa ciszę\nZaciska notes przy piersi.\n",
        "ALYSIA|Więc…\nNaprawdę tu byli\n",
        "NARRATOR|Cotard patrzy na nią.\n",
        "COTARD|Albo to miejsce chce, żebyś w to uwierzyła.\n",
        "ALYSIA|A jeśli choć raz nie masz racji?\n",
        "COTARD|…\n",
        "NARRATOR|Nagle znów słychać bzyczenie\n",
        "BEE|Prrrrr!\nJeśli chcecie znaleźć odpowiedzi…\nschodźcie niżej.\n",
        "BEE|Ale uważajcie.\nNa następnym poziomie Nicość nie pokazuje już kwiatów.\n",
        "BEE|Pokazuje prawdę.\nCzyli to, czego najbardziej się boicie.\n",
        "NARRATOR|Nie zdążyli zareagować.\nOdleciała.\n",
    };
    
    //IDĄ W DÓŁ
    public string[] Chapter1d8 =
    {
        "NARRATOR|Z głębi łąki dobiega śmiech.\n",
        "NARRATOR|Dziecięcy.",
        "NARRATOR|Znajomy.",
        "NARRATOR|Alyssia zamiera.",
        "UNKNOWN|Pani Alysio!\n",
        "NARRATOR|Na końcu ścieżki stoją dzieci.\nJej uczniowie.\n",
        "STUDENTS|Wróci Pani?\n",
        "STUDENTS|Brakuje nam Pani…\n",
        "NARRATOR|Cotard gwałtownie łapie ją za nadgarstek\nJego dłoń jest lodowata.\n",
        "COTARD|Nie patrz na nich!\n",
        "ALYSIA|To moi uczniowie!\nMusieli się o mnie martwić!\n",
        "NARRATOR|Alysia próbuje się wyrwać.\nCotard zaciska dłoń mocniej.\n",
        "ALYSIA|Puść mnie Cotard!!!\n",
        "NARRATOR|Pierwszy raz w jego głosie słychać… GNIEW.\n",
        "COTARD|NIE.\n",
        "COTARD|to nie oni\n",
        "COTARD|NICOŚĆ wie, czego najbardziej ci brakuje.\nI użyje tego przeciwko tobie.\n",
        "NARRATOR|Głos.\nRozbrzmiewa wszędzie.\n",
        "UNKNOWN|Jedno.\nMusi.\nZniknąć.\n",
        "NARRATOR|Alysia patrzy na Cotarda.\n",
        "ALYSIA|Słyszysz to?\n",
        "COTARD|Tak.\n",
        "COTARD|…\n",
        "COTARD|To nie głos.\n",
        "COTARD|To brak czegoś, co powinno istnieć.\n",
        "NARRATOR|Wszystko cichnie.\nNawet kwiaty przestają drżeć.\n",
        "NARRATOR|Przed nimi ziemia pęka na dwie ścieżki\nLewa - skąpana w jasnym miękkim świetle\nPrawa - ciemna, pozbawiona koloru.\n",
        "UNKNOWN|Lewo - Zostań. ",
        "UNKNOWN|Prawo - Zejdź niżej. Ale stracisz.\n",
        "UNKNOWN|Alysio.\nDecyzja zależy od Ciebie.",
        "NARRATOR|Zapada cisza.\n",
        "NARRATOR|Alysia patrzy na swoje dłonie.\nDrżą.\n",
        "COTARD|Alysio, musisz odpocząć.\n",
        "ALYSIA|Ja…\n",
        "ALYSIA|Nie wiem, co mam zrobić,\nNie wiem, czy to w ogóle jest wybór.\nAle czuję, że nie ma tu dobrej decyzji.\nNie chcę ich stracić…\n",
        "NARRATOR|Cotard patrzy na iluzje uczniów.\nNa twarzy Alysii maluje się ból.\n",
        "ALYSIA|Nie mogę.\nNie mogę ich tak po prostu usunąć!\n",
        "COTARD|To nie oni!",
        "ALYSIA|Skąd wiesz?!!!",
        "COTARD|Bo Nicość nie daje.\nOna tylko odbiera.\nNie tworzy życia.",
        "ALYSIA|A jeśli odbierze mi ich wspomnienia?!",
        "COTARD|Już zaczęła.\n",
        "COTARD|Pamiętasz ich twarze?!\n",
        "COTARD|Pamiętasz jak wyglądała góra?!",
        "NARRATOR|Alysia milknie.\nOczy jej drżą.\n",
        "NARRATOR|Próbuje sobie przypomnieć.\nI nie potrafi.\nTo ją łamie.\n",
        "ALYSIA|…\n",
        "ALYSIA|nie.",
        "COTARD|No właśnie.",
        "ALYSIA|Mówisz, że Oni nie istnieją…\nTo dlaczego o sobie mówisz to samo?",
    };
    
    //MAIN DECISION CHAPTER 1
    
    //ZOSTAŃ
    public string[] Chapter1ch1d8 =
    {
        "NARRATOR|Alysia patrzy na swoich uczniów.\nIch głosy są miękkie.\n",
        "NARRATOR|Znajome.\nPełne ciepła\n",
        "NARRATOR|Dotyka świetlistej chmury.\nW tej samej chwili świat mięknie.\nKwiaty rozkwitają gwałtownie.\n",
        "NARRATOR|Światło zalewa jej wizje\nJej twarz rozluźnia się.\nUśmiecha\n",
        "STUDENTS|Gdzie pani była?\nMartwiliśmy się.\n",
        "ALYSIA|Ja…\n",
        "ALYSIA|chyba się zgubiłam.\nAle już wszystko dobrze.\nMożemy wracać.\n",
        "NARRATOR|Powoli siada na łące.\nKładzie się między kwiatami.\nOczy same się zamykają.\n",
        "NARRATOR|Cotard rzuca się do Alysii\nPo raz pierwszy jego głos\ndrży.\n",
        "COTARD|Alysia…\n",
        "COTARD|Nie…\n",
        "COTARD|Proszę…",
        "NARRATOR|Po jego policzku spływa łza.\n",
        "COTARD|Nie zostawiaj mnie tutaj samego\n",
        "COTARD|…\n",
        "COTARD|Nie znikaj.",
        "NARRATOR|Alysia nie odpowiada.\nZostaje na łące.\nUśpiona przez Nicość.\n",
        "NARRATOR|Cotard zaczyna płakać.\n",
    };
    // IDŹ DALEJ
    public string[] Chapter1ch2d8 =
    {
        "NARRATOR|Alysia zamyka oczy.\nŁzy zbierają się pod powiekami.\n",
        "COTARD|To nie oni.\n",
        "NARRATOR|Iluzja zaczyna pękać.\nŚwiatło przygasa.\nSylwetki uczniów powoli znikają\n",
        "STUDENTS|Pani Alysio… dlaczego…?\n",
        "NARRATOR|Alysia odwraca wzrok\nNie potrafi patrzeć.\n",
        "ALYSIA|Przepraszam…\n",
        "NARRATOR|Uczniowie znikają.\nZaczyna płakać\n",
        "NARRATOR|Świat wokół nich traci kolory.\nKwiaty stają się niemal szare.\n",
        "COTARD|Dobrze\n",
        "COTARD|…\n",
        "COTARD|To jest prawdziwe.",
        "ALYSIA|Co?\n",
        "COTARD|To, że ich nie ma\nWolałem się upewnić.\n",
        "COTARD|… Chodź.\nIdziemy niżej\n",
        "NARRATOR|Alysia ociera łzy.\n",
        "ALYSIA|Zaczynam rozumieć, dlaczego ludzie nie chcą wiedzieć.\nJeśli każde zejście wymaga poświęcenia to…\n",
        "ALYSIA|ile z naszych wspomnień zostanie na końcu?\nA jeśli na samym końcu nie zostanie nic?\nto kim będę.\n",
    };
    
    //KONIEC AKTU 1
    
    //POCZĄTEK AKTU 2
    public string[] chapter2d1 =
    {
        "NARRATOR|Powoli schodzą po schodach.\nKamienna podłoga stopniowo przekształca się w lodową taflę pokrytą pajęczyną pęknięć.\nWyczuwają pod stopami delikatny ruch. \n",
        //Alyssia:
        "ALYSIA|\nCotard… \nZimno mi.\nAle… Ale nie w ciało \n.Dziwne…",

        "NARRATOR|Cotard patrzy na swoje dłonie.\nNie drżą.",

        //Cotard:
        "COTARD|To nie jest zimno.",
        "COTARD|To efekt Nicości.",

        "NARRATOR|Oddech Alyssi staje się spokojniejszy.",

        //Alyssia:

        "ALYSIA|Czy to normalne, że przestaję się bać?",
        "ALYSIA|Przecież powinnam.\nWiem o tym.",
        "ALYSIA|Ale…",
        "ALYSIA|Jakby ktoś wyciszył mnie w środku.",

        "NARRATOR|Alyssia dotyka klatki piersiowej.",

        //Alyssia:
        "ALYSIA|Jakby moje własne serce było gdzieś daleko stąd. .",
        "ALYSIA|Powinnam się bać…\nA jakoś…",
        "ALYSIA|Nie potrafię.",
        "ALYSIA|To chyba źle? Prawda?",

        "NARRATOR|Cotard patrzy przed siebie.\nIdzie nie zatrzymując się.\nMilczy.",

        "NARRATOR|Docierają na sam dół schodów.",
        "NARRATOR|Przed nimi rozpościera się niekończąca się jaskinia.",

        //Cotard:
        "COTARD|Ten lód nie jest przezroczysty.",
        "COTARD|Jest zapisany wspomnieniami.",
        "COTARD|Tu byłem najniżej, nie wiem co jest dalej.",

        "NARRATOR|Spod tafli lodu słychać szepty.",
        "NARRATOR|Nie pojedyncze głosy.\nDziesiątki. Setki.\nNakładają się na siebie.\nRezonują w narastający krzyk rozpaczy.",

        //SZEPTY:
        "UNKNOWN|…wróć…",
        "UNKNOWN|…nie pamiętasz mnie…",
        "UNKNOWN|…zostań…",
        "UNKNOWN|…to boli…",

        //Alyssia:
        "ALYSIA|To są ludzie.",
        "ALYSIA|To ich wspomnienia",

        //Cotard:
        "COTARD|Nie.",
        "COTARD|To są resztki wspomnień, tych co byli w Nicości.",

        "NARRATOR|Dwie ogromne bryły lodu z hukiem przebijają powierzchnię.\nSą idealnie gładkie.\nAle ich wnętrze… Żyje.",

        //Lewa Bryła:
        "LEFT_ICEBLOCK|Mały dom.",
        "LEFT_ICEBLOCK|Ciepłe światło.",
        "LEFT_ICEBLOCK|Śmiech.",
        "LEFT_ICEBLOCK|Mała Alyssia ucieka z poduszką.",
        "LEFT_ICEBLOCK|Mały Cotard goni ją, wyraźnie zirytowany.",

        //Prawa Bryła:
        "RIGHT_ICEBLOCK|Stół.",
        "RIGHT_ICEBLOCK|Rozłożona mapa Nicości.",
        "RIGHT_ICEBLOCK|Rodzice kłócą się.",
        "RIGHT_ICEBLOCK|Atmosfera napięta.",
        "RIGHT_ICEBLOCK|Strach.",

        //Alyssia:
        "ALYSIA|To… my.",
        "ALYSIA|To naprawdę my.",

        //Cotard:
        "COTARD|Wydaje mi się, że to zapis tego co było.",
        "COTARD|Albo tego, co Nicość chcę żebyś pamiętała.",

        "NARRATOR|Alyssia wyciąga rękę.",
        "NARRATOR|Dotyka lodu.",
        "NARRATOR|Nic.",
        "NARRATOR|Patrzy na Cotarda.",

        //Alyssia:
        "ALYSIA|Musimy razem.\nPrawda?",

        "NARRATOR|Cotard przez chwile się nie rusza.\nPotem przykłada dłoń",

    };
    //DZIECIŃSTWO
    public string[] Chapter2ch1d1 =
    {
        "NARRATOR|Lód pęka\nŚwiat zmienia się natychmiast.",
        "NARRATOR|Ciepło.",
        "NARRATOR|Zapach drewna.",
        "NARRATOR|Światło ognia.",

        //<Czarne tło>

        //Mała Alyssia:
        "LIL_ALYSIA|Oddaj! To moja poduszka!",

        //Mały Cotard:
        "LIL_COTARD|Nie jest twoja!\nZabrałaś mi ją pierwsza.",

        "NARRATOR|Cotard rzuca poduszką w Alyssie.\nAlyssia piszczy i śmieje się.",

        //Mały Cotard:
        "LIL_COTARD|Przestań się śmiać!\nTo nie jest śmieszne!",

        "NARRATOR|Alyssia rzuca kolejną poduszką.\nTrafia go.\nCotard się zatrzymuje",
        "NARRATOR|Przez sekundę wygląda jakby miał się rozpłakać.\nAle zamiast tego…",
        "NARRATOR|Rzuca książką.",

        //<Koniec czarnego tła>


        //Alyssia:
        "ALYSIA|To był ten moment…",
        "ALYSIA|Siniak.",
        "ALYSIA|Ukrywaliśmy to przed rodzicami.\nBałam się, że zamkną biuro.",

        //Cotard:
        "COTARD|Bałaś się bardziej kary, czy tego, że stracisz dostęp do wiedzy?",

        "NARRATOR|Alyssia patrzy na niego zaskoczona",

        //Alyssia:
        "ALYSIA|… obu.",

        //Cotard:
        "COTARD|To nie było całe wspomnienie.",
        "COTARD|Tylko fragment.",

        //Alyssia:
        "ALYSIA|…",

    };
    //RODZICE
    public string[] Chapter2ch2d1 =
    {
        "NARRATOR|Lód pęka.\nZimno uderza natychmiast.",

        //<Czarne tło>

        "NARRATOR|Stół.",
        "NARRATOR|Mapa Nicości.",
        "NARRATOR|Zaznaczone poziomy.",
        "NARRATOR|Niektóre przekreślone.",

        //Ojciec:
        "FATHER|To nie jest tylko struktura!",
        "FATHER|To system!",


        //Matka:
        "MOTHER|System?!",
        "MOTHER|Czego?!\nZnikania?!",

        //Ojciec:
        "FATHER|Każdy poziom coś zabiera!",
        "FATHER|Najpierw zmysły!\nPotem pamięć!\nPotem…",


        //<Koniec czarnego tła>
        //<Czarne tło>

        //Matka:
        "MOTHER|A jeśli to miejsce nie odbiera…\ntylko odsłania?",


        //<Koniec czarnego tła>


        //Alyssia:
        "ALYSIA|Oni wiedzieli…\nwięcej niż mówili…",

        //Cotard:
        "COTARD|Dobrze wiedzieli, co ich czeka.",

    };

    public string[] chapter2d2 =
    {
        "NARRATOR|Obydwie bryły lodu zostały zniszczone. \nNa ich miejscu pojawiły się jedna, nowa.",

        //Bryła:
        "NARRATOR|Sala. \nDziesiątki ludzi. \nZatrzymani w ruchu.",

        "NARRATOR|Cotard i Alysia dotykają razem bryłę lodu. \nLód pęka.",

        //<Czarne tło>
        "NARRATOR|Sala. \nDziesiątki ludzi.",

        //Mężczyzna 1:
        "MAN_1|To nie jest teoria. \nMamy dowód.",

        //Kobieta 1:
        "WOMAN_1|Nie powinniśmy byli go sprowadzac z powrotem.",

        //Starszy mężczyzna:
        "OLD_MAN|Musieliśmy.\nTo jedyna osoba, która wróciła.",

        //Mężczyzna 2:
        "MAN_2|To NIE jest osoba.",

        //Kobieta 2:
        "WOMAN_2|Nie ma reakcji emocjonalnych. \nNie reaguje na bodźce. \nNie rozpoznaje części własnych wspomnień.",

        //Mężczyzna 1:
        "MAN_1|Twierdzi, że nie istnieje.",

        //Kobieta 2:
        "WOMAN_2|To klasyczny rozpad tożsamości.",

        //Starszy Mężczyzna:
        "OLD_MAN|Nie.",

        "NARRATOR|Wszyscy milkną",

        "OLD_MAN|To adaptacja.",


        //Mężczyzna 2:
        "MAN_2|Adaptacja?!",
        "MAN_2|Czego?!",

        //Starszy Mężczyzna:
        "OLD_MAN|Milczeć!",
        "OLD_MAN|Spełnił to czego Nicość wymaga \nStracił emocje. \nStracił poczucie istnienia.",
        "OLD_MAN|Ale dzięki temu…",
        "OLD_MAN|Przetrwał.",

        "OLD_MAN|Musimy wysłać kogoś głębiej.",

        //<Koniec czarnego tła>

        "NARRATOR|Bryła się nie rozpadła, jest zmieniona.",


        "NARRATOR|Dotykają jej ponownie.",

        //<Czarne tło>

        "NARRATOR|Na ziemi leży blade, rozkładające się ciało.",

        "NARRATOR|To Cotard.",

        //<Koniec czarnego tła>

        //Cotard:
        "COTARD|To ten moment,",
        "COTARD|w którym przestałem istnieć.",

        //Alyssia:
        "ALYSIA|Nie możesz tak mówić!",
        "ALYSIA|Przecież stoisz tutaj! \nOddychasz!!!",

        //Cotard:
        "COTARD|Nie.",
        "COTARD|To co widzisz…\nTo kontynuacja mojej śmierci.",
        "COTARD|Po tym… ",
        "COTARD|Nagle znów mogłem się ruszać…",

        //Alyssia:
        "ALYSIA|Jeśli to wspomnienie jest prawdziwe…to kim jesteś?",

        "NARRATOR|Cotard patrzy na nią bez emocji.",

        //<Czarne tło>

        "NARRATOR|Cotard jest w sali narad.",

        //Mężczyzna 1:
        "MAN_1|… on nie oddycha.",

        //Kobieta 1:
        "WOMAN_1|Nie ma pulsu",

        //Mężczyzna 2:
        "MAN_2|Więc o czym my w ogóle rozmawiamy?",
        "MAN_2|To ciało.",

        //Starszy Mężczyzna:
        "OLD_MAN|Milcz.",

        "OLD_MAN|Notuj.",
        "OLD_MAN|Brak reakcji na bodźce.",
        "OLD_MAN|Brak funkcji życiowych.",

        "NARRATOR|Nagle palec martwego Cotarda drga.",

        //Kobieta 1:
        "WOMAN_1|Widzieliście to?!",

        "NARRATOR|Martwy Cotard otwiera oczy.",

        "NARRATOR|Nie łapie oddechu.",
        "NARRATOR|Nie reaguje.",
        "NARRATOR|Nie porusza się gwałtownie.",

        "NARRATOR|Po prostu…",
        "NARRATOR|Patrzy.",

        //Mężczyzna 1:
        "MAN_1|…czy on nas widzi?",

        "NARRATOR|Cotard powoli podnosi głowę. \nSiada.",

        //Cotard:
        "COTARD|… to nie ma znaczenia.",

        //Kobieta 1:
        "WOMAN_1|On… mówi",

        //Mężczyzna 2:
        "MAN_2|Nie.",
        "MAN_2|Nie, nie nie…",

        //Starszy Mężczyzna:
        "OLD_MAN|Cisza!",

        "OLD_MAN|NARRATOR|Starszy mężczyzna podchodzi do Cotarda. \nPatrzy mu prosto w oczy.",

        "OLD_MAN|Jak się nazywasz?",

        //Cotard:
        "COTARD|To nie ma znaczenia.",

        //Starszy mężczyzna:
        "OLD_MAN|To dziecko spełniło warunek. \nOddał wszystko, co było zbędne.",

        "NARRATOR|Musimy spróbować ponownie. \nZobaczyć co się stanie.",

        //Kobieta 1:
        "WOMAN_1|Oszalałeś?!",

        //Starszy Mężczyzna:
        "OLD_MAN|Musimy, inaczej nie dowiemy się dlaczego.",


        //<Koniec czarnego tła>


        //Cotard:
        "COTARD|Ja tego nie pamiętam.",
        "COTARD|Nie wiem kim są ci ludzie.",

        //Alysia:
        "ALYSIA|Oni… patrzyli na Ciebie jak na narzędzie. \nMówili o tobie jak o wyniku. \nNie jak o człowieku.",

        //Cotard:
        "COTARD|Bo człowiekiem przestałem być dla nich w momencie, kiedy przestałem reagować.",
        "COTARD|Dla siebie również.",

        //Alysia:
        "ALYSIA|Pamiętasz swoje pierwsze zejście do Nicości?",

        //Cotard:
        "COTARD|Nie.",

        //Alyssia:
        "ALYSIA|Dlaczego tam chodziłeś, jak już stałeś się sobą?",

        //Cotard:
        "COTARD|Bo ja nie wiem, co tracę.",
        "COTARD|Więc nie mam czego żałować.",

//—---------------------------------------------------------------------

        "NARRATOR|Hałas wokół nich milknie, \nŻadnych szeptów. \nŻadnych ruchów.",

        "NARRATOR|Jakby wszystko… \nZostało już zapisane \ni zamknięte.",

        //Alysia:
        "ALYSIA|Cotard…",
        "ALYSIA|Co się teraz stanie?",

        "NARRATOR|Nie odpowiada od razu.",

        //Cotard:
        "COTARD|…",
        "COTARD|Myślę, że to moment…",
        "COTARD|W którym jesteśmy sprawdzani.",

        "NARRATOR|Lód pod ich stopami zaczyna drżeć. \nNie pęka. \nNie rozpada się.",

        //Nicość:
        "UNKNOWN|Wystarczająco.\nOddaliście.",

        //Alysia:
        "ALYSIA|Nie chcieliśmy niczego oddawać.",

        //Nicość
        "UNKNOWN|Nie ma różnicy.",

        "NARRATOR|Te słowa… \nUderzają mocniej niż powinny.",

        "NARRATOR|Cotard stoi spokojnie \nJakby wszystko było logiczne",

        "NARRATOR|Lód przed nimi topi się, a rozgrzana woda paruje. \nPojawia się tunel do wnętrza wodnej czeluści.",

        //Nicość:
        "UNKNOWN|Możecie zejść niżej.",

        //Alyssia:
        "ALYSIA|Ile jeszcze…",

        //Nicość:
        "UNKNOWN|Tyle ile pozostało.",

        "NARRATOR|Ruszają",

        "NARRATOR|Lód zamyka się nad nimi. \nCisza wraca. \nJakby nic nigdy się tu nie wydarzyło.",
        
        "DZIĘKUJĘ ZA OGRANIE \nDO ZOBACZENA W AKCIE TRZECIM"
    };
    //KONIEC AKTU 2
}
