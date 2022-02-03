Rebonjour !  #speaker:Pioupiou #portrait:PNJ1_joy #perso:pioupiou
Alors, tu as changé d'avis ? #speaker:Pioupiou #portrait:PNJ1_neutral #perso:pioupiou
Tu veux jouer à Pierre/Feuille/Ciseaux/Lézard/Spock avec moi ?
Je te rappelle qu'il y a quelque chose à gagner !  #speaker:Pioupiou #portrait:PNJ1_joy #perso:pioupiou

+ Ok, on peut essayer. #speaker:Eli  #portrait:Player_joy
    Super ! C'est parti ! #speaker:Pioupiou #portrait:PNJ1_joy
    ->secondGameRules
+ Non, je ne veux pas jouer. #speaker:Eli  #portrait:Player_blase
    D'accord. Dommage ! #speaker:Pioupiou #portrait:PNJ1_neutral
    Reviens me voir si tu changes d'avis ! #speaker:Pioupiou #portrait:PNJ1_joy
    -> END
    
    
    == secondGameRules

Voici les règles du jeu. #speaker:Pioupiou #portrait:PNJ1_joy
Ce sont les mêmes règles qu'un Pierre/Feuille/Ciseaux classique, mais avec un minuscule ajout.
Le lézard mange le papier, empoisonne Spock, est écrasé par la pierre et est décapité par les ciseaux. #speaker:Pioupiou #portrait:PNJ1_neutral
Spock, quant à lui, vaporise la pierre, casse les ciseaux, et est désavoué par le papier.
Tu vois, c'est presque aussi simple ! #speaker:Pioupiou #portrait:PNJ1_joy
->secondgameStart

== secondgameStart
On y va ?
+ Je suis prête ! #speaker:Eli  #portrait:Player_joy
-> secondGameGame
+ Attends... Répète ? #speaker:Eli  #portrait:Player_gene
    Le lézard mange le papier, empoisonne Spock, est écrasé par la pierre et est décapité par les ciseaux.  #speaker:Pioupiou #portrait:PNJ1_neutral
    Spock vaporise la pierre, casse les ciseaux, et est désavoué par le papier.
    ->secondgameStart


== secondGameGame

A trois ! #speaker:Pioupiou #portrait:PNJ1_neutral
Un !
Deux !
Trois ! #speaker:Pioupiou #portrait:PNJ1_joy
+ Pierre ! #speaker:Eli  #portrait:Player_joy
    Spock ! #speaker:Pioupiou #portrait:PNJ1_joy
    ->secondGameLoose
+ Feuille ! #speaker:Eli  #portrait:Player_joy
    Spock ! #speaker:Pioupiou #portrait:PNJ1_joy
    ->secondGameWin
+ Ciseaux ! #speaker:Eli  #portrait:Player_joy
    Spock ! #speaker:Pioupiou #portrait:PNJ1_joy
    ->secondGameLoose
+ Lézard ! #speaker:Eli  #portrait:Player_joy
    Spock ! #speaker:Pioupiou #portrait:PNJ1_joy
    ->secondGameWin
+ Spock ! #speaker:Eli  #portrait:Player_joy
    Spock ! #speaker:Pioupiou #portrait:PNJ1_joy
    ->secondGameEgalite




== secondGameEgalite

Ah ah, on a choisi Spock tous les deux, c'est rigolo. #speaker:Pioupiou #portrait:PNJ1_neutral
Moi, je choisis toujours lui, c'est le meilleur. #speaker:Pioupiou #portrait:PNJ1_joy
... #speaker:Pioupiou #portrait:PNJ1_neutral
... #speaker:Pioupiou #portrait:PNJ1_blase
Aehm. Bref.
Il va falloir rejouer. #speaker:Pioupiou #portrait:PNJ1_neutral

+ Ok, rejouons ! #speaker:Eli  #portrait:Player_joy
    ->secondGameGame
+ Non, je n'ai plus envie de jouer, finalement. #speaker:Eli  #portrait:Player_blase
    Ah, dommage. Reviens me voir si tu changes d'avis ! #speaker:Pioupiou #portrait:PNJ1_neutral
    -> END
    
    
== secondGameWin

Bravo, tu as gagné ! #speaker:Pioupiou #portrait:PNJ1_joy
Voici quelques fraises pour te récompenser ! #newtext:2
... #speaker:Pioupiou #portrait:PNJ1_neutral
... #speaker:Pioupiou #portrait:PNJ1_blase
Comment ça, ce n'est pas la saison des fraises ?
Mais pourquoi chercher une logique à tout ça ?
Prends ces fraises et ne pose pas de questions ! #speaker:Pioupiou #portrait:PNJ1_neutral
Bon courage pour ton gâteau ! #speaker:Pioupiou #portrait:PNJ1_joy
A bientôt !
-> END


== secondGameLoose==

Dommage, tu as perdu ! #speaker:Pioupiou #portrait:PNJ1_neutral
Ce n'est pourtant pas compliqué.
Je t'assure ! #speaker:Pioupiou #portrait:PNJ1_joy
Moi, je ne m'embête jamais à réfléchir, je choisis toujours la même chose ! 
Aehm. Bref.  #speaker:Pioupiou #portrait:PNJ1_neutral
Essaye encore.
+ Okay. #speaker:Eli  #portrait:Player_joy
-> secondGameGame
+ Non merci. #speaker:Eli  #portrait:Player_blase
    Ah... Tant pis, une prochaine fois peut-être !  #speaker:Pioupiou #portrait:PNJ1_neutral
    -> END

->END