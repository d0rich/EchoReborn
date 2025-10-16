# Battle System Design Document

## Overview

A turn-based battle system for a JRPG game built with MonoGame. Players and enemies take alternating turns to perform actions: attack, use items, defend, or flee.

## Main Entities

- **Player** — the player's character participating in battle
- **Enemy** — opponent controlled by AI
- **BattleSystem** — controls battle flow, turn order, and action processing
- **Action** — abstraction for actions (attack, defend, item usage)
- **Inventory** — stores items that can be used in battle

## Battle Flow

1. Battle initialization (create participants, set initial parameters)
2. Determine turn order
3. Player selects an action
4. Enemy selects an action (AI)
5. Execute actions in order
6. Check battle end conditions (victory, defeat, flee)
7. End battle, distribute rewards

## Class Diagram

```mermaid
classDiagram
    class BattleSystem {
        +StartBattle()
        +Update()
        +EndBattle()
    }
    
    class Character {
        -string name
        -int hp
        -int attack
        -int defense
        +TakeDamage(int amount)
        +IsAlive() bool
    }
    
    class Player {
        -Inventory inventory
        +ChooseAction() Action
    }
    
    class Enemy {
        +ChooseAction() Action
    }
    
    class Action {
        +Execute(Character target)
    }
    
    class Inventory {
        -List~Item~ items
        +UseItem(Item item, Character target)
    }
    
    class Item
    
    BattleSystem --> Character
    Character <|-- Player
    Character <|-- Enemy
    Player --> Inventory
    Inventory --> Item
    
    Player -->"*" Action
    Enemy -->"*" Action

```

## Process

```mermaid
sequenceDiagram
    participant P as Player
    participant BS as BattleSystem
    participant E as Enemy
    participant A as Action

    BS->>BS: StartBattle()
    BS->>P: Initialize
    BS->>E: Initialize
    
    loop Battle Loop
        BS->>BS: Determine turn order
        
        alt Player's Turn
            BS->>P: Request action
            P->>P: ChooseAction()
            P-->>BS: Return Action
            BS->>A: Execute(Enemy)
            A->>E: TakeDamage()
            E->>E: IsAlive()
        end
        
        alt Enemy's Turn
            BS->>E: Request action
            E->>E: ChooseAction()
            E-->>BS: Return Action
            BS->>A: Execute(Player)
            A->>P: TakeDamage()
            P->>P: IsAlive()
        end
        
        BS->>BS: Check end conditions
        
        alt All enemies defeated
            BS->>BS: EndBattle(Victory)
        else Player defeated
            BS->>BS: EndBattle(Defeat)
        else Player fled
            BS->>BS: EndBattle(Flee)
        end
    end

```

## Available Actions

- Attack: deals damage to enemy
- Defend: reduces incoming damage
- Use Item: applies item effect from inventory
- Flee: attempt to escape from battle

## Victory/Defeat Conditions

- Victory: all enemies defeated
- Defeat: player HP reaches zero
- Flee: successful escape attempt

## Future Enhancements

- Multi-enemy battles
- Status effects (poison, stun)
- Special abilities and magic
- More complex AI behavior