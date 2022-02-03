Halte là ! #speaker:Roi #portrait:PNJ2_oh
Où crois-tu aller comme ça ?
Tu ne peux pas passer.

+ Mais... #speaker:Eli #portrait:Player_sad
    Il n'y a pas de mais qui tienne ! #speaker:Roi #portrait:PNJ2_oh
-> roi1
+ Pourquoi ? #speaker:Eli #portrait:Player_sad
->roi1

+ D'accord, tant pis. Salut. #speaker:Eli #portrait:Player_blase
-> END

== roi1 ==
Il y a un coffre un peu plus loin avec des choses précieuses dedans.  #speaker:Roi #portrait:PNJ2_neutral
Enfin, c'est ce qu'on m'a dit. #speaker:Roi #portrait:PNJ2_neutral
Bref.
Si tu veux passer, tu vas devoir prouver ta valeur ! #speaker:Roi #portrait:PNJ2_laugh

+ D'accord, mais comment ? #speaker:Eli #portrait:Player_neutral
-> gameRule
+ J'ai de l'argent si tu veux... #speaker:Eli #portrait:Player_gene
    Malheureuse ! #speaker:Roi #portrait:PNJ2_laugh
    Tu crois vraiment que je suis intéressé par ton argent ?
    Tu fais donc partie de ceux qui croient que l'argent résout tous les problèmes ? #speaker:Roi #portrait:PNJ2_neutral
    On vit dans un drôle de monde, quand même !
    Et puis...
    Je suis sûr que ma couronne est bien plus précieuse que tout ce que tu pourrais m'offrir.  #speaker:Roi #portrait:PNJ2_laugh
    
    ++ Ok ok... #speaker:Eli #portrait:Player_blase
    ->gameRule
    ++ Veux-tu que l'on discute un peu de l'impact du capitalisme sur le monde et sur la société ? #speaker:Eli #portrait:Player_blase
        ... #speaker:Roi #portrait:PNJ2_oh
        ...
        Euh... #speaker:Roi #portrait:PNJ2_neutral
        Non...
        Ca ira. Je n'ai pas de temps à perdre. #speaker:Roi #portrait:PNJ2_gene
        Je suis très occupé, tu sais...
        A... garder ce passage.
        -> gameRule

== gameRule ==

Je vais te lancer un défi ! #speaker:Roi #portrait:PNJ2_laugh
Si tu réussis, je te laisserais passer. #speaker:Roi #portrait:PNJ2_neutral
Mais j'en doute ! #speaker:Roi #portrait:PNJ2_laugh
Ah ah ah !
J'ai crée un défi ABSOLUMENT IMPOSSIBLE.
Tu vois le sol coloré derrière moi ? #speaker:Roi #portrait:PNJ2_neutral #cam:1
Il va falloir le traverser pour réussir mon défi.
Rien de plus simple, n'est-ce pas ?

+ C'est tout ? #speaker:Eli #portrait:Player_gene
Ah ah ah, bien sûr que non ! #speaker:Roi #portrait:PNJ2_laugh
Vois-tu, chaque couleur a un effet. #speaker:Roi #portrait:PNJ2_neutral
->gameRule2
+ Mouais... C'est quoi le piège ? #speaker:Eli #portrait:Player_blase
Ah ah, je vois que tu as compris ! #speaker:Roi #portrait:PNJ2_laugh
Vois-tu, chaque couleur a un effet. #speaker:Roi #portrait:PNJ2_neutral
->gameRule2

== gameRule2 ==

Les cases vertes déclenchent une alarme : si tu marches dessus, tu devras combattre un monstre !  #speaker:Roi #portrait:PNJ2_neutral
Les cases jaunes sont électriques, si tu poses un pied dessus... Tu le sentiras passer !  #speaker:Roi #portrait:PNJ2_laugh
Les cases rouges sont des trappes qui te feront tomber, il faut donc sauter par-dessus pour passer. #speaker:Roi #portrait:PNJ2_neutral
Les cases oranges te feront sentir bon les oranges.
Les cases bleues sont remplies d'eau. Tu peux marcher dessus si tu n'as pas peur de te mouiller, mais si tu sens l'orange, tu attireras des pirahnas ! #speaker:Roi #portrait:PNJ2_laugh
Les cases violettes seront rendues glissantes si tu as marché dans l'eau juste avant, et elles te feront alors passer directement à la case suivante.  #speaker:Roi #portrait:PNJ2_neutral
Et enfin, il y a les cases roses !
Les cases roses... #speaker:Roi #portrait:PNJ2_oh
Ne font rien de spécial. #speaker:Roi #portrait:PNJ2_gene
Tu peux marcher dessus.
Comme tu le souhaites. #speaker:Roi #portrait:PNJ2_gene

Quand j'abaisserai ce levier, c'est une toute nouvelle combinaison de couleurs qui apparaîtra sous tes yeux ébahis ! #speaker:Roi #portrait:PNJ2_laugh
Moi-même, je ne peux pas prédire ce qu'elle sera ! #speaker:Roi #portrait:PNJ2_oh
Je ne pourrai pas t'aider, ah ah ah ! #speaker:Roi #portrait:PNJ2_laugh
Si ça se trouve, je serais coincé là moi aussi, ah ah ah !
Ah ah ah... #speaker:Roi #portrait:PNJ2_oh
Ah...
Aehm.
Tu es prête à relever le défi ? #speaker:Roi #portrait:PNJ2_neutral

+ Euh... C'est parti... #speaker:Eli #portrait:Player_blase
-> gameRule3
+ Euh, tu peux répéter les règles ? #speaker:Eli #portrait:Player_gene
    Bien sûr !  #speaker:Roi #portrait:PNJ2_neutral
-> gameRule2

== gameRule3 ==

Alors c'est parti !  #speaker:Roi #portrait:PNJ2_laugh
Attention !
J'abaisse le levier... #lever:1
->END