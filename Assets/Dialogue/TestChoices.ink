
-> main


=== main ===
Bonjour bonjour ! #speaker : PNJ1
Je m'appelle Pioupiou et je suis là pour te faire passer ta première épreuve. 
-> premiereQuestion

=== premiereQuestion ===

    + [Ma première épreuve ?]
        Eh oui ! Nous allons jouer à un jeu, et si tu gagnes, tu obtiendras un ingrédient nécessaire pour ta recette. #speaker : PNJ1
        ->jeu
    + [Tu t'appelles... Pioupiou ?]
        ...
        Je te signale que je ne suis qu'un personnage issu de TON imagination. #speaker : PNJ1
        ->premiereQuestion
    //* ->
    //->jeu
    
    === jeu ===
Tu es prête ? C'est parti ! #speaker : PNJ1
Nous allons jouer à Pierre/Feuille/Ciseaux !

-> END
