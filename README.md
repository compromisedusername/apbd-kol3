![obraz](https://github.com/compromisedusername/apbd-kol3/assets/100251433/bc79de07-f9d2-411d-9efb-f6af008db17d)
1. Odczytanie danych na temat klienta i jego rezerwacji
2. Dodawanie nowej rezerwacji
Dodatkowe informacje:
1. Przygotuj końcówkę, która pozwoli nam na podstawie id klienta pobrać listę rezerwacji przypisaną do użytkownika.
2. Odpowiedź API powinna uwzględniać wszystkie dane osobowe na temat klienta wraz z listą wszystkich rezerwacji. Rezerwacje
powinny uwzględniać wszystkie dane z tabeli Reservation.
3. Lista rezerwacji powinna być posortowana malejąca po dacie DateTo rezerwacji.
1. Kolejna końcówka powinna pozwolić nam dokonać rezerwacji. Żądanie powinno uwzględniać: IdClient, DateFrom, DateTo,
IdBoatStandard, NumOfBoats.
2. Rezerwacja uwzględnia identyfikator klienta, zakres dat na który chcemy zarezerwować żaglówkę/żaglówki. Pole IdBoatStandard
określa standard łodzi jaki chcemy zarezerwować. Pole NumOfBoats określa liczbę żaglówek, które chcemy wynająć.
3. Zanim zrobimy rezerwację sprawdzamy czy klient nie ma w systemie innej aktywnej rezerwacji. Klient może mieć tylko jedną
aktywną rezerwację naraz. Aktywna rezerwacja to taka, która nie została zaakceptowana, ani odrzucona.
4. W momencie wykonywania rezerwacji powinniśmy sprawdzić czy mamy odpowiednią liczbę wolnych żaglówek.
5. Jeśli brakuje nam żaglówek w odpowiednim standardzie - możemy zarezerwować żaglówkę o wyższym standardzie.
6. Jeśli nie możemy spełnić rezerwacji - zwracamy błąd z odpowiednim opisem. Ponadto aktualizujemy w bazie danych rezerwację
z odpowiednim opisem w kolumnie CancelReason.
7. W innym wypadku zapisujemy w bazie o wypożyczonych łódkach. Ponadto obliczamy cenę realizacji rezerwacji. W trakcie
obliczeń uwzględniamy promocję, które może być przypisana do danego klienta.
8. Aktualizujemy ceną i flagę Fulfilled w tabeli rezerwacja.
9. Jako rezultat zwracamy identyfikator nowo utworzonej rezerwacji z odpowiednim kodem zwrotnym HTTP
