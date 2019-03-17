# FizzBuzz Adam Bajguz



# Zadanie FizzBuzz - część 1

Zrealizuj jeden z podanych wariantów aplikacji webowej FizzBuzz.


# Wariant 1 (web)

Gdy użytkownik wchodzi na stronę główną widzi formularz do wpisania liczby oraz przycisk 'Odpowiedz'.

Po wpisaniu liczby i wciśnięciu 'Odpowiedz' użytkownik otrzymuje odpowiedź:
- 'fizz' jeśli dana liczba jest podzielna przez 3
- 'buzz' jeśli liczba jest podzielną przez 5
- 'fizzbuzz' jeśli liczba jest podzielna przez 3 i 5
- wpisaną liczbę w pozostałych przypadkach


## Wymagania:

- Obliczenie powinno odbywać się po stronie serwera.
- Zapytanie do serwera powinno zostać zrealizowane za pomocą metody POST.
- Dozwolone są jedynie liczby całkowite z zakresu <1,100>.
- Aplikacja powinna wyświetlić odpowiedni komunikat w przypadku nieprawidłowych danych.
- Rozwiązanie umieść w repozytorium kodu i udostępnij prowadzącemu do odczytu (istolarska)


# Wariant 2 (API)

Przygotuj endpoint przyjmujący zapytanie wysyłane metodą POST w formacie JSON:

```json
{
     „number”: <int>
}
```


W przypadku przesłania prawidłowych danych endpoint API powinien zwrócić status odpowiedzi HTTP 200 OK z zawartością w formacie JSON:

```json
{
    'answer': <string>
}, gdzie::


answer - odpowiedź serwera przyjmująca wartości:
- 'fizz' jeśli dana liczba jest podzielna przez 3
- 'buzz' jeśli liczba jest podzielną przez 5
- 'fizzbuzz' jeśli liczba jest podzielna przez 3 i 5
- wysłaną liczbę w pozostałych przypadkach
```

## Wymagania:

Dozwolone są jedynie liczby całkowite z zakresu <1,100>.  
W przypadku nieprawidłowych danych, endpoint API powinienzwrócić status HTTP 400 Bad Request z zwartością w formacie JSON:

```json
{
   'error': <string>
}, gdzie:

error - szczegóły błędu
```

Rozwiązanie umieść w repozytorium kodu i udostępnij prowadzącemu do odczytu (istolarska)

# Punktacja i zasady
Projekt rozgrzewka jest realizowany przez pierwsze dwa zajęcia.

Celem projektu jest poznanie systemu kontroli wersji Git oraz środowiska pracy dla projektów WWW realizowanych w technologii .NET.

Projekt jest realizowany w dwóch etapach. 

Kod powinien być realizowany na zewnętrznym systemie kontroli wersji  (projekt prywatny na dev.azure.com/gitlab.com/bitbucket.org) i udostępniony prowadzącemu do odczytu.

Ostateczna wersja projektu powinna zostać opublikowana w systemie CEZ.

**Szczegóły punktacji (6 punktów):**
* realizacja logiki z zajęć nr 1- 1.5pkt
* obsługa błędów - 1pkt
* realizacja modyfikacji z zajęć nr 2 - 1.5pkt
* użycie git-a - 2pkt (1 pkt za systematyczne dodanie zmian z każdych zajęć)
* *Punkty nie zostaną przyznane w przypadku stwierdzenia braku samodzielności w realizacji projektu.*
* *W przypadku opóźnienia w realizacji zadania liczba punktów zmniejsza się o połowę za każdy tydzień opóźnienia.*


# Zmodyfikuj kod z poprzednich zajęć o przypadek "wizz".

Po wpisaniu liczby i wciśnięciu 'Odpowiedz' użytkownik otrzymuje odpowiedź

* "wizz" jeśli dana liczba jest podzielna przez 7
* "fizzwizz" jeśli dana liczba jest podzielna przez 3 i 7
* "buzzwizz" jeśli dana liczba jest podzielna przez 5 i 7
* "fizzbuzzwizz" jeśli dana liczba jest podzielna przez 3, 5 i 7
Zrealizuj podane zadanie w sposób umożliwiający prostą rozbudowę programu o kolejne przypadki.

Każde wyszukiwanie oraz odpowiedź serwera powinna być rejestrowane w bazie danych wraz z IP, z którego zostało wysłane zapytanie.

(Podpowiedź: użyj HTTP_X_FORWARDED_FOR  i REMOTE_ADDR zapisanych w obiekcie Request).

W projekcie umieść plik README z imieniem i nazwiskiem autora rozwiązania oraz linkiem do repozytorium.

Rozwiązanie umieść w repozytorium kodu i udostępnij prowadzącemu do odczytu (istolarska).

Rozwiązanie umieść w systemie CEZ.