# Przychodnia

## Instalacja
### Wymagania
By móc poprawnie wyświetlać zawartość należy upewnić się że na systemie zainstalowane są te lub nowsze wersje oprogramowania
- .NET 6
- Visual studio 2022

### Proces instalacji
Po zklonowaniu repozytorium, w programie Visual Studio 2022, należy wybrać `Widok > Inne okna > Konsola meneadżera pakietów`, a wewnątrz niej wpisać następujące komendy
```
Add-Migration "PrzychodniaDB"
Update-Database
```
Dane komendy powinny zmigrować bazę danych do naszego środowiska lokalnego.
By sprawdzić czy operacja została wykonana pomyślnie należy otworzyć `Widok > SQL Server Object explorer`. W oknie które zostałoi otworzone powinna się ukazać baza danych PrzychodniaDB.

Więcej informacji na ten temat
- [Problemy z działanie .NET 6 na Visual studio 2019](https://stackoverflow.com/questions/69773547/visual-studio-2019-not-showing-net-6-framework)
- [Tutorial z migracji](https://www.youtube.com/watch?v=bZ74dirFHUA)

## Korzystanie
Aktualnie nie wiem jeszcze jak to zrobić przy pomocy IIS, ale można otworzyć projekt przy pomocy IIS Express poprzez kliknięcie przycisku F5 w Visual Studio.
Powinien ukazac nam się domyslny panel blazor App, więc taki który jeszcze nie posiada żadnych cech związacnych z przychodnią.
