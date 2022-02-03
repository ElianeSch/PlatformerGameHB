Rebonjour !
Alors, tu as changé d'avis ?
Tu veux bien jouer à un jeu avec moi ?
Si tu gagnes, je t'offre une tablette de chocolat !

+ [Okay]
    Super ! On va jouer à Pierre/Feuille/Ciseaux ! #speaker:PNJ1 #portrait:PNJ1_joy 
    -> game
+ [Bof, je n'ai pas tellement envie de jouer] 
    Ah bon ? Dommage...
    Tu ne pourras pas passer au niveau suivant tant que tu n'auras pas essayé.
    C'est moi qui garde la porte, après tout !
    Tant pis, je garde mon chocolat, dans ce cas ! #portrait:PNJ1_neutral #newtext:1
    -> END

== game ==

J'imagine que je n'ai pas besoin de t'expliquer les règles. #speaker:PNJ1 #portrait:PNJ1_joy
Alors c'est parti !
->gameBegin
== gameBegin==
A trois ! #speaker:PNJ1 #portrait:PNJ1_neutral
Un...
Deux...
Trois !

~ temp pnj = random()
+ Pierre #speaker:Player #portrait:Player_neutral

{pnj} #speaker:PNJ1 #portrait:PNJ1_neutral 
{pnj == "Pierre":
   -> egalite
    }
{pnj == "Feuille":
    -> perdu
    }
{pnj == "Ciseaux":
-> gagne
}
->DONE
+ Feuille #speaker:Player #portrait:Player_neutral
~ pnj = random()
{pnj} #speaker:PNJ1 #portrait:PNJ1_neutral 
{pnj == "Pierre":
   -> gagne
    }
{pnj == "Feuille":
    -> egalite
    }
{pnj == "Ciseaux":
-> perdu
}
->DONE
+ Ciseaux #speaker:Player #portrait:Player_neutral
~ pnj = random()
{pnj} #speaker:PNJ1 #portrait:PNJ1_neutral 
{pnj == "Pierre":
   -> perdu
    }
{pnj == "Feuille":
    -> gagne
    }
{pnj == "Ciseaux":
-> egalite
}
->DONE


== egalite==

Oh, égalité ! #speaker:PNJ1 #portrait:PNJ1_neutral
Il va falloir rejouer.
->gameBegin

== gagne==
Bravo, tu as gagné ! #speaker:PNJ1 #portrait:PNJ1_joy #newtext:2
Voici donc ton cadeau ! Tu l'as bien mérité. 
-> secondGame

==perdu==
Dommage, tu as perdu ! #speaker:PNJ1 #portrait:PNJ1_blase
Veux-tu réessayer ? #speaker:PNJ1 #portrait:PNJ1_joy
+ Oui, c'est parti ! #speaker:Player #portrait:Player_joy
->gameBegin
+ Non, j'en ai marre. #speaker:Player #portrait:Player_blase
    Tu es sûre ? Tu ne peux pas passer au niveau suivant sans avoir réussi. #speaker:PNJ1 #portrait:PNJ1_blase
        ++ Oui, je suis sûre. Je repasserai plus tard. #speaker:Player #portrait:Player_blase
            D'accord, à bientôt alors ! #speaker:PNJ1 #portrait:PNJ1_joy
            -> END
        ++ D'accord, je veux bien rejouer. #speaker:Player #portrait:Player_neutral
            Ah,  super ! C'est reparti alors ! #speaker:PNJ1 #portrait:PNJ1_joy
            -> gameBegin
+ Nan mais t'as triché, c'est certain ! #speaker:Player #portrait:Player_blase
Mmh. Je ne vois pas comment j'aurais pu tricher... #speaker:PNJ1 #portrait:PNJ1_blase
Tu veux rejouer ? #speaker:PNJ1 #portrait:PNJ1_blase
        ++ Oui, c'est parti ! #speaker:Player #portrait:Player_neutral
        ->gameBegin
        ++ Non, j'en ai marre. #speaker:Player #portrait:Player_blase
            Tu es sûre ? Tu ne peux pas passer au niveau suivant sans avoir réussi. #speaker:PNJ1 #portrait:PNJ1_blase
                +++ Oui, je suis sûre. Je repasserai plus tard. #speaker:PNJ1 #portrait:PNJ1_blase
                    D'accord, à bientôt alors ! #speaker:PNJ1 #portrait:PNJ1_joy
                    -> END
                +++ D'accord, je veux bien rejouer. #speaker:Player #portrait:Player_neutral
                    Ah,  super ! C'est reparti alors ! #speaker:PNJ1 #portrait:PNJ1_joy
                    -> gameBegin


== secondGame==

Bon, en fait, c'était trop facile. On va jouer à un autre jeu ! #speaker:PNJ1 #portrait:PNJ1_blase
Et cette fois-ci, ça sera bien plus compliqué, ah ah ! #speaker:PNJ1 #portrait:PNJ1_joy
Mais si tu gagnes... #speaker:PNJ1 #portrait:PNJ1_neutral
Je t'offrirai un deuxième ingrédient ! #speaker:PNJ1 #portrait:PNJ1_joy
Partante ? #speaker:PNJ1 #portrait:PNJ1_joy

+ Allez, c'est parti ! #speaker:Player #portrait:Player_joy
    -> secondGameRules
+ Mmh... Ok. #speaker:Player #portrait:Player_neutral
    -> secondGameRules
+ Non merci. #speaker:Player #portrait:Player_blase
-> END

== secondGameRules

On va jouer à Pierre/Feuille/Ciseaux/Lézard/Spock ! #speaker:PNJ1 #portrait:PNJ1_neutral
C'est très très simple !
Ce sont les mêmes règles qu'avant, mais avec un minuscule ajout : le lézard mange le papier, empoisonne Spock, est écrasé par la pierre et est décapité par les ciseaux. Spock vaporise la pierre, casse les ciseaux, et est discrédité par le papier.
Tu vois, c'est presque aussi simple !
->secondgameStart

== secondgameStart
On y va ?
+ Attends... Répète ? #speaker:Player #portrait:Player_gene
    le lézard mange le papier, empoisonne Spock, est écrasé par la pierre et est décapité par les ciseaux. Spock vaporise la pierre, casse les ciseaux, et est discrédité par le papier. #speaker:PNJ1 #portrait:PNJ1_neutral
    ->secondgameStart
+ Je suis prête !  #speaker:Player #portrait:Player_blase
-> secondGameGame

== secondGameGame

A trois !  #speaker:PNJ1 #portrait:PNJ1_neutral
Un !
Deux !
Trois !
+ Pierre  #speaker:Player #portrait:Player_joy
    Spock !
    ->secondGameLoose
+ Feuille  #speaker:Player #portrait:Player_joy
    Spock !
    ->secondGameWin
+ Ciseaux  #speaker:Player #portrait:Player_joy
    Spock !
    ->secondGameLoose
+ Lézard  #speaker:Player #portrait:Player_joy
    Spock !
    ->secondGameWin
+ Spock  #speaker:Player #portrait:Player_joy
    Spock !
    ->secondGameEgalite




== secondGameEgalite

Ah ah, on a choisi Spock tous les deux, c'est rigolo.  #speaker:PNJ1 #portrait:PNJ1_joy
Il va falloir rejouer.

+ Ok, rejouons ! #speaker:Player #portrait:Player_gene
    ->secondGameGame
+ Non, je n'ai plus envie de jouer, finalement. #speaker:Player #portrait:Player_sad
    Ah, dommage. Reviens me voir si tu vchanges d'avis !
    -> END
    
    
== secondGameWin

Bravo, tu as gagné ! #speaker:PNJ1 #portrait:PNJ1_joy
Voici quelques fraises pour te récompenser ! #newtext:3
... #speaker:PNJ1 #portrait:PNJ1_neutral
... #speaker:PNJ1 #portrait:PNJ1_blase
Comment ça, ce n'est pas la saison des fraises ?
Mais pourquoi chercher une logique à tout ça ?
Prends ces fraises et ne pose pas de questions !
Bon courage pour ton gâteau ! #speaker:PNJ1 #portrait:PNJ1_joy
A bientôt !
-> END


== secondGameLoose==

Dommage, tu as perdu ! #speaker:PNJ1 #portrait:PNJ1_neutral
Ce n'est pourtant pas compliqué.
Je t'assure !
Essaye encore.
+ Okay. #speaker:Player #portrait:Player_gene
-> secondGameGame
+ Non merci. #speaker:Player #portrait:Player_sad
    Ah... Tant pis, une prochaine fois peut-être !
    -> END

->END
== function random==
{shuffle:
-~return "Pierre"
-~return "Feuille"
-~return "Ciseaux"
}
