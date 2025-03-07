# Quiz Applikation

## Projektbeschreibung
Die Quiz-Applikation ist eine Software, die es Benutzern ermöglicht, Fragen zu beantworten und Ergebnisse in Echtzeit anzuzeigen. Das Ziel ist es, eine intuitive und erweiterbare Plattform zu schaffen, die sowohl für einzelne Spieler als auch für zukünftige Erweiterungen genutzt werden kann.

## Teammitglieder
- **Martullo, Giuliano**
- **Innamorato, Giovanni**
- **Bischof, Gabriel**



## 1. Informieren

### 1.1 Projektziel
Die Applikation ermöglicht das Beantworten von Fragen in einem Quiz-Format. Ein Hauptfokus liegt auf der Benutzerfreundlichkeit sowie einer klar strukturierten und fehlerfreien Anwendung.

### 1.2 User Stories
| US-№ | Verbindlichkeit | Typ        | Beschreibung |
|------|----------------|------------|--------------|
| 1    | Muss          | Funktional | Als Nutzer möchte ich Fragen beantworten können, um am Quiz teilnehmen zu können. |
| 2    | Muss          | Funktional | Als Nutzer möchte ich wissen ob meine Antwort richtig oder falsch war |
| 3    | Sollte        | Funktional | Als Nutzer möchte ich eine visuelle Rückmeldung zu richtigen und falschen Antworten erhalten. |
| 4    | Sollte        | Funktional | Als Nutzer möchte ich wissen welche Antwort richtig gewesen wäre im Fall einer falschen Antwort |
| 5    | Muss          | Qualität   | Als Entwickler möchte ich ein simples Spiel Erlebnis haben. |

### 1.3 Testfälle

| TC-№ | Ausgangslage | Eingabe | Erwartete Ausgabe |
|------|-------------|---------|------------------|
| 1    | Eine Frage wird angezeigt | Nutzer wählt eine Antwort | Die Antwort wird registriert, und das Quiz geht weiter. |
| 2    | Eine Frage wurde beantwortet | Nutzer sieht Ergebnis | Die Anwendung zeigt an, ob die Antwort richtig oder falsch war. |
| 3    | Eine Frage wurde beantwortet | Nutzer sieht visuelle Rückmeldung | Die Anwendung hebt richtige Antworten grün und falsche rot hervor. |
| 4    | Eine Frage wurde falsch beantwortet | Nutzer sieht korrekte Antwort | Die Anwendung zeigt die richtige Antwort an. |
| 5    | Spiel wird gestartet | Nutzer spielt das Quiz | Das Quiz läuft ohne komplexe Ablenkungen oder unnötige Interaktionen. |

## 2. Planen
| AP-№ | Frist   | Zuständig | Beschreibung |
|------|--------|-----------|--------------|
| 01   | 10.03. | Team      | Informieren über das Projekt |
| 02   | 12.03. | Martullo  | Planung des Projektablaufs |
| 03   | 15.03. | Innamorato | Implementierung der Fragenlogik |
| 04   | 17.03. | Bischof   | UI-Design und Navigation |
| 05   | 20.03. | Innamorato | Ergebnisanzeige und Statistiken |
| 06   | 22.03. | Martullo  | Integration der Fragenverwaltung (Hinzufügen, Bearbeiten, Löschen) |
| 07   | 24.03. | Bischof   | Implementierung der visuelle Rückmeldungen für richtige/falsche Antworten |
| 08   | 26.03. | Bischof      | Entwicklung des Logging-Systems |
| 09   | 28.03. | Innamorato | Fehlerhandling und Optimierung der App |
| 10   | 30.03. | Martullo      | Testen der Applikation und Fehlerbehebung |
| 11   | 02.04. | Team      | Erstellung der Projektdokumentation und Portfolio |
| 12   | 05.04. | Team      | Letzte Anpassungen und finale Abgabe |

## 3. Entscheiden
- Die Applikation wird als Einzelspieler-Version umgesetzt.
- Fragen werden fest in einer JSON-Datei gespeichert (keine externe Datenbank).
- Logging-System wird implementiert, um Fehler und Ereignisse nachzuverfolgen.

## 4. Realisieren
| AP-№ | Datum   | Zuständig  | Geplante Zeit | Tatsächliche Zeit |
|------|--------|------------|---------------|-------------------|
| 1    | 17.01.25 | Team       | 120'          |      160             |
| 2    | 17.01.25 | Martullo   | 180'          |      200             |
| 3    | 24.01.25 | Innamorato | 180'          |         170          |
| 4    | 24.01.25 | Bischof    | 240'          |        250           |
| 5    | 14.02.25 | Innamorato | 120'          |        100           |
| 6    | 14.02.25 | Martullo   | 150'          |         160          |
| 7    | 14.02.25 | Bischof    | 150'          |         150          |
| 8    | 21.02.25 | Bischof       | 200'          |       200            |
| 9    | 21.02.25 | Innamorato | 180'          |          180         |
| 10   | 28.02.25 | Martullo       | 300'          |         320          |
| 11   | 07.03.25 | Team       | 180'          |            180       |
| 12   | 07.03.25 | Team       | 120'          |        200           |

## 5. Kontrollieren
### Testprotokoll
| TC-№ | Datum   | Resultat | Tester |
|------|--------|---------|--------|
| 1    | 28.02.25 | Bestanden | Martullo |
| 2    | 28.02.25 | Bestanden | Martullo |
| 3    | 28.02.25 | Bestanden | Martullo |
| 4    | 28.02.25 | Bestanden | Martullo |

## 6. Auswerten
Das Produkt funktioniert einwandfrei. Ein Testfall hat nicht funktioniert, dies war eine bewusste Entscheidung, während des Projektes


