Poznámky k samplu
=================

Ide o MVC 5 aplikáciu kde som ponechal všetko z pôvodného project template a pridal funkcionalitu:

Models - folder obsahuje definície DTO-čiek s jednoduchým modelom "koľajisko" - CargoRailModel,
"nakladač so zoznamom destinácií" - LoaderModel a "nakladač pre read-only zobrazenie na display" - LoaderViewModel.

Controllers/CargoController - menežuje kolekciu koľajísk a nakladačov - číta a zapisuje do cargo.json
súboru v roote aplikácie.

Views/Cargo - Index view pre menežovanie destinácií, LoaderView - parametrizovaný ID koľajiska a nakladača predstavuje
zobrazenie na display. V LoaderView je vytvorený SignalR hub proxy, ktorého metódu onLoaderChanged volá server pri zmene

IIS aplikácia musí mať zapnutú Anonymous a Windows autentifikáciu.
