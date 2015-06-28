# MNN2015 FirstWinPhoneApp Simple API

Dokumentacja API - wersja 0.1

## Dostęp
Adres URL to `http://mnn.dsinf.net/2015/winphone/weather/api.php`
Przekazywanie parametrów przez HTTP GET

## Parametry
- `miasto` - obowiązkowy; string będacy nazwą miasta w Polsce (obcięcie polskich znaków jest zadaniem dostawcy danych, w celu zgodności najlepiej ich unikać)
- `cel` - obowiązkowy; jedna z wartości:
 - `temperatura` - zwraca liczbę całkowitą będącą aktulną temperaturą we wskazanym mieście
 - `obrazek` - zwraca obrazek GIF z reprezentacją bieżącego stanu pogody

## Błędy
- `target_error` jeśli parametr `cel` nie ma prawidłowej wartości
- `city_error` jeśli wyszukiwanie miasta w Polsce zakończyło się niepowodzeniem po stronie dostawcy (uwaga: czasem dla niepoprawnych miast zwracane są wyniki z losowego miejsca na świecie)

## Dostawca danych
Yahoo

## Zasady dostępu
Celem tego API jest ułatwienie prowadzenia warsztatów poprzez uproszczenie danych, które aplikacja klienca miałaby parsować. Należy używać go tylko do tworzenia aplikacji podczas Małopolskiej Nocy Naukowców 2015 oraz do samodzielnego eksperymentowania ze stworzoną aplikacją. System może zostać wyłączony bez ostrzeżenia lub zostać przełączony w tryb statyczny.

## Przykłady
`GET http://mnn.dsinf.net/2015/winphone/weather/api.php?cel=obrazek&miasto=krakow` => "23"
`GET http://mnn.dsinf.net/2015/winphone/weather/api.php?cel=temperatura&miasto=warszawa` => obrazek GIF
