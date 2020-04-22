# KlauterGame

## Team info

Team #1
  1. [Stanley Dam](https://github.com/Stanley-Dam)
  2. [Tim Bouwman](https://github.com/TimBouwman)

## Het concept

Sinds wij beiden game ontwikkelaren zijn wilden wij graag een game maken voor dit project. Wij kwamen na enig prakkiseren uit op een leuk innovatief spel concept die wij hier kort en bondig samen zullen vatten.
Als input voor dit spel gebruiken wij een camera om mensen voorledig te tracken. En als output hebben wij een beamer die het spel op een muur projecteert. Deze muur is ongelijkvormig, er steken polygonen uit. De spelers kunnen hier als een stickman op klimmen, de speler die als eerste boven aan de muur is heeft gewonnen.
![Game concept](http://maclout.com/klautergame/gameconcept/Game_Concept.png)

_Een visueele representatie van ons concept._

## Obstakels

Om dit project te realiseren hebben wij een kleine lijst met obstakels te overwinnen. Hier
hebben wij een kleine opsomming gemaakt zodat, wanneer wij daadwerkelijk research gaan
doen naar libraries die wij kunnen gebruiken, gemakkelijk alle punten af kunnen gaan.
Als eerste obstakel hebben wij een 3D render en een physics engine nodig. We zullen dus een
goede game engine moeten zien te vinden die aan beide eisen voldoet.
Vervolgens lopen wij tegen het probleem aan dat wij een map nodig zullen hebben waar
spelers op kunnen klimmen, hiervoor zullen wij dus een manier moeten zien te vinden de
“echte wereld map” om te zetten naar een map in de game.
Spelers zullen natuurlijk ook daadwerkelijk de muur op moeten kunnen klimmen. Hiervoor
moeten wij hun volledige lichaam zien te tracken. Vervolgens hebben wij een digitaal skelet
nodig die wij kunnen gebruiken voor ons speler poppetje.
Nadat wij de speler zijn input binnen hebben moeten wij deze data om zien te zetten naar een
in-game karakter die kan klimmen en vallen.

## Vergelijking van libraries & tools

### Input

Voor de user input wouden wij in het begin [tensorflow posenet](https://github.com/tensorflow/tfjs-models/tree/master/posenet) gebruiken maar toen wij onderzoek aan het doen waren naar hoe wij posenet het beste in unity konden krijgen vonden wij de [ThreeDPoseUnityBarracuda](https://github.com/digital-standard/ThreeDPoseUnityBarracuda) van digital-standard op github. in deze repository stond een unity project die met een klein beetje setup meteen in unity3D scene werkte. Dat maakte ons werk uiteraard een heel stuk makkelijker en daarom hebben wij daarvoor gekozen. het enige wat wij nog moeten doen is de beweging omzetten naar physics.

![ThreeDPoseUnityBarracuda](https://github.com/digital-standard/ThreeDPoseUnityBarracuda/blob/master/Assets/StreamingAssets/ScreenShots/unity_wiper_too_big.PNG)
_Een ThreeDPoseUnityBarracuda in werking._

### Output

In eerste instantie wilde wij de map met de hand maken door blokken binnen de game engine te verplaatsen tot ze gelijk staan aan hun corresponderende tevens reële duplicaat. Wij zijn later echter op het idee gekomen dit proces te automatiseren.
Hier introduceren wij het [QR => 3DMap systeem](https://github.com/Stanley-Dam/QRToMapUnity)! Een systeem die simpele QR-codes in een image omzet naar 3D vectoren. Op basis van deze vectoren kunnen wij vervolgens een zogenaamde “noise map”. Deze map kunnen wij vervolgens overzetten op een plane object binnen de game engine die wij gebruiken.
Door deze speciale QR-codes op de muur te plakken kunnen wij dus gemakkelijk een map laten genereren, deze map kunnen we vervolgens als speelveld gebruiken voor de “active ragdolls” om op te klimmen. Wanneer wij deze vervolgens projecteren op de muur hebben wij dus gelijk een map die er exact op past. 

![Game concept](http://maclout.com/klautergame/gameconcept/QRToMap.png)

_QR => 3DMap Systeem door Stanley Dam_

## Scrum

Tijdens dit project hebben wij ons aan de scrum methode gehouden, hiervoor hebben wij deze github repo gebruikt en onze trello pagina.
We hebben ook een logboek bijgehouden.
 * [Github](https://github.com/TimBouwman/KlauterGame)
 * [Trello](https://trello.com/b/3TJg7tu1/klauter-game)
 * [Logboek](https://drive.google.com/file/d/14VioDuYl6Uj4FIM25CZNXeuKN10XYHg6/view?usp=sharing)

## Portfolio

Dit zijn links naar onze documentatie:

 * [Bronnenlijst](https://docs.google.com/document/d/1UM-okvRDE-k7mv25ZLIc7dJOAEY0Idz9P0P2i9AQrsc/edit?usp=sharing)
 * [Logboek](https://drive.google.com/file/d/14VioDuYl6Uj4FIM25CZNXeuKN10XYHg6/view?usp=sharing)
 * [Test plan](https://docs.google.com/document/d/1aE_iQHHHYf8DPlLhrkjpY4dOlStucb_iAi5EafhHoTI/edit?usp=sharing)
 * [Game in werking en test resultaat](https://www.youtube.com/watch?v=TkWeqh1pLaA&feature=youtu.be)
 * [Trello](https://trello.com/b/3TJg7tu1/klauter-game)
 * [Packet list](https://docs.google.com/spreadsheets/d/1sO6xQE3OJJMnTjGyyGFFbH32yej5ryA2hlKZ6-13m8c/edit?usp=sharing)
