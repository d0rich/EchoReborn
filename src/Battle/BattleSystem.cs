using System;
using EchoReborn;

namespace EchoReborn.Battle;

class BattleSystem
{
    private Player player;
    private Enemy enemy;

    private BattleEtape state = BattleEtape.START;
    private bool battleOver = false;

    private Action pendingPlayerAction;

    public BattleSystem(Player p, Enemy e)
    {
        player = p;
        enemy = e;
    }

    public void StartBattle()
    {
        

        // Main loop
        while (!battleOver)
        {
            update();
            
        }
    }

    public void update()
    {
        switch (state)
        {
            case BattleEtape.START:
                StartPlayerTurn();
                break;

            case BattleEtape.PENDING_PLAYER:
                WaitForPlayerInput();
                break;

            case BattleEtape.PENDING_ENEMY:
                EnemyTurn();
                break;
        }
    }

    private void StartPlayerTurn()
    {
        

        // le vraie debut de jeu 

        
        state = BattleEtape.PENDING_PLAYER;
    }

    private void WaitForPlayerInput()
    {
        

        Console.ReadKey(true);// je l'ai mis ici juste pour tester la logique

        pendingPlayerAction = player.ChooseAction();//choisie l'action qu'on veut exécuter 
        pendingPlayerAction.Execute(enemy);

        if (CheckEnd())
            return;

        state = BattleEtape.PENDING_ENEMY;
    }

    private void EnemyTurn()
    {
        

        Action action = enemy.ChooseAction();// ici l'action est aléatoire ,on peut la changer si on veut 
        action.Execute(player);

        if (CheckEnd())
            return;

        state = BattleEtape.START;
    }

    private bool CheckEnd()
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

    private void EndBattle(string result)
    {
        battleOver = true;
        Console.WriteLine($"\n=== {result}! ===");
    }
}
