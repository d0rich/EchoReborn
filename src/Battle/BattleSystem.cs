using System;

namespace EchoReborn.Battle;

class BattleSystem
{
    Player player;
    Enemy enemy;
    bool battleOver = false;

    public BattleSystem(Player p, Enemy e)
    {
        player = p;
        enemy = e;
    }

    public void StartBattle()
    {
        Console.WriteLine("=== Battle Started ===");

        player.Initialize();
        enemy.Initialize();

        while (!battleOver)
        {
            DetermineTurnOrder();

            PlayerTurn();
            if (CheckEnd()) break;

            EnemyTurn();
            if (CheckEnd()) break;
        }
    }

    void DetermineTurnOrder()
    {
        Console.WriteLine("\n--- New Turn ---");
    }

    void PlayerTurn()
    {
        Console.WriteLine("Player's Turn");

        Action action = player.ChooseAction();
        action.Execute(enemy);
    }

    void EnemyTurn()
    {
        Console.WriteLine("Enemy's Turn");

        Action action = enemy.ChooseAction();
        action.Execute(player);
    }

    bool CheckEnd()
    {
        if (!enemy.IsAlive())
        {
            EndBattle("Victory");
            return true;
        }

        if (!player.IsAlive())
        {
            EndBattle("Defeat");
            return true;
        }

        return false;
    }

    void EndBattle(string result)
    {
        battleOver = true;
        Console.WriteLine($"\n=== {result}! ===");
    }
}