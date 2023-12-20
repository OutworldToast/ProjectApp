CODE CONVENTIES:

Check elke week of we dit nog aan willen houden tijdens retrospective maandag

TAAL: nederlands

VARIABELE/METHODE NAAMGEVING:

Alle namen zijn beschrijvend
Methodes zijn van vorm Werkwoord{Znmw} 
Testen zijn van vorm:
{klasse}Test
{methode}[{parameters}]{resultaat}Test -> bijv HaalContextSlaagTest
Attributen: CamelCase beginnend met hoofdletter
Methodes: CamelCase beginnend met hoofdletter
Paramaters: CamelCase beginnend met kleine letter

METHODES SCHRIJVEN:

Geef zoveel mogelijk return waardes -> testbaar
Throw Exceptions voor errors
Maak meteen testen aan bij methodes

TESTEN SCHRIJVEN:

Hou //arrange //act //assert aan
Bewaar resultaat in een variable Result


=============================================================
GIT:

MAIN BRANCHES:

Master wordt alleen bij grote versies gemergd
Production wordt alleen bij stabiele versies gemergd ()
Development wordt alleen met complete features gemergd

FEATURE BRANCHES:

Maak feature branches vanaf Development
Fetch + pull altijd voor het branchen
Gebruik beschrijvende namen ->> MaakPersoonControllerBranch
Standaard werkt 1 persoon per branch

PUSH:
Push alleen features met slagende unit tests
Pull altijd voor het pushen

COMMIT:
Beschrijvend maar beknopte Commit


