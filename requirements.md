Examinationsuppgift programmering 2:
Sista inlämningsdag 03/06/2024 - 3e Juni 23:59 
Hej! I den här uppgiften kommer ni göra en prototyp på ett third person action game! Genre lämnas relativt fritt, ni kan sikta på en vertical slice av allt mellan 3D-fps i stil Helldivers 2 eller Resident Evil 4, Action-rpg hybrider i stil Assasins Creed, ARPG i 3D som Path of Exile eller Diablo 4 eller Spectacle fighters som God of War, Metal Gear: Rising eller DMC()
Uppgiften har 3 kategorier, E, C & A. Det som skiljer nivån på uppgifterna är inte hur svåra de är att programmera utan hur mycket instruktioner ni får i varje uppgift. 

Det går att få A & C utan att ha gjort alla uppgifter i alla kategorier om ni har visat betygskriterierna på nivån i resten av kursen, eller om ni har lämnat egna spel eller projekt på fritiden där ni visar dem, så stressa inte upp er för mycket om ni inte hinner allt. 
Inlämning sker i ett github-arkiv med en länk, precis som tidigare. Säg till mig om ni har problem. 


E:
I kategori E kommer jag att skriva ut detaljerade instruktioner steg för steg när jag går igenom uppgiften imorgon, det enda ni inte får en exakt instruktion på är hur koden ska se ut. 

E1 
Skapa en 3D-Character Controller som kan röra sig i alla riktningar, hoppa och falla. Ge den kontroller som passar den typen av spel du vill bygga. 
Använd inte unity’s inbyggda Character-Controller-Component.  

E2
Skapa en melee-attack som har en tydlig grafisk effekt och en fungerande hitbox samt partiklar som genereras när man slår. Lägg till en debug-input som visar hitboxen för attacken tydligt(Genom att tex. aktivera en kub som visar hitbox eller motsvarande när man slår). Skapa ett scriptable-object som tillhör vapnet där du kan fylla i värden(skada osv. som rör vapnet i fråga) och är dem som vapnet läser från. 

E3
Skapa en avståndsattack som använder en raycast på något sätt. Hitscan machine gun, en missil som du siktar via en raycast, en eldboll som på något sätt använder en raycast, du får bestämma själv vad som passar din spelide. Skapa ett scriptable-object som tillhör vapnet där du kan fylla i värden(skada osv. som rör vapnet i fråga) och är dem som vapnet läser från. 

E4
Skapa en avståndsattack som skjuter iväg en missil av något slag, en eldboll eller något annat som använder sig av collisions och inte raycasts för att fungera, flyttar sig frammåt i världen och sedan exploderar på något sätt när den slår i något. Skapa ett scriptable-object som tillhör vapnet där du kan fylla i värden(skada osv. som rör vapnet i fråga) och är dem som vapnet läser från.
E5
Skapa en scen med en meny där spelaren kan starta spelet och gå till en optionsmeny. På optionsmenyn kan spelaren ändra minst en kontrollinställning med hjälp av ett scriptable object(vilka knappar som gör vad, eller mouse look sensitivity eller något annat)


--------------------------------
C:

C1
Skapa en training dummy som spelaren kan slå och skjuta på. Visa via en eller flera UI-canvas, antingen i världen eller i ett hörn i screenspace Screenspace, resultatet av att dummyn blir träffad, samt lägg till partiklar eller någon annan effekt eller animation som tydligt visar att dummyn har blivit träffad och var den har blivit träffad. 

C2
Ge Spelaren en ground melee combo med minst 3 olika attacker. Combo innebär att attack nr 2 kommer ut om du klickar attack igen inom ett visst tidsfönster efter att den första attacken har använts. 
Ge även spelaren en Melee combo i luften. Spelaren slutar falla eller faller långsammare under tiden hen slår i luften.

C3 
Gör en fiende som går fram och tillbaka och ibland skjuter en långsam projektil mot där spelaren står just nu. Fienden går att slå eller skjuta ihjäl, och det går att spawna en ny genom någon typ av debug input. 

C4
Använd arv för att skapa flera varianter minst av ett av vapnen som ni implementerat i E-uppgifterna; ett av vapnen kanske slår långsammare eller snabbare, har andra partiklar, har en extra comboattack? 
Vad skillnaden är är inte lika viktigt som att det finns en tydlig skillnad och att ni använder arv och polymorfism för att implementera den.
--------------------------------
A:

A1
Implementera ännu en fiende med ett helt annorlunda beteende(attackmönster, skada, rörelse osv). Ni sätter själva parametrarna för hur den ska fungera. 

A2 
Gör en level av spelet som går att spela från början till slut, med minst 2 combat encounters(två utrymmen som är distinkt annorlunda från varandra där spelaren slåss mot minst en fiende gärna fler). Level ska ha ett mål som leder till en victory-Scene, gå att pausa och ha en dödsmeny där spelaren kan välja att starta om. 

A3 
Lägg ljud och soundtrack samt möjlighet att ändra upplösning, windowed/fullscreen mode och volym på sfx och soundtrack separat i optionsmenyn från uppgift E5. 

A4 (Bonus, flera gånger?)
Lägg till en helt egen feature av något slag, som inte är något som nämns i en annan uppgift.  
