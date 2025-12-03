using System;
using EchoReborn;

namespace EchoReborn.Battle;

public class BattleSystem
{
    public BattleEtape State => state;
    private Character _character;
    private Enemy enemy;

    private BattleEtape state = BattleEtape.START;

    private BattleAction _pendingPlayerBattleAction = null;

    public BattleSystem(Character p, Enemy e)
    {
        _character = p;
        enemy = e;
    }

    public void StartBattle()
    {
        
    }

    public void Update()
    {
        switch (state)
        {
            case BattleEtape.START:
                StartPlayerTurn();
                break;

            case BattleEtape.PENDING_PLAYER:
                TryExecutePlayerAction();
                break;

            case BattleEtape.ENEMY_ACTION_EXECUTION:
                EnemyTurn();
                break;
        }
    }

    public void AcceptPlayerAction(BattleAction action)
    {
        if (state != BattleEtape.PENDING_PLAYER)
        {
            return;
        }

        _pendingPlayerBattleAction = action;
    }

    private void StartPlayerTurn()
    {
        

        // le vraie debut de jeu 

        
        state = BattleEtape.PENDING_PLAYER;
    }

    private void TryExecutePlayerAction()
    {
        
        if (_pendingPlayerBattleAction != null)
        {
            if (_pendingPlayerBattleAction.Target == BattleAction.TargetType.Enemy)
                _pendingPlayerBattleAction.Execute(_character, enemy);
            else
                _pendingPlayerBattleAction.Execute(_character, _character);
            if (CheckEnd())
                return;
            state = BattleEtape.PLAYER_ACTION_EXECUTION;
        }
    }
    private void EnemyTurn()
    {
        

        BattleAction battleAction = enemy.ChooseAction();// ici l'action est aléatoire ,on peut la changer si on veut 
        if (battleAction.Target == BattleAction.TargetType.Enemy)
            battleAction.Execute(enemy, _character);
        else
            battleAction.Execute(enemy, enemy);

        if (CheckEnd())
            return;

        state = BattleEtape.START;
    }

    private bool CheckEnd()
    {
        if (!enemy.IsAlive)
        {
            state = BattleEtape.VICTORY;
            return true;
        }

        if (!_character.IsAlive)
        {
            state = BattleEtape.DEFEAT;
            return true;
        }

        return false;
    }
}
