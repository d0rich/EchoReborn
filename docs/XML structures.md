# XML Structures

```mermaid
classDiagram
    class EchoReborn {
        +initialState: InitialState
        +gameState: GameState
    }

    class InitialState {
        +location: Locations
        +enemies: Enemies
        +caracter: Character
    }

    class Skill {
        +Id: Int
        +Name: String
        +Description: String
    }

    class SkillRef {
        +Id: Int
    }

    class Skills {
        +Skills: Skills
    }

    class SkillRefs {
        +SkillRefs: List<SkillRef>
    }

    class BasicSkill {
        +ManaCost: Int
        +HealthCost: Int
        +Damage: Int
        +Heal: Int
        +AnimationClass: String
        +TargetType: TargetType
    }

    class ComplexSkill {
        +SkillClass: String
    }

    class Locations {
        +LocationList: List<Location>
    }

    class LocationRef {
        +Id: Int
    }

    class Location {
        +Id: Int
        +Name: String
        +Difficulty: Int
        +NextLocation: LocationRef
        +EnemyEncounter: EnemyRefs
        +IsStartLocation: Boolean
        +IsFinalLocation: Boolean
    }

    class Enemies {
        +EnemyList: List<Enemy>
    }

    class Enemy {
        +Id: Int
        +Name: String
        +MaxHP: Int
        +Skill: SkillRefs
        +AnimationClass: String
        +RewardXP: Int
    }
    class EnemyRef {
        +Id: Int
    }
    class EnemyRefs {
        +EnemyRefs: List<EnemyRef>
    }

    class GameState {
        +SaveDate: DateTime
        +GameVersion: String
        +PlayTime: TimeSpan
        +Player: Character
        +World: World
    }

    class Character {
        +Level: Int
        +Experience: Int
        +CurrentHealth: Int
        +MaxHealth: Int
        +CurrentMana: Int
        +MaxMana: Int
        +Skills: SkillRefs
    }

    class World {
        +LatestClearedLocation: LocationRef
    }

    EchoReborn *-- InitialState : initialState
    EchoReborn *-- GameState : gameState
    GameState *-- Character
    GameState *-- World
    World *-- LocationRef

    InitialState *-- Skills : skills
    InitialState *-- Locations : location
    InitialState *-- Enemies : enemies
    InitialState *-- Character : character

    Skill <|-- BasicSkill
    Skill <|-- ComplexSkill

    EnemyRefs *-- EnemyRef
    SkillRefs *-- SkillRef

    LocationRef ..> Location
    EnemyRef ..> Enemy
    SkillRef ..> Skill

    Locations *-- Location
    Location *-- LocationRef
    Enemies *-- Enemy : EnemyList
    Enemy *-- SkillRefs : uses
    Skills *-- Skill
    Character *-- SkillRefs : starts with
    Location *-- EnemyRefs : encounters

```
