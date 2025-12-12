# Fiche signalétique — EchoReborn (version 0.2)

## Auteurs

- DOROFEEV Nikolai
- BENTAHA Ahcene
- DJAFRI Halim
- CHEIKH Mohamed Amine

## Informations générales

- Titre (provisoire) : EchoReborn
- Genre : JRPG / RPG au tour par tour
- Support cible : Desktop — Windows, macOS, Linux (multi-plateforme). MonoGame permet de viser ces plateformes.
- Technologie : C#, MonoGame, .NET 8.0
- Dépôt / projet : projet Visual Studio (.csproj) — nom de la solution : `EchoReborn.sln`

## Courte description

EchoReborn est un RPG au tour par tour construit avec MonoGame. Le joueur contrôle un ou plusieurs personnages, progresse dans un monde composé de quelques lieux, affronte des ennemis en combats au tour par tour, gère un inventaire et sauvegarde sa progression.

## Sujet / Pitch

Le protagoniste a été fragmenté : il part à la recherche de ses parties du corps dispersées à travers le monde. Dans chaque lieu se trouve un boss qui détient une partie manquante ; en le battant il récupère cette partie et obtient une compétence spéciale liée à celle-ci. Le récit et la progression sont centrés sur cette quête de réunification corporelle et sur la manière dont chaque partie récupérée modifie les capacités du personnage.

## Personnage principal

- Nom : (à définir)
- Description : personnage central fragmenté (physiquement et symboliquement). Chaque partie récupérée représente un palier de puissance et une nouvelle mécanique jouable.
- Mécanique clé : récupérer une partie du corps confère une compétence spéciale (ex. bras = attaque spéciale, jambe = dash / vitesse, œil = précision / portée, cœur = régénération / bonus passif).

## Style visuel

- Direction artistique (MVP) : pixel art / sprites image par image (frame-by-frame) adaptés pour des animations 2D simples. Le style privilégiera la lisibilité des actions (attaques, compétences, états) plutôt que le détail photoréaliste.
- Source recommandée : sprites gratuits CraftPix (Freebies) — https://craftpix.net/freebies/filter/sprites/ — utiliser ces packs comme ressources pour prototypage et placeholders.
- Lien principal CraftPix : https://craftpix.net/freebies/filter/sprites/
- Format recommandé : PNG, fonds transparents (alpha), tailles cohérentes (par ex. 32x32, 48x48 ou 64x64 par frame selon l'échelle de la caméra). Privilégier un multiple d'une grille (ex. 32 px) pour faciliter le placement et collisions.
- Animation : séquences image par image (idle, walk, attack, hurt, death). Importer chaque animation comme une série de fichiers nommés séquentiellement ou comme spritesheet (conserver convention de nommage).
- Licence : vérifier la licence de chaque asset CraftPix avant utilisation et mentionner les crédits si nécessaire (certaines ressources requièrent attribution).

### Packs supplémentaires (liens + aperçu)

- Free RPG Monster Sprites Pixel Art (CraftPix)
  - Lien : https://craftpix.net/freebies/free-rpg-monster-sprites-pixel-art/
  - Aperçu :

  ![Free RPG Monster Sprites](https://img.craftpix.net/2020/04/Free-RPG-Monster-Sprites-Pixel-Art.webp)
- Free Satyr Sprite Sheet (CraftPix)
  - Lien : https://craftpix.net/freebies/free-satyr-sprite-sheet-pixel-art-pack/
  - Aperçu :

  ![Free Satyr Sprite Sheet](https://img.craftpix.net/2025/01/Free-Satyr-Sprite-Sheet-Pixel-Art-Pack-1536x1024.webp)

- Free Fantasy Enemies Pixel Art Sprite Pack (CraftPix)
  - Lien : https://craftpix.net/freebies/free-fantasy-enemies-pixel-art-sprite-pack/
  - Aperçu :

  ![Free Fantasy Enemies](https://img.craftpix.net/2023/12/Free-Fantasy-Enemies-Pixel-Art-Sprite-Pack-1536x1024.webp)

- Free Wizard Sprite Sheets (CraftPix)
  - Lien : https://craftpix.net/freebies/free-wizard-sprite-sheets-pixel-art/
  - Aperçu :

  ![Free Wizard Sprite Sheets](https://img.craftpix.net/2023/01/Wizard-Sprite-Sheets-Pixel-Art-1536x1024.webp)

## Objectifs MVP (extrait et synthèse)

Fonctionnalités minimales à livrer pour une version jouable :

- Système de combat : combats au tour par tour, actions de base (Attaquer, Défendre, Utiliser objet, Fuir), compétences/compétences simples, calculs de dégâts/soins, conditions victoire/défaite.
- Monde et progression : 5 lieux, 3–5 types d'ennemis, transitions entre lieux, points de sauvegarde.
- UI minimale : menu principal, menu pause, interface de combat, menu inventaire, affichage des statistiques.
- Mécanique de progression liée au pitch : dans chaque location un boss principal détient une partie du corps de la protagoniste ; la victoire donne la partie récupérée et débloque une compétence spéciale associée.
- Assets graphiques (MVP) : utilisation de sprites gratuits image par image (frame-by-frame) provenant de CraftPix — https://craftpix.net/freebies/filter/sprites/ — à utiliser comme ressources/placeholder pour le prototype (prévoir vérification de la licence d'utilisation pour le contexte pédagogique).



## Système de combat

- Tour par tour avec alternance joueur / IA.
- Actions disponibles : Attaque, Défendre, etc.
- Tour : détermination de l'ordre, sélection d'action, exécution, vérification des conditions de fin (victoire, défaite, fuite), distribution des récompenses.


## Persistance / sauvegarde

- Format de sauvegarde attendu : XML (spécifié dans la doc).
- Entités principales sauvegardées : GameState (date, version, temps de jeu), Player (stats, position, inventaire, skills), World (locations, NPCs, objets), Quests, InventoryItem, Skills.
- Conventions : Int pour identifiants, DateTime ISO 8601, TimeSpan en format ISO 8601.



## Écrans

### Écran principal

Premier écran au lancement du jeu. Affiche le titre "Echo Reborn" en grand et propose trois options principales :
- **Start** : commencer une nouvelle partie ou continuer
- **Tests** : accéder au menu de sélection des scènes de test (développement)
- **Exit** : quitter le jeu

![Main Menu](./Screens/Main%20Menu.png)

### La Carte du monde

Le monde est composé de 5 locations reliées entre elles, formant un réseau progressif :
Location 1 → Location 2 ↔ Location 3 ↔ Location 4 ↔ Location 5.

**Le joueur peut** :

- Naviguer entre les lieux accessibles

- Suivre sa progression à travers le monde

- Affronter des ennemis spécifiques à chaque zone

- Récupérer un fragment du corps dans chaque location

**Détail des locations**:

**Location 1 – Campement Orc**

- Ennemis : Orcs

- Fragment récupéré : Les bras

**Location 2 – Forêt Sacrée**

- Ennemis : Elfes

- Fragment récupéré : Les oreilles

**Location 3 – Cimetière Oublié**

- Ennemis : créatures du cimetière

- Fragment récupéré : Les yeux

**Location 4 – Forteresse des Chevaliers**

- Ennemis : Knights

- Fragment récupéré : Les jambes

**Location 5 – Antre Magma**

- Ennemis : Monstres Spirits

- Fragment récupéré : Le cœur

![World Map](./Screens/Map.png)

### Écran de combat

Interface de combat au tour par tour divisée en deux zones :
- **Zone supérieure** : visualisation du Character (gauche) et de l'Enemy (droite) avec leurs sprites animés
- **Zone inférieure (HUD)** : 
  - **Gauche** : Character avec indicateur de Level, barres de HP (rouge), Energy (orange), XP (bleu) avec valeurs actuelles/max
  - **Centre** : panneau Skills avec liste de compétences disponibles (Attack, Heal, Mega Attack, etc.) et coûts en Energy. Navigation par pagination (triangles haut/bas)
  - **Droite** : Enemy avec barre de HP

**Note** : Pour chaque location, 5 ennemis différents. Le dernier est le boss.

![Battle Screen](./Screens/Battle.png)

### Écran de victoire

Écran affiché après avoir remporté un combat. Affiche "Victory" en grand et montre :
- **Gauche** : Character (bonhomme bâton) avec badge "?" indiquant récompense/drop
- **Centre** : barres de statistiques remplies (HP: 105/105, Energy: 105/105, XP: 5/200)
- **Droite** : panneau Skills mis à jour avec les compétences disponibles (Heal 5en, Mega Attack, Mega Heal 20en) et navigation
- **Bas** : bouton "Go to Map" pour retourner à la carte du monde

![Victory Screen](./Screens/Victory.png)

### Écran de défaite

Écran affiché en cas de défaite au combat. Affiche "Defeat" en grand et propose deux options :
- **Retry** : recommencer le combat
- **Go to Map** : retourner à la carte du monde (avec perte de progression du combat)

![Defeat Screen](./Screens/Defeat.png)

## Structure technique & contraintes observées

- Projet .NET 8.0.
- Usage attendu de MonoGame (moteur graphique 2D/3D léger ciblant C#).
- Pipeline de contenu présent (`Content/`, `Content.mgcb`).
- Implications multi-plateforme : prévoir validation des builds sur macOS et Linux, gestion des différences d'input/chemins de fichiers et packaging (exécutables, bundles, permissions). Mettre en place des procédures de test et, si possible, une CI multi-plateforme.
- Ressources graphiques : les textures et animations du MVP seront basées sur des sprites frame-by-frame gratuits (CraftPix Freebies). Vérifier les conditions de licence et crédit éventuel avant distribution.
