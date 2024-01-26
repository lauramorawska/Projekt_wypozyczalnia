# Dokumentacja

W pierwszej części dokumentacji zamieszczony został opis techniczny poszczególnych klas "Projektu",
w dalszej części - opis poszczególnych okien interfejsu graficznego.

## Pakiety wymagające instalacji
WpfAnimatedGif
Projektant Klas
EntityFramework


## Klasa Klient

Klasa reprezentująca informacje o kliencie wypożyczalni.

## Właściwości

### NrDowoduOsobistego (string)

```
        public string NrDowoduOsobistego
        {
            get => nrDowoduOsobistego; set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{3}\d{6}$"))
                {
                    throw new BledyNrDowoduException("Niepoprawne Dane!");
                }
                nrDowoduOsobistego = value;
            }
        } 
        
```

Pobiera numer dowodu osobistego klienta. Sprawdza czy format jest poprawny (3 litery, 4 cyfry - jesli nie, wyrzuca wyjątek BledyNrDowoduException).


Reszta właściwości pobiera lub ustawia imię, naziwsko i numer telefonu klienta.

### Konstruktory

- **Klient():** Konstruktor domyślny, tworzy instancję klasy Klient z pustymi danymi.
- **Klient(string imie, string nazwisko, string numerTelefonu, string nrDowoduOsobistego):** Konstruktor inicjalizujący instancję klasy Klient danymi przekazanymi jako parametry.

### Metody

- **Clone() : object:** Metoda implementująca interfejs ICloneable, umożliwiająca klonowanie obiektu klasy Klient.
- **CompareTo(Klient? other) : int:** Metoda implementująca interfejs IComparable<Klient>, umożliwiająca porównanie dwóch obiektów klasy Klient na podstawie nazwiska i imienia.
- **ToString() : string:** Przesłonięta metoda ToString() zwracająca czytelny tekstowy opis obiektu klasy Klient.

### Właściwości Dodatkowe

- Pobiera lub ustawia unikalny identyfikator klienta (`klientID`), identyfikator wypożyczalni, z którą klient jest powiązany (`WypozyczalniaId`), i właściwość reprezentującą powiązaną wypożyczalnię (`Wypozyczalnia`).

## Klasa Pracownik

Klasa Pracownik reprezentuje informacje o pracowniku w systemie. Posiada podstawowe właściwości, takie jak imię, nazwisko, numer PESEL, dostępność (na urlopie czy nie), numer telefonu oraz przypisaną rolę, zdefiniowaną w typie wyliczeniowym `EnumRola`.

### Konstruktory

- **Pracownik():** Konstruktor domyślny, tworzy instancję klasy Pracownik.
- **Pracownik(string imie, string nazwisko, string pesel, bool dostepny, string nrTelefonu, EnumRola rola):** Konstruktor inicjalizujący instancję danymi przekazanymi jako parametry.

### Metody

- **CompareTo(Pracownik? other) : int:** Metoda implementująca interfejs IComparable<Pracownik>, umożliwiająca porównanie dwóch obiektów klasy Pracownik na podstawie nazwiska i imienia.
- **Clone() : object:** Metoda implementująca interfejs ICloneable, umożliwiająca klonowanie obiektu klasy Pracownik.
- **Equals(Pracownik? other) : bool:** Metoda implementująca interfejs IEquatable<Pracownik>, umożliwiająca porównanie dwóch obiektów klasy Pracownik na podstawie numeru PESEL.
- **ToString() : string:** Przesłonięta metoda ToString() zwracająca czytelny tekstowy opis obiektu klasy Pracownik oraz wypisująca numer telefonu w formacie substringów (`xxx-xxx-xxx`).

### Właściwości Dodatkowe

- Klasa korzysta z atrybutu `[DataContract]` do oznaczenia, że może być serializowana.

## Program

W klasie program tworzymy nowych klientów, pracowników, wypożyczenia, testujemy metody oraz wywołujemy zapis i odczyt z bazy danych.

```csharp
wypozyczalnia1.ZapiszDoBazy();
wypozyczalnia1.OdczytBazyDanych();
```

## Klasa Samochód

### Właściwości

- **Marka (string):** Marka samochodu.
- **Model (string):** Model samochodu.
- **NumerRejestracyjny (string):** Numer rejestracyjny samochodu.
- **CzyDostepny (bool):** Informacja o dostępności samochodu.
- **RokProdukcji (int):** Rok produkcji samochodu.
- **Kaucja (decimal):** Kwota kaucji za wypożyczenie samochodu.
- **Stan (EnumStan):** Stan samochodu, zdefiniowany w typie wyliczeniowym EnumStan.

### Relacje

- `SamochodySport (List<SamochodSportowy>):` Lista samochodów sportowych powiązanych z danym obiektem.
- `SamochodyKlas (List<SamochodKlasyczny>):` Lista samochodów klasycznych powiązanych z danym obiektem.
- `SamoWielo (List<SamochodWieloosobowy>):` Lista samochodów wieloosobowych powiązanych z danym obiektem.
- `SamochodyCab (List<SamochodCabriolet>):` Lista samochodów cabriolet powiązanych z danym obiektem.

### Konstruktory

- **Samochod():** Konstruktor domyślny, tworzy instancję klasy Samochod z domyślnymi danymi.
- **Samochod(string marka):** Konstruktor z jednym parametrem, inicjalizuje markę samochodu.
- **Samochod(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal kaucja, EnumStan stan):** Konstruktor inicjalizujący instancję danymi przekazanymi jako parametry.

### Metody

- **Clone():** Implementuje interfejs ICloneable, umożliwia klonowanie obiektu klasy Samochod.
- **ToString():** Przesłonięta metoda ToString(), zwraca czytelny tekstowy opis obiektu klasy Samochod ze wszystkimi jego elementami.

### Uwagi

- Klasa korzysta z atrybutu `[DataContract]` do oznaczenia, że może być serializowana.
- Klasa zawiera atrybuty `[KnownType]` oraz `[XmlInclude]` do obsługi dziedziczenia i serializacji klas pochodnych.

## Klasa Samochód Cabriolet

Klasa SamochodCabriolet reprezentuje informacje o rodzaju samochodu Cabriolet w systemie wypożyczalni. 
Jest pochodną klasy Samochod i dziedziczy jej właściwości oraz metody.

### Właściwości

- **Dach (EnumDach):** Rodzaj dachu samochodu Cabriolet, zdefiniowany w typie wyliczeniowym EnumDach.

### Konstruktory

- **SamochodCabriolet():** Konstruktor domyślny, tworzy instancję klasy SamochodCabriolet.
- **SamochodCabriolet(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal cenaZaDzienWypozyczenia, EnumDach dach, decimal kaucja, EnumStan stan):** Konstruktor inicjalizujący instancję danymi przekazanymi jako parametry. Wywołuje także konstruktor klasy bazowej Samochod.

### Metody

- **ToString():** Przesłonięta metoda ToString(), zwraca czytelny tekstowy opis obiektu klasy SamochodCabriolet.
  Wypisuje informacje o marce, modelu, roku produkcji, numerze rejestracyjnym, dostępności, stanie, kaucji i rodzaju dachu.

### Uwagi

- Klasa korzysta z atrybutu `[DataContract]` do oznaczenia, że może być serializowana.

## Klasa Samochód Klasyczny

Klasa SamochodKlasyczny reprezentuje informacje o samochodzie klasycznym w systemie wypożyczalni. 
Jest pochodną klasy Samochod i dziedziczy jej właściwości oraz metody.

### Konstruktory

- **SamochodKlasyczny():** Konstruktor domyślny, tworzy instancję klasy SamochodKlasyczny.
- **SamochodKlasyczny(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal cenaZaDzienWypozyczenia, decimal kaucja, EnumStan stan):** 
  Konstruktor inicjalizujący instancję danymi przekazanymi jako parametry. Wywołuje także konstruktor klasy bazowej Samochod.

### Metody

- **ToString():** Zwraca wszystkie właściwości samochodu w czytelny sposób.


### Samochód sportowy

Klasa `SamochodSportowy` reprezentuje informacje o samochodzie sportowym w systemie wypożyczalni. Jest pochodną klasy `Samochod` i dziedziczy jej właściwości oraz metody.

### Właściwości

- **KonieMechaniczne (int):** Moc silnika samochodu sportowego wyrażona w koniach mechanicznych.
- **PodwojnyTlumik (bool):** Informacja o dostępności podwójnego tłumika w samochodzie sportowym.

### Konstruktory

- **SamochodSportowy():** Konstruktor domyślny, tworzy instancję klasy `SamochodSportowy`.
- **SamochodSportowy(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal cenaZaDzienWypozyczenia, int konieMechaniczne, bool podwojnyTlumik, decimal kaucja, EnumStan stan):** Konstruktor inicjalizujący instancję danymi przekazanymi jako parametry. Wywołuje także konstruktor klasy bazowej `Samochod`.


### Metody

- **ToString():** Przesłonięta metoda `ToString()`, zwraca czytelny tekstowy opis obiektu klasy z wszystkimi jego właściwościami.


## Samochód Wieloosobowy

Klasa `SamochodWieloosobowy` reprezentuje informacje o samochodzie wieloosobowym w systemie wypożyczalni. Jest pochodną klasy `Samochod` i dziedziczy jej właściwości oraz metody.

### Właściwości

- **Ilosc (EnumMiejsca):** Określa liczbę miejsc w samochodzie wieloosobowym. Jest to typ wyliczeniowy `EnumMiejsca`.
Dostępne opcje - siedmioosobowy i dziesięcioosobowy

### Konstruktory

- **SamochodWieloosobowy():** Konstruktor domyślny, tworzy instancję klasy `SamochodWieloosobowy`.
- **SamochodWieloosobowy(string marka, string model, string numerRejestracyjny, int rokProdukcji, decimal cenaZaDzienWypozyczenia, EnumMiejsca ilosc, decimal kaucja, EnumStan stan):** Konstruktor inicjalizujący instancję danymi przekazanymi jako parametry. Wywołuje także konstruktor klasy bazowej `Samochod`.


### Metody

- **ToString():** Przesłonięta metoda `ToString()`, zwraca czytelny tekstowy opis obiektu klasy `SamochodWieloosobowy`.



## Klasa Wypożyczalnia

Klasa `Wypozyczalnia` reprezentuje wypożyczalnię w systemie. Implementuje interfejs `IWypozyczanie` i zawiera informacje o wypożyczeniach, pracownikach, klientach, samochodach oraz aktualnej kasie.

## Właściwości

- **Nazwa (string):** Określa nazwę wypożyczalni.
- **Wypozyczenia (List<Wypozyczenie>):** Lista wypożyczeń zawartych w wypożyczalni.
- **Pracownicy (List<Pracownik>):** Lista pracowników zatrudnionych w wypożyczalni.
- **Klienci (List<Klient>):** Lista klientów korzystających z usług wypożyczalni.
- **Samochody (List<Samochod>):** Lista samochodów dostępnych w wypożyczalni.
- **Kasa (decimal):** Ilość środków pieniężnych zgromadzonych przez wypożyczalnię.

## Metody

- **Wypozyczalnia():** Konstruktor domyślny, inicjalizuje listy wypożyczeń, pracowników, klientów i samochodów, ustawia wartość kasy na 0.
- **Wypozyczalnia(string nazwa):** Konstruktor inicjalizujący instancję klasy daną nazwą, inicjalizuje także listy wypożyczeń, pracowników, klientów i samochodów, ustawia wartość kasy na 0.
- **DodajKlienta(Klient k):** Dodaje klienta do listy klientów w wypożyczalni.
- **SortujNazwiskoImie():** Sortuje listę wypożyczeń według nazwiska i imienia klienta.
- **SortujNazwiskoImieKlienta():** Sortuje listę klientów według nazwiska i imienia.
- **SortujNazwiskoImiePracownika():** Sortuje listę pracowników według nazwiska i imienia.
- **DodajPracownika(Pracownik p):** Dodaje pracownika do listy pracowników w wypożyczalni.
- **WypiszPracownikow():** Metoda ta zwraca ciąg znaków zawierający informacje o pracownikach w formie tekstowej. Jeśli lista pracowników jest pusta, zwracana jest wartość null.
- **WypiszKlientow():** Metoda ta zwraca ciąg znaków zawierający informacje o klientach w formie tekstowej. Jeśli lista klientów jest pusta, zwracana jest wartość null.
- **UsunPracownika(Pracownik p):** Metoda ta usuwa podanego pracownika z listy pracowników w wypożyczalni.
- **NoweWypozyczenie(Wypozyczenie wypo):** Metoda ta dodaje nowe wypożyczenie do listy wypożyczeń. Jeśli klient wypożyczenia nie znajduje się jeszcze na liście klientów, zostaje również dodany.
- **DodajAuto(Samochod sam):** Metoda ta dodaje nowy samochód do listy dostępnych wypożyczalni samochodów.
- **UsunAuto(Samochod sam):** Metoda ta usuwa podany samochód z listy dostępnych wypożyczalni samochodów.
- **WypiszSamochody():** Metoda ta zwraca ciąg znaków zawierający informacje o samochodach dostępnych w wypożyczalni.
- **WypiszStanKasy():** Metoda ta zwraca ciąg znaków informujący o aktualnym stanie kasy wypożyczalni.
- **ZnajdzAktualnieWypozyczoneAuta():** Metoda ta zwraca ciąg znaków zawierający informacje o aktualnie wypożyczonych samochodach. Jeśli brak takich samochodów, zwracana jest wartość null.
- **ZnajdzAktualnieWypozyczenia():** Metoda ta zwraca ciąg znaków zawierający informacje o aktualnych wypożyczeniach, zarówno dostępnych jak i niedostępnych samochodów. Jeśli brak takich wypożyczeń, zwracana jest wartość null.
- **ToString():** Metoda ta zwraca ciąg znaków zawierający informacje o wszystkich samochodach, pracownikach i wypożyczeniach w wypożyczalni. Jeśli brak danych, zwracana jest wartość null.
- **ZmienStatusSamochodu(Samochod samochod):** Metoda ta zmienia status dostępności podanego samochodu. Jeśli samochód jest dostępny, staje się niedostępny, a vice versa.
- **WypozyczSamochod(Wypozyczenie wypo):** Metoda ta obsługuje proces wypożyczania samochodu. Aktualizuje datę wypożyczenia, oznacza samochód jako niedostępny, i aktualizuje stan kasy wypożyczalni.
- **OddanieSamochodu(Wypozyczenie wypo, bool CzySprawny):** Metoda ta obsługuje proces zwrotu samochodu. Aktualizuje datę zwrotu, oznacza samochód jako dostępny, oraz aktualizuje stan kasy wypożyczalni w zależności od tego, czy samochód jest sprawny czy zepsuty.
- **JestPracownikiem(Pracownik p):** Metoda ta sprawdza, czy podany pracownik jest pracownikiem w wypożyczalni.
- **ZapiszJSON(string nazwa):** Metoda ta zapisuje dane wypożyczalni do pliku JSON o podanej nazwie.
- **OdczytJSON(string nazwa):** Metoda ta odczytuje dane wypożyczalni z pliku JSON o podanej nazwie i zwraca obiekt wypożyczalni.
- **Zapisz(string nazwaPliku):** Metoda ta zapisuje dane wypożyczalni do pliku XML o podanej nazwie.
- **Odczytaj(string nazwaPliku):** Metoda ta odczytuje dane wypożyczalni z pliku XML o podanej nazwie i zwraca obiekt wypożyczalni.
- **ZapiszDoBazy():** Metoda ta zapisuje dane wypożyczalni do bazy danych.
- **OdczytBazyDanych():** Metoda ta odczytuje dane wypożyczalni z bazy danych.

## Właściwości Dodatkowe

- **WypozyczalniaId (int):** Unikalny identyfikator wypożyczalni.
- **Pracownik (List<Pracownik>):** Właściwość reprezentująca powiązaną listę pracowników.
- **Klient (List<Klient>):** Właściwość reprezentująca powiązaną listę klientów.
- **Samochod (List<Samochod>):** Właściwość reprezentująca powiązaną listę samochodów.
- **Wypozyczenie (List<Wypozyczenie>):** Właściwość reprezentująca powiązaną listę wypożyczeń.

## Uwagi

- Klasa implementuje interfejs `IWypozyczanie`, co oznacza, że musi zawierać metody zdefiniowane w tym interfejsie.
- Konstruktory inicjalizują listy na puste listy, a kasę na 0.


## WypozyczalniaDbContext 

Klasa `WypozyczalniaDbContext` reprezentuje kontekst bazy danych dla wypożyczalni. Dziedziczy po klasie `DbContext` z Entity Framework.

### Właściwości

- **Klienci:** DbSet przechowujący dane klientów w bazie danych.
- **Pracownicy:** DbSet przechowujący dane pracowników w bazie danych.
- **Wypozyczenia:** DbSet przechowujący dane wypożyczeń w bazie danych.
- **Wypozyczalnie:** DbSet przechowujący dane wypożyczalni w bazie danych.
- **Samochody:** DbSet przechowujący dane samochodów w bazie danych.

### Użycie

Klasa `WypozyczalniaDbContext` służy do definiowania struktury bazy danych oraz umożliwia interakcję z bazą danych w kontekście wypożyczalni.


## Klasa Wypozyczenie


Klasa `Wypozyczenie` reprezentuje pojedyncze wypożyczenie samochodu w systemie wypożyczalni. 
Implementuje interfejs `ICloneable` dla możliwości klonowania obiektu.

### Właściwości

- **NrWypozyczenia:** Statyczna właściwość przechowująca numer wypożyczenia.
- **DataWypozyczenia:** Data rozpoczęcia wypożyczenia.
- **DataZwrotu:** Planowana data zwrotu samochodu.
- **Samochod:** Obiekt reprezentujący wypożyczony samochód.
- **Klient:** Obiekt reprezentujący klienta dokonującego wypożyczenia.
- **CenaZaDzienWypozyczenia:** Cena za dzień wypożyczenia samochodu.
- **Kaucja:** Kwota kaucji za wypożyczenie.
- **Pracownik:** Obiekt reprezentujący pracownika obsługującego wypożyczenie.
- **AktualnyNumer:** Numer bieżącego wypożyczenia.
- **WypozyczenieId:** Identyfikator wypożyczenia (klucz główny).
- **WypozyczalniaId:** Identyfikator wypożyczalni (klucz obcy).
- **Wypozyczalnia:** Obiekt reprezentujący wypożyczalnię, do której przypisane jest wypożyczenie.

### Metody

- **Kwota():** Oblicza całkowitą kwotę do zapłaty za wypożyczenie.
- **PrzedluzWypozyczenie(int liczbaDni):** Przedłuża planowany czas zwrotu o zadaną liczbę dni (obsługuje również błędy)
- **Clone():** Tworzy kopię obiektu wypożyczenia.

## Klasy błędów:

Stworzone zostały również klasy błędów - obsługujące niepoprawny format numeru telefonu, peselu, numeru dowodu osobistego,
a także obsługujące błędy związane z datą zwrotu lub liczbą dni przedłużenia wypożyczenia.


# GUI

## Klasa MainWindow (GUI)

Klasa MainWindow odpowiada za główne okno interfejsu graficznego użytkownika (GUI) programu. 
Pozwala na nawigację między różnymi widokami oraz interakcję z funkcjonalnościami programu.

### Konstruktory

- **MainWindow():** Konstruktor domyślny, inicjalizuje instancję klasy, wywołuje metodę InitializeComponent() oraz odtwarza dźwięk z pliku "Muzyka.wav".

### Metody

- **ZapisPracownika(Pracownik pracownik):** Metoda statyczna do zapisu informacji o pracowniku do pliku XML.

### Zdarzenia

- **BtnPracownicy_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Pracownicy". Otwiera nowe okno PracownicyWindow i zamyka bieżące okno.

- **BtnKlienci_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Klienci". Otwiera nowe okno KlienciWindow i zamyka bieżące okno.

- **BtnSamochody_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Samochody". Otwiera nowe okno SamochodyWindow i zamyka bieżące okno.

- **MenuZapisz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Zapisz". Wyświetla okno dialogowe do wyboru lokalizacji i nazwy pliku, a następnie zapisuje dane wypożyczalni do pliku XML.

- **MenuOtworz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Otwórz". Wyświetla okno dialogowe do wyboru pliku XML, wczytuje dane wypożyczalni z pliku i aktualizuje informacje na ekranie.

- **MenuZakoncz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Zakończ". Zamyka główne okno programu.

- **BtnWypozyczenia_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Wypożyczenia". Otwiera nowe okno WypozyczeniaWindow i zamyka bieżące okno.

- **PokażStanKasy_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Pokaż Stan Kasy". Wywołuje metodę WypiszStanKasy() i aktualizuje TextBlock z wyświetlonym stanem kasy.

### Wyjątki

- **ZapisPracownikaException:** Wyjątek rzucany w przypadku problemów z zapisem informacji o pracowniku.

### Uwagi

- Klasa korzysta z atrybutu [DataContract] do oznaczenia, że może być serializowana.


## Pracownicy Window


Klasa PracownicyWindow jest odpowiedzialna za okno interfejsu graficznego użytkownika (GUI), które umożliwia zarządzanie pracownikami w systemie wypożyczalni.

### Konstruktory

- **PracownicyWindow():** Konstruktor domyślny, inicjalizuje instancję klasy i wywołuje metodę InitializeComponent().

### Metody

- **MenuZapisz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Zapisz". Zapisuje dane wypożyczalni do pliku XML, wcześniej wybierając lokalizację i nazwę pliku.

- **MenuOtworz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Otwórz". Wczytuje dane wypożyczalni z pliku XML, wcześniej umożliwiając wybór pliku.

- **MenuZakoncz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Zakończ". Zamyka okno PracownicyWindow.

- **BtnDodaj_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Dodaj". Otwiera nowe okno DodajPracownikaWindow, pozwalając użytkownikowi dodać nowego pracownika.

- **BtnUsun_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Usuń". Usuwa zaznaczonego pracownika z listy pracowników.

- **BtnSortuj_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Sortuj". Sortuje listę pracowników według nazwiska i imienia.

- **BtnCofnij_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Cofnij". Otwiera główne okno MainWindow i zamyka okno PracownicyWindow.

- **LstPracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e):** Obsługuje zmianę zaznaczenia w liście pracowników.

- **BtnUrlop_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Urlop". Ustawia pracownika na urlopie, zmieniając jego dostępność.

- **BtnPraca_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Praca". Ustawia pracownika jako dostępnego do pracy, zmieniając jego dostępność.

### Pola

- **wypozyczalnia (Wypozyczalnia):** Pole przechowujące instancję klasy Wypozyczalnia.

- **filename (string):** Pole przechowujące nazwę pliku XML.

### Uwagi

- Klasa korzysta z atrybutu [DataContract] do oznaczenia, że może być serializowana.


## DodajPracownikaWindow 

Klasa DodajPracownikaWindow odpowiada za okno interfejsu graficznego użytkownika (GUI), które umożliwia dodawanie nowego pracownika do systemu wypożyczalni.

### Właściwości

- **pracownik (Pracownik):** Instancja klasy Pracownik, reprezentująca pracownika, którego dodajemy.

- **zapiszPracownika (ZapisPracownikaDelegate):** Delegat do zapisywania danych pracownika.

### Konstruktory

- **DodajPracownikaWindow():** Konstruktor domyślny, inicjalizuje instancję klasy.

- **DodajPracownikaWindow(Pracownik pracownik):** Konstruktor przyjmujący obiekt Pracownik. Wywołuje konstruktor domyślny i ustawia pracownika, na którym będą dokonywane zmiany.

### Metody

- **BtnOk_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "OK". Sprawdza, czy wszystkie wymagane pola są wypełnione poprawnie, a następnie aktualizuje dane pracownika. Ustawia zmienną `zapiszPracownika` na delegata zapisującego pracownika z klasy MainWindow.

- **BtnCancel_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Anuluj". Zamyka okno DodajPracownikaWindow.

### Uwagi

- Klasa korzysta z atrybutu [DataContract] do oznaczenia, że może być serializowana.


## Klienci Window

## Klasa KlienciWindow (GUI)

Klasa KlienciWindow odpowiada za okno interfejsu graficznego użytkownika (GUI), które umożliwia zarządzanie klientami w systemie wypożyczalni.

### Właściwości

- **wypozyczalnia (Wypozyczalnia):** Instancja klasy Wypozyczalnia przechowująca dane systemu wypożyczalni.

- **K (Klient):** Właściwość przechowująca klienta.

### Konstruktory

- **KlienciWindow():** Konstruktor domyślny, inicjalizuje instancję klasy.

### Metody

- **BtnDodaj_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Dodaj". Otwiera nowe okno DodajKlientaWindow, umożliwiając dodanie nowego klienta do systemu.

- **BtnUsun_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Usuń". Usuwa zaznaczonego klienta z listy klientów.

- **BtnSortuj_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Sortuj". Sortuje listę klientów według nazwiska i imienia.

- **BtnCofnij_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Cofnij". Otwiera główne okno MainWindow i zamyka okno KlienciWindow.

- **LstKlienci_SelectionChanged(object sender, SelectionChangedEventArgs e):** Obsługuje zmianę zaznaczenia w liście klientów.

- **MenuZapisz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Zapisz". Zapisuje dane wypożyczalni do pliku XML, wcześniej umożliwiając wybór lokalizacji i nazwy pliku.

- **MenuOtworz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Otwórz". Wczytuje dane wypożyczalni z pliku XML, wcześniej pozwalając wybrać plik.

- **MenuZakoncz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Zakończ". Zamyka okno KlienciWindow.

### Uwagi

- Klasa korzysta z atrybutu [DataContract] do oznaczenia, że może być serializowana.



## SamochodyWindow



Klasa SamochodyWindow odpowiada za okno interfejsu graficznego użytkownika (GUI), które umożliwia zarządzanie samochodami w systemie wypożyczalni.

### Właściwości

- **wypozyczalnia (Wypozyczalnia):** Instancja klasy Wypozyczalnia przechowująca dane systemu wypożyczalni.

- **filename (string):** Zmienna przechowująca nazwę pliku.

### Konstruktory

- **SamochodyWindow():** Konstruktor domyślny, inicjalizuje instancję klasy.

### Metody

- **MenuOtworz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Otwórz". Wczytuje dane wypożyczalni z pliku XML, wcześniej pozwalając wybrać plik.

- **MenuZapisz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Zapisz". Zapisuje dane wypożyczalni do pliku XML, wcześniej umożliwiając wybór lokalizacji i nazwy pliku.

- **MenuZakoncz_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie opcji menu "Zakończ". Zamyka okno SamochodyWindow.

- **LstPracownicy_SelectionChanged(object sender, SelectionChangedEventArgs e):** Obsługuje zmianę zaznaczenia w liście pracowników.

- **BtnCofnij_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Cofnij". Otwiera główne okno MainWindow i zamyka okno SamochodyWindow.

- **BtnKlasyczny_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Samochód Klasyczny". Otwiera okno DodajSamochodKlasycznyWindow, umożliwiając dodanie samochodu klasycznego do systemu.

- **BtnSportowy_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Samochód Sportowy". Otwiera okno DodajSamochodSportowyWindow, umożliwiając dodanie samochodu sportowego do systemu.

- **BtnWieloosobowy_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Samochód Wieloosobowy". Otwiera okno DodajSamochodWieloosobowyWindow, umożliwiając dodanie samochodu wieloosobowego do systemu.

- **BtnCabriolet_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Samochód Cabriolet". Otwiera okno DodajSamochodCabrioletWindow, umożliwiając dodanie samochodu cabriolet do systemu.

- **BtnWypozyczoneAuta_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Wypozyczone Auta". Wyświetla aktualnie wypożyczone samochody w MessageBox.

- **BtnUsun_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Usuń". Usuwa zaznaczony samochód z listy samochodów.

### Uwagi

- Klasa korzysta z atrybutu [DataContract] do oznaczenia, że może być serializowana.


## Okna dodawania samochodów

## DodajSamochodCabrioletWindow

Klasa DodajSamochodCabrioletWindow odpowiada za okno interfejsu graficznego użytkownika (GUI), które umożliwia dodawanie nowego samochodu cabriolet do systemu wypożyczalni.

### Właściwości

- **samochod (SamochodCabriolet):** Instancja klasy SamochodCabriolet, reprezentująca dodawany samochód cabriolet.

### Konstruktory

- **DodajSamochodCabrioletWindow():** Konstruktor domyślny, inicjalizuje instancję klasy.

- **DodajSamochodCabrioletWindow(SamochodCabriolet samochod):** Konstruktor przyjmujący obiekt SamochodCabriolet. Wywołuje konstruktor domyślny i ustawia samochód, na którym będą dokonywane zmiany.

### Metody

- **BtnOk_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "OK". Sprawdza, czy wszystkie wymagane pola są wypełnione poprawnie, a następnie aktualizuje dane samochodu cabriolet.

- **BtnCancel_Click(object sender, RoutedEventArgs e):** Obsługuje kliknięcie przycisku "Anuluj". Zamyka okno DodajSamochodCabrioletWindow.

### Uwagi

- Klasa korzysta z atrybutu [DataContract] do oznaczenia, że może być serializowana.


Analogicznie działają okna DodajSamochodKlasyczyWindow, DodajSamochodSportowyWindow i DodajSamochodWieloosobowyWindow


## WypozyczeniaWindow 

Klasa WypozyczeniaWindow odpowiada za okno interfejsu graficznego użytkownika (GUI), które umożliwia zarządzanie wypożyczeniami w systemie wypożyczalni.

### Właściwości

- **wypozyczalnia (Wypozyczalnia):** Obiekt klasy Wypozyczalnia, przechowujący dane systemu wypożyczalni.

- **filename (string):** Przechowuje ścieżkę do pliku z danymi wypożyczeń.

- **aktualneWypozyczenia (List<Wypozyczenie>):** Lista aktualnych wypożyczeń w systemie.

### Konstruktory

- **WypozyczeniaWindow():** Konstruktor domyślny, inicjalizuje instancję klasy.

### Metody

- **MenuOtworz_Click(object sender, RoutedEventArgs e):** Obsługuje zdarzenie otwarcia pliku. Umożliwia wybór pliku i wczytanie danych wypożyczeń.

- **MenuZapisz_Click(object sender, RoutedEventArgs e):** Obsługuje zdarzenie zapisu danych do pliku. Pozwala na wybór lub podanie nazwy pliku i zapisuje aktualne dane wypożyczeń.

- **MenuZakoncz_Click(object sender, RoutedEventArgs e):** Obsługuje zdarzenie zamknięcia okna.

- **LstWypozyczenia_SelectionChanged(object sender, SelectionChangedEventArgs e):** Obsługuje zmianę zaznaczenia na liście wypożyczeń.

- **BtnCofnij_Click(object sender, RoutedEventArgs e):** Obsługuje zdarzenie cofnięcia do głównego okna.

- **BtnWypozyczSamochod_Click(object sender, RoutedEventArgs e):** Obsługuje zdarzenie wypożyczenia samochodu. Sprawdza dostępność pracownika obsługującego wypożyczenie i czy samochód jest dostępny.

- **BtnDodaj_Click(object sender, RoutedEventArgs e):** Obsługuje zdarzenie dodania nowego wypożyczenia. Tworzy nowe wypożyczenie i dodaje je do systemu.

- **BtnAktualneWypozyczenia_Click(object sender, RoutedEventArgs e):** Obsługuje zdarzenie wyświetlenia aktualnych wypożyczeń.

- **BtnZwrocSamochod_Click(object sender, RoutedEventArgs e):** Obsługuje zdarzenie zwrotu samochodu. Sprawdza dostępność samochodu, a następnie oddaje samochód i aktualizuje listę wypożyczeń.

- **AktualizujListeWypozyczen():** Metoda prywatna, aktualizuje listę wypożyczeń na podstawie danych wypożyczalni.

- **BtnPelnaListaWypozyczen_Click(object sender, RoutedEventArgs e):** Obsługuje zdarzenie wyświetlenia pełnej listy wypożyczeń.

### Uwagi

- Okno umożliwia otwieranie, zapisywanie, przeglądanie i zarządzanie wypożyczeniami w systemie.
- Dostarcza funkcje takie jak dodawanie nowych wypożyczeń, wypożyczanie i zwracanie samochodów, oraz wyświetlanie pełnej listy wypożyczeń.
- Posiada obsługę błędów i komunikatów informacyjnych w przypadku nieprawidłowych działań użytkownika.

## WypozyczenieWindow Obsługa Błędów

W klasie WypozyczeniaWindow, obsługa błędów została uwzględniona w kilku miejscach, aby zapewnić poprawne i bezpieczne funkcjonowanie interfejsu użytkownika.

### 1. Weryfikacja poprawności pliku przy otwieraniu

W metodzie `MenuOtworz_Click` następuje otwieranie pliku z danymi wypożyczeń. Przed próbą wczytania pliku, sprawdzana jest poprawność rozszerzenia pliku oraz czy plik istnieje. W przypadku, gdy plik nie spełnia tych warunków, użytkownik otrzymuje odpowiedni komunikat o błędzie.

```csharp
if (result == true)
{
    string filename = dlg.FileName;
    if (System.IO.Path.GetExtension(filename) == ".xml" && System.IO.File.Exists(filename))
    {
        wypozyczalnia = Wypozyczalnia.Odczytaj(filename);
        if (wypozyczalnia is not null)
        {
            LstWypozyczenia.ItemsSource = new ObservableCollection<Wypozyczenie>(wypozyczalnia.Wypozyczenia);
        }
    }
    else
    {
        MessageBox.Show("Wybrano nieprawidłowy plik lub plik nie istnieje.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
```

## 2. Zabezpieczenie przed oddaniem już zwróconego samochodu

W metodzie `BtnZwrocSamochod_Click`, przed próbą oddania samochodu, sprawdzane jest, czy samochód nie został już oddany. W przypadku próby zwrotu już zwróconego samochodu, użytkownik otrzymuje odpowiedni komunikat o błędzie.

```csharp
if (wybraneWypozyczenie.Samochod.CzyDostepny == false)
{
    // Wywołaj funkcję oddania samochodu
    wypozyczalnia.OddanieSamochodu(wybraneWypozyczenie, true);

    // Zaktualizuj widok listy wypożyczeń
    AktualizujListeWypozyczen();
    // Wywołaj metodę obliczającą kwotę
    decimal kwota = wybraneWypozyczenie.Kwota();

    
    MessageBox.Show($"Kwota do zapłacenia: {kwota:C}");
}
else
{
    MessageBox.Show("Ten samochód został już oddany.", "Informacja");
}
```

W różnych miejscach, takich jak BtnWypozyczSamochod_Click czy BtnZwrocSamochod_Click, przed wykonaniem operacji na wypożyczeniu, sprawdzane jest, czy użytkownik wybrał konkretne wypożyczenie. 
Jeśli nie, użytkownik otrzymuje komunikat o błędzie.


W metodzie BtnDodaj_Click, przed dodaniem nowego wypożyczenia, sprawdzane są warunki poprawności danych wprowadzonych przez użytkownika. W przypadku nieprawidłowych danych, użytkownik otrzymuje komunikat o błędzie.

# DodajWypozyczenieWindow

### Opis Klasy
`DodajWypozyczenieWindow` to klasa obsługująca interakcję z oknem dodawania nowego wypożyczenia. Pozwala użytkownikowi wprowadzić informacje dotyczące wypożyczenia, takie jak data wypożyczenia, data zwrotu, wybór klienta, pracownika, samochodu oraz cena za dzień wypożyczenia. Dodatkowo, klasa umożliwia zabezpieczenie przed dodaniem wypożyczenia, gdy pracownik obsługujący wypożyczenie jest niedostępny.

### Atrybuty
- `private string filename;`: Przechowuje ścieżkę do pliku.
- `Wypozyczenie wypozyczenie;`: Przechowuje dane nowego wypożyczenia.
- `public static Wypozyczalnia wypozyczalnia = new Wypozyczalnia();`: Utworzony statyczny obiekt `Wypozyczalnia` dla operacji na danych wypożyczenia.

### Metody

#### `public DodajWypozyczenieWindow()`
Konstruktor klasy. Inicjalizuje okno i ustawia źródła danych dla ComboBox z klientami, pracownikami i samochodami.

#### `private void BtnOk_Click(object sender, RoutedEventArgs e)`
Obsługuje zdarzenie naciśnięcia przycisku "OK". Sprawdza poprawność wprowadzonych danych, tworzy nowe wypożyczenie i dodaje je do listy. Wyświetla odpowiednie komunikaty w przypadku błędów.

#### `private void BtnCancel_Click(object sender, RoutedEventArgs e)`
Obsługuje zdarzenie naciśnięcia przycisku "Anuluj". Zamyka okno bez dokonywania zmian.


## KwotaDoZaplatyWindow

Okno wyświetla informacje o kwocie do zapłaty.



