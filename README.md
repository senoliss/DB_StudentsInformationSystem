# DB_StudentsInformationSystem

This application is built on .NET SDK 7 64x bit architecture



DB tarpinis atsiskaitymas
Due November 24, 2023 3:00 PM

Instructions
Studentų informacinė sistema:

Entities:
1. Departamentas. Turi: Daug studentų, daug paskaitų.
2. Paskaita. Turi: Daug departamentų.
3. Studentas. Turi: Daug paskaitų, vieną departamentą.

Funkcionalumai:
1. Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points jei pridedamos paskaitos jau egzistuojančios duomenų bazėje).
2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.
3. Sukurti paskaitą ir ją priskirti prie departamento.
4. Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias paskaitas.
5. Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos).
6. Atvaizduoti visus departamento studentus.
7. Atvaizduoti visas departamento paskaitas.
8. Atvaizduoti visas paskaitas pagal studentą.

Nepamirškite padaryti įvedamų duomenų Validacija.  Pvz:
-Studento vardas ir pavardė: tik raidės, 2-50 simbolių.
-Studento numeris: unikalus, tik skaičiai. Tiksliai 8 simboliai.
-Studento el.paštas: turi būti teisingo formato
-Departamento pavadinimas: 3-100 simbolių, gali būti raidės ir skaičiai.
-Departamento kodas: unikalus, tik raidės ir skaičiai. Tiksliai 6 simboliai.
-Paskaitos pavadinimas: unikalus, ne mažiau nei 5 simboliai.
-Paskaitos laikas: turi atitikti realius laiko intervalus (pvz., ne prasideda 25:00 val.).
+Validacija atliekama prieš įrašant duomenis į duomenų bazę.
+Galite sukurti papildomas savo validacijas.


Vertinimas
1. Kodo Kokybė (30 taškų)
   - Aiškumas ir Skaitomumas (10 taškų): Kodas gerai organizuotas, lengvai skaitomas ir pakankamai komentuotas.
   - Laikymasis C# Kodavimo Taisyklių (10 taškų): Tinkamas kintamųjų, metodų ir pan. vardų taisyklių, sintaksės ir geriausių praktikų naudojimas.
   - Klaidų Tvarkymas (10 taškų): Tinkamas try-catch blokų naudojimas ir galimų išimčių tvarkymas.
2. Duomenų Bazės Dizainas ir Integracija (30 taškų)
   - Schemos Dizainas (10 taškų): Logiškas ir efektyvus lentelių bei ryšių dizainas.
   - Duomenų Vientisumas (10 taškų): Tinkamas pagrindinių/išorinių raktų, apribojimų ir duomenų tipų naudojimas.
   - Duomenų Bazės Prijungimas (10 taškų): Efektyvus darbas su duomenų baze, tinkamas užklausų naudojimas.
3. Funkcionalumas (30 taškų)
   - Pagrindiniai Reikalavimai (15 taškų): Visi pagrindiniai funkcionalumai (departamentų kūrimas, studentų/paskaitų pridėjimas, validacijos ir kt.) įgyvendinti ir veikia teisingai.
   - Papildomos Funkcijos (10 taškų): Papildomų funkcijų, pavyzdžiui, esamų paskaitų pridėjimo prie departamentų, studentų perkėlimo tarp departamentų su paskaitų atnaujinimu įgyvendinimas.
   - Be Klaidų Vykdymas (5 taškai): Programa veikia be užstrigimų ir tinkamai tvarko vartotojo įvestis/klaidas.
4. Vartotojo Sąsaja (10 taškų)
   - Naudojimo Paprastumas (5 taškai): Konsolės programa yra vartotojui draugiška su aiškiomis instrukcijomis ir išvestimis.
   - Navigacija (5 taškai): Logiškas perėjimas tarp skirtingų funkcionalumų, su aiškiomis vartotojui skirtomis pasirinkimo galimybėmis.
5. Papildomi Taškai (iki 10 taškų)
   - Inovacijos (5 taškai): Kūrybiškas funkcijų ar įgyvendinimo metodų naudojimas, kuris pagerina programą.
   - Dokumentacija (5 taškai): Išsami dokumentacija, vidinius komentarus ir trumpą ataskaitą, paaiškinančią dizainą ir funkcijas.

### Iš Viso: 100 taškų (plius iki 10 papildomų taškų)


Tips:

įvedamiems duomenims nepamirškite padaryti validaciju. pvz:
Duomenų Validacija:
-Studento vardas ir pavardė: tik raidės, 2-50 simbolių.
-Studento numeris: unikalus, tik skaičiai. Tiksliai 8 simboliai.
-Studento el.paštas: turi būti teisingo formato
-Departamento pavadinimas: 3-100 simbolių, gali būti raidės ir skaičiai.
-Departamento kodas: unikalus, tik raidės ir skaičiai. Tiksliai 6 simboliai.
-Paskaitos pavadinimas: unikalus, ne mažiau nei 5 simboliai.
-Paskaitos laikas: turi atitikti realius laiko intervalus (pvz., ne prasideda 25:00 val.).
-Validacija atliekama prieš įrašant duomenis į duomenų bazę.
Galite sukurti papildomas savo validacijas.

jei planuojate rašyti testus, visai logiška juos rašyti validatoriams, kad ištestuoti visas įmanomas teisingas ir neteisingas įvestis. Nepamirškite, kad įvestis gali būti 'null'





Entities:
1. Autorius. Turi: Daug knygų.
2. Kategorija. Turi: Daug knygų.
3. Knyga. Turi: Daug kategorijų, vieną autorių.
4. Knygos Kategorija. Turi: Knygos ID ir Kategorijos ID užtikrinant sąryšį 'Many to Many'


Entities:
1. Departamentas. Turi: Daug studentų, daug paskaitų.
2. Paskaita. Turi: Daug departamentų.
3. Studentas. Turi: Daug paskaitų, vieną departamentą.

