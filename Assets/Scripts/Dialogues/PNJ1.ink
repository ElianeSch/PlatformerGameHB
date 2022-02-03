
Salut à toi ! Je m'appelle Pioupiou. #speaker:Pioupiou #portrait:PNJ1_joy #perso:pioupiou
-> main

=== main ===

Tu trouveras la fin du niveau juste derrière moi, il te suffit de traverser la porte.
De nouveaux défis t'attendent un peu plus loin. #speaker:Pioupiou #portrait:PNJ1_neutral #perso:pioupiou
Quelle aventure !
Bon courage ! #speaker:Pioupiou #portrait:PNJ1_joy #perso:pioupiou

+ Merci du conseil. #speaker:Eli  #portrait:Player_neutral
    Ah ah, de rien !  #speaker:Pioupiou #portrait:PNJ1_joy
+ Tu t'appelles vraiment Pioupiou ? #speaker:Eli #portrait:Player_joy 
    ... #speaker:Pioupiou #portrait:PNJ1_neutral
    ...... #speaker:Pioupiou #portrait:PNJ1_blase
    Je te signale que je ne suis qu'un personnage issu de TON imagination. 
    Ce n'est quand même pas de ma faute si tu as du mal à trouver des noms corrects pour tes PNJs.
    
    De quoi tu parles ? #speaker:Eli  #portrait:Player_gene
    
    Non non, rien, oublie ça. #speaker:Pioupiou #portrait:PNJ1_blase
    On ne va quand même pas commencer par casser le quatrième mur. #speaker:Pioupiou #portrait:PNJ1_joy
    Bref. #speaker:Pioupiou #portrait:PNJ1_neutral

- C'est bientôt l'anniversaire de quelqu'un que j'aime beaucoup, et je voudrais lui offrir un gateau. #speaker:Eli #portrait:Player_neutral
Un truc bien, quoi, un truc un peu classe ! #speaker:Eli #portrait:Player_joy
Le problème, c'est que mes placards sont vides. #speaker:Eli #portrait:Player_sad
Et je n'ai pas d'argent !


Ah mince, la tuile ! #speaker:Pioupiou #portrait:PNJ1_neutral
Oh, mais tu sais quoi ? #speaker:Pioupiou #portrait:PNJ1_joy
Maintenant que j'y pense, j'ai une tablette de chocolat qui traîne dans ma poche ! #speaker:Pioupiou #portrait:PNJ1_joy
Si tu veux, on peut jouer à un jeu ! Et si tu gagnes, je te l'offre. 
Ca te va ? #speaker:Pioupiou #portrait:PNJ1_neutral

+ [Okay]
    Super ! On va jouer à Pierre/Feuille/Ciseaux ! #speaker:Pioupiou #portrait:PNJ1_joy 
    -> game
+ [Bof...] 
    Tu ne pourras pas passer au niveau suivant tant que tu n'auras pas joué avec moi. #speaker:Pioupiou #portrait:PNJ1_neutral
    Après tout, c'est moi qui garde la porte ! #speaker:Pioupiou #portrait:PNJ1_joy 
    Donc on va jouer quand même ! #speaker:Pioupiou #portrait:PNJ1_joy 
    On va jouer à Pierre/Feuille/Ciseaux ! #speaker:Pioupiou #portrait:PNJ1_neutral
    
    -> game

== game ==

J'imagine que je n'ai pas besoin de t'expliquer les règles. #speaker:Pioupiou #portrait:PNJ1_joy
Alors c'est parti !
->gameBegin
== gameBegin==
A trois ! #speaker:Pioupiou #portrait:PNJ1_neutral
Un...
Deux...
Trois ! #speaker:Pioupiou #portrait:PNJ1_joy

~ temp pnj = random()
+ Pierre ! #speaker:Eli #portrait:Player_neutral

{pnj} ! #speaker:Pioupiou #portrait:PNJ1_neutral 
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
+ Feuille ! #speaker:Eli #portrait:Player_neutral
~ pnj = random()
{pnj} ! #speaker:Pioupiou #portrait:PNJ1_neutral 
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
+ Ciseaux ! #speaker:Eli #portrait:Player_neutral
~ pnj = random()
{pnj} ! #speaker:Pioupiou #portrait:PNJ1_neutral 
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

Oh, égalité ! #speaker:Pioupiou #portrait:PNJ1_neutral
Il va falloir rejouer. #speaker:Pioupiou #portrait:PNJ1_joy
->gameBegin

== gagne==
Bravo, tu as gagné ! #speaker:Pioupiou #portrait:PNJ1_joy #newtext:1
Voici donc ton cadeau ! Tu l'as bien mérité. 
-> secondGame

==perdu==
Dommage, tu as perdu ! #speaker:Pioupiou #portrait:PNJ1_blase
Ce n'est pas bien grave, réessayons.  #speaker:Pioupiou #portrait:PNJ1_joy
+ C'est parti !
->gameBegin
+ Tu as triché, c'est certain ! #speaker:Eli #portrait:Player_blase
Mmh. Je ne vois pas comment j'aurais pu tricher... #speaker:Pioupiou #portrait:PNJ1_blase
Bref.
Rejouons, tu verras bien ! #speaker:Pioupiou #portrait:PNJ1_joy
->gameBegin


== secondGame==
Super ! Je vais pouvoir faire un gateau au chocolat ! #speaker:Eli #portrait:Player_joy
Et en plus, ça n'est pas n'importe quel chocolat ! Ton gateau sera trop bon avec ça ! #speaker:Pioupiou #portrait:PNJ1_joy
Bon, en fait, tu es beaucoup trop forte pour un simple jeu de Pierre/Feuille/Ciseaux... #speaker:Pioupiou #portrait:PNJ1_blase
Il te faut des défis à ta taille ! (Enfin...) #speaker:Pioupiou #portrait:PNJ1_joy
Comme on dit si bien : "A vaincre sans péril, on triomphe sans gloire !"

On parle toujours de cuisiner un gateau, là ? #speaker:Eli #portrait:Player_gene


On va jouer à un autre jeu ! #speaker:Pioupiou #portrait:PNJ1_neutral
Et cette fois-ci, ça sera bien plus compliqué, ah ah ! #speaker:Pioupiou #portrait:PNJ1_joy
Mais si tu gagnes... #speaker:Pioupiou #portrait:PNJ1_neutral
Je t'offrirai quelque chose d'autre ! #speaker:Pioupiou #portrait:PNJ1_joy
Un ingrédient qui n'est pas nécessaire pour ton gateau, mais qui lui donnera un petit truc en plus ! #speaker:Pioupiou #portrait:PNJ1_neutral
On va jouer à Pierre / Feuille / Ciseaux / Lézard / Spock ! #speaker:Pioupiou #portrait:PNJ1_joy
Est-ce que tu es d'accord ? #speaker:Pioupiou #portrait:PNJ1_neutral

+ Allez, c'est parti ! #speaker:Eli #portrait:Player_joy
    -> secondGameRules
+ Mmh... Ok. #speaker:Eli #portrait:Player_neutral
    -> secondGameRules
+ Non merci, je reviendrai plus tard. #speaker:Eli #portrait:Player_blase

D'accord, ce n'est pas grave ! Tu peux partir au prochain niveau si tu le souhaites. #speaker:Pioupiou #portrait:PNJ1_neutral
Reviens me voir si tu changes d'avis ! #speaker:Pioupiou #portrait:PNJ1_joy
-> END

== secondGameRules

Je disais donc, nous allons jouer à Pierre / Feuille / Ciseaux / Lézard / Spock !#speaker:Pioupiou #portrait:PNJ1_neutral
C'est très très simple !
Ce sont les mêmes règles qu'avant, mais avec un minuscule ajout : le lézard mange le papier, empoisonne Spock, est écrasé par la pierre et est décapité par les ciseaux. 
Spock vaporise la pierre, casse les ciseaux, et est désavoué par le papier.
Tu vois, c'est presque aussi simple !
->secondgameStart

== secondgameStart
On y va ?
+ Je suis prête !  #speaker:Eli #portrait:Player_blase
-> secondGameGame
+ Attends... Répète ?#speaker:Eli #portrait:Player_gene
    Le lézard mange le papier, empoisonne Spock, est écrasé par la pierre et est décapité par les ciseaux. #speaker:Pioupiou #portrait:PNJ1_neutral
    Spock vaporise la pierre, casse les ciseaux, et est désavoué par le papier.
    C'est bon cette fois ?
    ->secondgameStart


== secondGameGame

A trois !  #speaker:Pioupiou #portrait:PNJ1_neutral
Un !
Deux !
Trois !  #speaker:Pioupiou #portrait:PNJ1_joy
+ Pierre ! #speaker:Eli #portrait:Player_joy
    Spock !  #speaker:Pioupiou #portrait:PNJ1_neutral
    ->secondGameLoose
+ Feuille !  #speaker:Eli #portrait:Player_joy
    Spock !  #speaker:Pioupiou #portrait:PNJ1_neutral
    ->secondGameWin
+ Ciseaux !  #speaker:Eli #portrait:Player_joy
    Spock !  #speaker:Pioupiou #portrait:PNJ1_neutral
    ->secondGameLoose
+ Lézard ! #speaker:Eli #portrait:Player_joy
    Spock !  #speaker:Pioupiou #portrait:PNJ1_neutral
    ->secondGameWin
+ Spock !  #speaker:Eli #portrait:Player_joy
    Spock !  #speaker:Pioupiou #portrait:PNJ1_neutral
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
Bon courage pour ton gateau ! #speaker:Pioupiou #portrait:PNJ1_joy
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
== function random==
{shuffle:
-~return "Pierre"
-~return "Feuille"
-~return "Ciseaux"
}
